using ProiectTMWA_Final.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProiectTMWA_Final.Views
{
    public class StringToColorConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           
                StatusType s = (StatusType)value;
                switch (s)
                {
                    case StatusType.IN_PROGRESS:
                        return Color.OrangeRed;
                    case StatusType.NOT_STARTED:
                        return Color.DarkBlue;
                    case StatusType.WATCHED:
                         return Color.DarkGreen;
                    default:
                         return Color.Black;
                }

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
