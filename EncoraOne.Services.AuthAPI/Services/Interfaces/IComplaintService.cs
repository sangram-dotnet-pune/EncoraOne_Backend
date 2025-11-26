using System.Collections.Generic;
using System.Threading.Tasks;
using EncoraOne.Grievance.API.DTOs;

namespace EncoraOne.Grievance.API.Services.Interfaces
{
    public interface IComplaintService
    {
        Task<ComplaintResponseDto> CreateComplaintAsync(CreateComplaintDto createDto, int employeeId);
        Task<IEnumerable<ComplaintResponseDto>> GetComplaintsByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<ComplaintResponseDto>> GetComplaintsByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<ComplaintResponseDto>> GetAllComplaintsAsync();
        Task<bool> UpdateComplaintStatusAsync(UpdateComplaintStatusDto updateDto, int managerId);

        // NEW: Edit & Cancel for Employees
        Task<bool> EditComplaintAsync(int complaintId, CreateComplaintDto editDto, int employeeId);
        Task<bool> CancelComplaintAsync(int complaintId, int employeeId);
    }
}