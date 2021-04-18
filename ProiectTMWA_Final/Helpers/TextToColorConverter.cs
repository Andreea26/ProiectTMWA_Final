using ProiectTMWA_Final.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProiectTMWA_Final.Helpers
{
    public class TextColorConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is StatusType && value != null)
            { 
                switch (value)
                {
                    case StatusType.IN_PROGRESS:
                        return Color.DarkOrange;
                    case StatusType.NOT_STARTED:
                        return Color.DarkBlue;
                    case StatusType.WATCHED:
                        return Color.DarkGreen;
                    default:
                        return Color.Black;
                }

            }
            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    } 
}
