using AutoMapper;
using TeamBalancer.API.Models.Domain;
using TeamBalancer.API.Models.DTO;
using TeamBalancer.API.Repositories;

namespace TeamBalancer.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository employeeRepository ,IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto employee)
        {
            var newEmployee = mapper.Map<Employee>(employee);
            newEmployee.IsActive = true;

            await employeeRepository.CreateEmployeeAsync(newEmployee);
            return mapper.Map<EmployeeDto>(newEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var exsitEmployee = await employeeRepository.GetEmployeeByIdAsync(id);
            if (exsitEmployee == null)
            {
                return false;
            }
            await employeeRepository.DeleteEmployeeAsync(id);
            return true;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees =  await employeeRepository.GetAllEmployeesAsync();
            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null) {
                return null;
            }
            return mapper.Map<EmployeeDto>(employee);
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesByTeamAndRoleAsync(Guid teamId, string role)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByTeamIdAsync(Guid teamId)
        {
            var employees = await employeeRepository.GetEmployeesByTeamIdAsync(teamId);
            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesPagedAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeDto>> SearchEmployeesAsync(string searchTerm)
        {
            var employees = await employeeRepository.SearchEmployeesAsync(searchTerm);
            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var exsitEmployee = await employeeRepository.GetEmployeeByIdAsync(id);
            if (exsitEmployee == null)
            {
                return null;
            }
            mapper.Map(updateEmployeeDto, exsitEmployee);
            await employeeRepository.UpdateEmployeeAsync(exsitEmployee);
            return mapper.Map<EmployeeDto>(exsitEmployee);
                
        }
    }
}
