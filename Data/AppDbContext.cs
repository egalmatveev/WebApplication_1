using Microsoft.EntityFrameworkCore;
using WebApplication_1.Models; // Замените на ваше пространство имен моделей

namespace WebApplication_1.Data // Убедитесь, что пространство имен соответствует вашему проекту
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
