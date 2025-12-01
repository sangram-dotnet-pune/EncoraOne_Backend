#!/usr/bin/env bash
set -e

echo "Waiting for PostgreSQL..."
sleep 15

# Ensure dotnet-ef exists
if ! command -v dotnet-ef >/dev/null 2>&1; then
    echo "dotnet-ef not found — installing..."
    dotnet tool install --global dotnet-ef || dotnet tool update --global dotnet-ef
    export PATH="$PATH:/root/.dotnet/tools"
fi

echo "Checking if migrations already exist..."

MIGRATIONS_DIR="/app/Migrations"

if [ ! -d "$MIGRATIONS_DIR" ] || [ -z "$(ls -A $MIGRATIONS_DIR 2>/dev/null)" ]; then
    echo "No migrations found — creating InitialCreate migration..."
    dotnet ef migrations add InitialCreate --project /app/Grievance.API.csproj --startup-project /app
else
    echo "Migrations already exist — skipping creation."
fi

echo "Applying migrations to database..."

# Retry until PostgreSQL becomes ready
max_attempts=10
attempt=1
until dotnet ef database update --project /app/Grievance.API.csproj --startup-project /app; do
    if [ "$attempt" -ge "$max_attempts" ]; then
        echo "Migration update failed after $attempt attempts." >&2
        exit 1
    fi
    echo "Attempt $attempt failed — retrying in 5 seconds..."
    attempt=$((attempt+1))
    sleep 5
done

echo "Database migrations completed successfully!"