using System.ComponentModel.DataAnnotations;

namespace TestApiRest.Validations
{
    public class EnumValidacionAttribute : ValidationAttribute
    {
        private readonly Type tipoEnum;

        public EnumValidacionAttribute(Type tipoEnum)
        {
            this.tipoEnum = tipoEnum;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //if(value != null)
            //{
            //    if(value is int intValue)
            //    {
            //        if(Enum.IsDefined(tipoEnum, intValue) && intValue >= 0 && intValue <= 2)
            //        {
            //            return ValidationResult.Success;
            //        }
            //        else if(intValue == 0)
            //        {
            //            return ValidationResult.Success;
            //        }
            //    }
            //    else if(value is string strValue)
            //    {
            //        if(Enum.TryParse(tipoEnum,strValue,true,out _))
            //        {
            //            return ValidationResult.Success;
            //        }
            //    }
  
            //    return new ValidationResult("El valor no es valido para tipoDocumento");
            //}
            return ValidationResult.Success;


        }
    }
}
