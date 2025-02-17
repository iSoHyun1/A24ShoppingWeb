using System.ComponentModel.DataAnnotations;

namespace A24Shopping.Repository.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extenstions = { "jpg", "png", "jpeg" };
                bool result = extenstions.Any(x => extension.EndsWith(x));
                
                if(!result)
                {
                    return new ValidationResult("Allowed extensions are jpg or png or jpeg");
                }
            }
            return ValidationResult.Success;
        }
    }
}
