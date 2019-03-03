using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student : IValidatableObject
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

        [Required]
        [Display(Name = "Address 1")]
        public virtual string Address1 { get; set; }

        [Required]
        [Display(Name = "Address 2")]
        public virtual string Address2 { get; set; }

        [Required]
        public virtual string City { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public virtual string Zipcode { get; set; }

        [Required]
        public virtual string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validation 1 : Address2 and Address 1 not the same
            if(Address1 == Address2)
            {
                yield return new ValidationResult("Address 2 cannot be the same as Address 1");
            }

            // Validation 2 : State is 2 digits
            int CountState = State.Length;

            if(CountState < 2 || CountState > 2)
            {
                yield return new ValidationResult("Enter a 2 digit State code ");
            }

            // Validation 3 : ZipCode is 5 digits
            int CountZip = Zipcode.Length;

            if (CountZip < 5 || CountZip > 5)
            {
                yield return new ValidationResult("Enter a 5 digit Zipcode");
            }
            
        }
    }
}