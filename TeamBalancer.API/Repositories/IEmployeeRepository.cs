using TeamBalancer.API.Models.Domain;

namespace TeamBalancer.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee?> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<IEnumerable<Employee>> GetEmployeesByTeamIdAsync(Guid teamId);
        Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(string role);
    }
}
