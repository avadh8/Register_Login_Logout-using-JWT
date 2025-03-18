using System.ComponentModel.DataAnnotations;

namespace AuthUI.Models
{
    public class EmployeeViewModel
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
