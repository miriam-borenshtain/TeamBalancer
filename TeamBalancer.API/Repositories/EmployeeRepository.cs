using Microsoft.EntityFrameworkCore;
using TeamBalancer.API.Data;
using TeamBalancer.API.Models.Domain;

namespace TeamBalancer.API.Repositories
{


    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TeamBalancerDbContext dbContext;
        public EmployeeRepository(TeamBalancerDbContext context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }
        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await dbContext.Employees.FindAsync(id).AsTask();


        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await GetEmployeeByIdAsync(employee.Id);
            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.FullName = employee.FullName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Position = employee.Position;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.IsActive = employee.IsActive;
            existingEmployee.TeamId = employee.TeamId;
            dbContext.Employees.Update(existingEmployee);
            await dbContext.SaveChangesAsync();
            return existingEmployee;
        }
        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return false;
            }
            dbContext.Employees.Remove(employee);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesByTeamIdAsync(Guid teamId)
        {
            return await dbContext.Employees.Where(e => e.TeamId == teamId).ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(string role)
        {
            return await dbContext.Employees.Where(e => e.Position == role).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByTeamAndRoleAsync(Guid teamId, string role)
        {
           return await dbContext.Employees.Where(e => e.TeamId == teamId && e.Position.ToLower() == role.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchESearchEmployeesAsync(string searchTerm)
        {
            return await dbContext.Employees.Where(e => e.FullName.Contains(searchTerm) || e.Email.Contains(searchTerm))
                .ToListAsync(); 
        }

        public async Task<IEnumerable<Employee>> GetEmployeesPagedAsync(int pageNumber, int pageSize)
        {
            return await dbContext.Employees.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
