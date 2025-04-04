using ITIWebApi.Context;
using System.ComponentModel.DataAnnotations;

namespace ITIWebApi.CustomValidate
{
    public class UniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DBContext b = validationContext.GetRequiredService<DBContext>();
            if (b.Departmments.FirstOrDefault(x => x.Name == value) != null)
            {
                return new ValidationResult("Name already exists");
            }
            return ValidationResult.Success;
        }
    }
}
