using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace KulGen.Droid.Converters
{
	public class IntToRarityValueConverter : MvxValueConverter<int, string>
    {
		protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
			switch(value)
			{
				case 1:
					return "Common";
				case 2:
					return "Uncommon";
				case 3:
					return "Rare";
				case 4:
					return "Very Rare";
				case 5:
					return "Legendary";
				default:
					return "Common";
			}
        }
    }
}
