using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EnrollmentApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string invalidChars;

        public InvalidCharsAttribute(string invalidChars) :base("{0} Notes contains unacceptable characters!")
        {
            this.invalidChars = invalidChars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                
                if (invalidChars.Contains("[~!@#$%^&*()_-[]{}|<>/]") == true)
                {
                    var errormessage = FormatErrorMessage(validationContext.DisplayName);

                    return new ValidationResult(errormessage);
                }
            }

            return ValidationResult.Success; 
            
        }
    }
}