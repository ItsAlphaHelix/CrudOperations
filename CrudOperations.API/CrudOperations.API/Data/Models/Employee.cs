using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperations.API.Data.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }

        public string Department { get; set; }
    }
}
