using System;
using System.Globalization;
using System.Windows.Controls;

namespace DA.SS
{
    public class CeroANoventaYNueveValidationRule : ValidationRule
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
                return new ValidationResult(false, "Solo números entre 0 y 99");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
