using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;
using System.Globalization;
using Xamarin.Forms.Svg;

namespace Ejercicio2_1.Converter
{
    public class UrlToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var uriString = (string)value;
                Uri uri = new Uri(uriString);
                if (uri.AbsolutePath.ToLowerInvariant().EndsWith(".svg"))
                {
                    return SvgImageSource.FromSvgUri(uriString, 200, 200, default(Color));
                }
                else
                {
                    return ImageSource.FromUri(uri);
                }
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
