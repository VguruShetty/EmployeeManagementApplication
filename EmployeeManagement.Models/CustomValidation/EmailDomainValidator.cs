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
        public string AllowedDomain { get; set; } = "gmail.com";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] strings = value.ToString().Split('@');
               if (strings.Length > 1 && strings[1].ToLower() == AllowedDomain.ToLower())
                {
                    return null;
                }
                else
                {
                    return new ValidationResult($"Email domain must be {AllowedDomain}",
                        new[] { validationContext.MemberName });
                }
            }
            return null;
        }
    }
}
