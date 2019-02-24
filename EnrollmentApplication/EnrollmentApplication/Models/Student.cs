using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student
    {
        [Display(Name ="Student ID")]
        public virtual int      StudentID        { get; set; }

        [Required(ErrorMessage = "A last name is required")]
        [StringLength(50, ErrorMessage = "A last name not more than 50 characters is required")]
        [Display(Name ="Last Name")]
        public virtual string   StudentLastName  { get; set; }

        [Required(ErrorMessage = "A first name is required")]
        [StringLength(50, ErrorMessage = "A first name not more than 50 characters is required")]
        [Display(Name ="First Name")]
        public virtual string   StudentFirstName { get; set; }

    }
}