using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEmployeCrud.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string FatherName { get; set; }
        [Required(ErrorMessage ="10 digit mobile number required")]
        [MaxLength(10, ErrorMessage = "Max 10 digits allowed")]
        public string Mobile { get; set; }
    }
}
 