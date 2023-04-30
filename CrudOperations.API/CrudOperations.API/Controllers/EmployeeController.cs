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
    }
}
