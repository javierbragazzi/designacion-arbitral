using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DA.SS
{
    [ValueConversion(typeof(ValidationError), typeof(bool))]
    public class MultiFieldValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // foreach (object value in values)
            // {
            //return value as ValidationError == null;
            // }

            //return new ValidationError(new ValidationRule());

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
