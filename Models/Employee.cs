using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEmployee.Models
{
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "eid is required")]

        public int eid { get; set; }

        [Required(ErrorMessage = "ename is required")]
        public string ename { get; set; }

        [Required(ErrorMessage = "dept is required")]
        public string dept { get; set; }

        [Required(ErrorMessage = "salary is required")]
        public int salary { get; set; }
        
        [Required(ErrorMessage = "age is required")]
        public int age { get; set; }

        [Required(ErrorMessage = "gender is required")]
        public string gender { get; set; }


        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }

    }
}

    

