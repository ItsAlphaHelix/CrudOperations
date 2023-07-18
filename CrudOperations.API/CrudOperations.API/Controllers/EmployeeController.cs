namespace CrudOperations.API.Controllers
{
    using CrudOperations.API.Data;
    using CrudOperations.API.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CrudOperationsDbContext dbContext;
        public EmployeeController(CrudOperationsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await this.dbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();

            await this.dbContext.Employees.AddAsync(employeeRequest);
            await this.dbContext.SaveChangesAsync();

            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await this.dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditEmployee([FromRoute] Guid id, Employee updateEmployee)
        {
            var employee = await this.dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployee.Name;
            employee.PhoneNumber = updateEmployee.PhoneNumber;
            employee.Email = updateEmployee.Email;
            employee.Salary = updateEmployee.Salary;
            employee.Department = updateEmployee.Department;

            await this.dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await this.dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            this.dbContext.Employees.Remove(employee);
            await this.dbContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
