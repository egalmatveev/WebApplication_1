using System.ComponentModel.DataAnnotations;

namespace WebApplication_1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'ФИО' обязательно для заполнения.")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Поле 'Номер телефона' обязательно для заполнения.")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Фотография")]
        public string? PhotoPath { get; set; }

        [Required(ErrorMessage = "Поле 'Отдел' обязательно для заполнения.")]
        [Display(Name = "Отдел")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
