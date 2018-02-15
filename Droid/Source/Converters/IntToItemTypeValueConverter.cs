using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace KulGen.Droid.Converters
{
	public class IntToItemTypeValueConverter : MvxValueConverter<int, string>
    {
		protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
			switch(value)
			{
				case 1:
					return "Armor";
				case 2:
					return "Potion";
				case 3:
					return "Ring";
				case 4:
					return "Staff/Wand";
				case 5:
					return "Scroll";
				case 6:
					return "Weapon";
				case 7:
					return "Wondrous Item";
				default:
					return "Armor";
			}
        }
    }
}
