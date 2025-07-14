using TeamBalancer.API.Models.Domain;

namespace TeamBalancer.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<IEnumerable<Employee>> GetEmployeesByTeamIdAsync(Guid teamId);
        Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(string role);
        Task<IEnumerable<Employee>> GetEmployeesByTeamAndRoleAsync(Guid teamId, string role);
        Task<IEnumerable<Employee>> SearchESearchEmployeesAsync(string searchTerm);
        Task<IEnumerable<Employee>> GetEmployeesPagedAsync(int pageNumber, int pageSize);
    }
}
