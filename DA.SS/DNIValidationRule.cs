using System;
using System.Globalization;
using System.Windows.Controls;

namespace DA.SS
{
    public class DNIValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sVal = value as string;

            if (string.IsNullOrEmpty(sVal))
            {
                return new ValidationResult(false, "Ingrese un DNI");
            }


            if (!System.Text.RegularExpressions.Regex.IsMatch(sVal, @"^\d{1,8}(?:[-\s]\d{4})?$"))
            {
                return new ValidationResult(false, "Formato de DNI invalido");
            }
            else
            {
                if (Convert.ToInt32(sVal) == 0)
                {
                    return new ValidationResult(false, "Formato de DNI invalido");
                }
                else
                    return new ValidationResult(true, null);
            }
        }
    }
}
