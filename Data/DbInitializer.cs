using WebApplication_1.Models;
using System.Linq;
using Bogus;

namespace WebApplication_1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Проверяем, есть ли уже данные
            if (context.Employees.Any())
            {
                return; // База данных уже инициализирована
            }

            // Создаем отделы
            var departments = new Department[]
            {
                new Department { Name = "Отдел продаж" },
                new Department { Name = "Отдел маркетинга" },
                new Department { Name = "IT отдел" },
                new Department { Name = "HR отдел" },
                new Department { Name = "Бухгалтерия" }
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            // Обновляем идентификаторы отделов после сохранения
            var salesDeptId = departments.First(d => d.Name == "Отдел продаж").Id;
            var marketingDeptId = departments.First(d => d.Name == "Отдел маркетинга").Id;
            var itDeptId = departments.First(d => d.Name == "IT отдел").Id;
            var hrDeptId = departments.First(d => d.Name == "HR отдел").Id;
            var accountingDeptId = departments.First(d => d.Name == "Бухгалтерия").Id;

            // Создаем список идентификаторов отделов
            var departmentIds = new int[] { salesDeptId, marketingDeptId, itDeptId, hrDeptId, accountingDeptId };

            // Используем библиотеку Bogus для генерации фейковых данных
            var faker = new Faker<Employee>("ru")
                .RuleFor(e => e.FullName, f => f.Name.FullName())
                .RuleFor(e => e.PhoneNumber, f => f.Phone.PhoneNumber("8##########"))
                .RuleFor(e => e.DepartmentId, f => f.PickRandom(departmentIds))
                .RuleFor(e => e.PhotoPath, f => null);

            // Генерируем 1000 сотрудников
            var employees = faker.Generate(1000);

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
