using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.CustomValidation
{
    public class EmailDomainValidator: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            if (strings[1].ToLower() == "gmail.com")
            {
                return null;
            }
            else
            {
                return new ValidationResult("Email domain must be gmail.com",
                    new[] { validationContext.MemberName });
            }
        }
    }
}
