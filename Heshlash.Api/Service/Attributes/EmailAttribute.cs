using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Heshlash.Api.Service.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var result = new MailAddress(value.ToString());

                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Not recognized as an email");
            }
        }
    }
}
