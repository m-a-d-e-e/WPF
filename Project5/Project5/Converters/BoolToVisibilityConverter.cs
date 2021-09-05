using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Project5.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
       
        public Visibility TrueValue { get; set; }
        
        public Visibility FalseValue { get; set; }

        public Visibility NullValue { get; set; }


        public BoolToVisibilityConverter()
        {
            TrueValue = Visibility.Visible;
            FalseValue = Visibility.Hidden;
            NullValue = Visibility.Hidden;
        }
 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return NullValue;
            }
            bool b;
            bool.TryParse(value.ToString(), out b);
            return b ? TrueValue : FalseValue;
        }

        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
