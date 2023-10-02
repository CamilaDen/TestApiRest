using System.ComponentModel.DataAnnotations;
using Utils.Exceptions;

namespace Utils.CustomValidator
{
    public class CustomValidator<T>
    {
        public static void DTOValidator(T dto)
        {
            if (dto == null)
            {
                throw new BadRequestException($"Solicitud incorrecta. Verifique la información enviada.");
            }

            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

            if (!isValid)
            {
                throw new BadRequestException($"{validationResults[0].ErrorMessage}");
            }
        }
    }
}
