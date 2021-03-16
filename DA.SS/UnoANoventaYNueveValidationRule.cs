using System;
using System.Globalization;
using System.Windows.Controls;

namespace DA.SS
{
    public class UnoADiezValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sVal = value as string;

            if (string.IsNullOrEmpty(sVal))
            {
                return new ValidationResult(false, "Ingrese un número");
            }

            float number;

            if (!float.TryParse(sVal,out number))
            {
                return new ValidationResult(false, "Solo números entre 1 y 10");
            }
            else
            {
                if (number > 0 && number <= 10)
                {
                    return new ValidationResult(true, null);
                }
                else
                    return new ValidationResult(false, "Solo números entre 1 y 10");

            }
        }
    }
}
