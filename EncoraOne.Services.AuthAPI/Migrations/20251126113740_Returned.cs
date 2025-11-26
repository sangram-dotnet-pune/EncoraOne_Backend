using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncoraOne.Grievance.API.Migrations
{
    /// <inheritdoc />
    public partial class Returned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 11, 37, 40, 186, DateTimeKind.Utc).AddTicks(5108));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 25, 17, 23, 46, 380, DateTimeKind.Utc).AddTicks(6382));
        }
    }
}
