using System.Globalization;
using System.Windows.Controls;

namespace DA.SS
{
    public class SoloLetrasValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sVal = value as string;

            if (string.IsNullOrEmpty(sVal))
            {
                return new ValidationResult(false, "Ingrese algún texto");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(sVal, @"^[a-zA-Z\u00C0-\u00FF ]+$"))
            {
                return new ValidationResult(false, "Solo debe contener letras");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }

    }
}
