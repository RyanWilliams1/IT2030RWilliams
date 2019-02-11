using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Student
    {
        public virtual int      StudentID        { get; set; }
        public virtual string   StudentLastName  { get; set; }
        public virtual string   StudentFirstName { get; set; }

    }
}