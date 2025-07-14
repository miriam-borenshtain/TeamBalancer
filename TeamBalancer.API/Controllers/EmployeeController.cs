using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamBalancer.API.Models.DTO;
using TeamBalancer.API.Services;

namespace TeamBalancer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees =  await employeeService.GetAllEmployeesAsync();
            
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
           var employee = await employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var newEmployee = await employeeService.CreateEmployeeAsync(createEmployeeDto);
            return Ok(newEmployee);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var updatedEmployee = await employeeService.UpdateEmployeeAsync(id,updateEmployeeDto);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

    }
}
