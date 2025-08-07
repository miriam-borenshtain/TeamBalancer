using TeamBalancer.API.Models.Domain;
using TeamBalancer.API.Models.DTO;

namespace TeamBalancer.API.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id);

        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto employee);
        Task<EmployeeDto?> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto updateEmployeeDto);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByTeamIdAsync(Guid teamId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByRoleAsync(string role);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByTeamAndRoleAsync(Guid teamId, string role);
        Task<IEnumerable<EmployeeDto>> SearchEmployeesAsync(string searchTerm);
        Task<IEnumerable<EmployeeDto>> GetEmployeesPagedAsync(int pageNumber, int pageSize);


    }
}
