namespace EncoraOne.Grievance.API.Models
{
    public enum ComplaintStatus
    {
        Pending = 1,
        InProgress = 2,
        Resolved = 3,
        Cancelled = 4,
        Returned = 5 // New Status for returning to employee
    }
}