using CrudOperations.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations.API.Data
{
    public class CrudOperationsDbContext : DbContext
    {
        public CrudOperationsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
