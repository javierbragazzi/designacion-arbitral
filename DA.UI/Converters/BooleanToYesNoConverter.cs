using System;
using System.Windows.Data;

namespace DA.UI.Converters
{
    public class BooleanToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool) value == true)
                    return "Si";
                else
                    return "No";
            }

            return "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "Yes":
                    return true;
                case "No":
                    return false;
                default:
                    return Binding.DoNothing;
            }
        }
    }
}
