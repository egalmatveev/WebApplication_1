using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_1.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public List<Employee> Employees { get; set; }
    }
}
