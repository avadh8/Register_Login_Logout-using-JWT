using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Designation { get; set; }

    }
}
