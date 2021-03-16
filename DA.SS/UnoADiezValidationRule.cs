using System;
using System.Globalization;
using System.Windows.Controls;

namespace DA.SS
{
    public class UnoANoventaYNueveValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sVal = value as string;

            if (string.IsNullOrEmpty(sVal))
            {
                return new ValidationResult(false, "Ingrese un número");
            }

         
            if (!System.Text.RegularExpressions.Regex.IsMatch(sVal, @"^\d{1,2}(?:[-\s]\d{4})?$"))
            {
                return new ValidationResult(false, "Solo números entre 1 y 99");
            }
            else
            {
                if (Convert.ToInt32(sVal) == 0)
                {
                    return new ValidationResult(false, "Solo números entre 1 y 99");
                }
                else
                    return new ValidationResult(true, null);
            }
        }
    }
}
