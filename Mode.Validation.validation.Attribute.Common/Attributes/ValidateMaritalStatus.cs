using Mode.Validation.validation.Attribute.Common.DTO;
using Mode.Validation.validation.Attribute.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Mode.Validation.validation.Attribute.Common.Attributes
{
    public class ValidateMaritalStatus : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var maritalStatus = (MaritalStatus)value;
            var personObj = (Person)validationContext.ObjectInstance;
            if (maritalStatus == MaritalStatus.Married)
            {
                var (valid, validationResult) = PerformValidation(personObj.SpouseFirstName, personObj.SpouseLastName);
                if (!valid)
                {
                    return validationResult;
                }
            }
            return ValidationResult.Success;
        }

        private (bool, ValidationResult) PerformValidation(string spouseFirstName, string spouseLastName)
        {
            return (string.IsNullOrWhiteSpace(spouseFirstName), string.IsNullOrWhiteSpace(spouseLastName)) switch
            {
                (true, true) => (false, new ValidationResult("Spouse First Name and Last Name is empty", new[] { nameof(spouseFirstName), nameof(spouseLastName) })),
                (true, false) => (false, new ValidationResult("Spouse First Name is empty", new[] { nameof(spouseFirstName) })),
                (false, true) => (false, new ValidationResult("Spouse Last Name is empty", new[] { nameof(spouseLastName) })),
                _ => (true, null)
            };
        }
    }
}
