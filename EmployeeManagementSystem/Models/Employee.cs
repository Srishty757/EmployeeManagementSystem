using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key] 
        public int EmployeeId { get; set; }

        [Display(Name = "Employee name")]
        [Required(ErrorMessage = "Employee Name Required")]
        [MinLength(5, ErrorMessage = "Minimum 5 char Required"), MaxLength(20, ErrorMessage = "Maximum 20 char Required")]
        public string EmployeeName { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "EmailId Required")]
        [MinLength(5, ErrorMessage = "Minimum 5 char Required"), MaxLength(30, ErrorMessage = "Maximum 30 char Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "City")]
        
        public string City { get; set; }


        [Display(Name = "Phone No")]
        [Required(ErrorMessage = "PhoneNo Required"), RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Phone no is not Valid")]
        [StringLength(10)]
        public string PhoneNo { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        //Foreign key for Department
        public Department DepartmentId { get; set; }

        //Foreign key for EmpManager
        public Employee EmployeeManager { get; set; }

    }
}