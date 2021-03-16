using System;
using System.Globalization;
using System.Windows.Controls;

namespace DA.SS
{
    public class UnoANovecientosNoventaYNueveMilValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sVal = value as string;

            if (string.IsNullOrEmpty(sVal))
            {
                return new ValidationResult(false, "Ingrese un número");
            }

         
            if (!System.Text.RegularExpressions.Regex.IsMatch(sVal, @"^\d{1,4}(?:[-\s]\d{4})?$"))
            {
                return new ValidationResult(false, "Solo números entre 1 y 9999");
            }
            else
            {
                if (Convert.ToInt32(sVal) == 0)
                {
                    return new ValidationResult(false, "Solo números entre 1 y 9999");
                }
                else
                    return new ValidationResult(true, null);
            }
        }
    }
}
