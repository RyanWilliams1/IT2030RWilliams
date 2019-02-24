using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        [Display(Name = "Course ID")]
        public virtual int      CourseID            { get; set; }

        [Required(ErrorMessage = "A Course Title is required")]
        [StringLength(150)]
        [Display(Name = "Course Title")]
        public virtual string   CourseTitle         { get; set; }

        [Display(Name = "Description")]
        public virtual string   CourseDescription   { get; set; }

        [Required(ErrorMessage = "A credit value is required")]
        [Range(1,4, ErrorMessage = "A value between 1 and 4 is required")]
        [Display(Name = "Number of Credits")]
        public virtual int      CourseCredits       { get; set; }
    }
}