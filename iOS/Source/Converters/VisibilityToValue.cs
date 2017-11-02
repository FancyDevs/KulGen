using System;
using MvvmCross.Platform.Converters;

namespace KulGen.iOS.Source.Converters
{
    public class VisibilityToValue:MvxValueConverter<bool, int>
    {
        private readonly int constraintHeight = 85;
        protected override int Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value) 
                return constraintHeight;

            return 0;
        }
    }
}
