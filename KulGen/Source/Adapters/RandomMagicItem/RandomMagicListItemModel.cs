using System.Windows.Input;
using KulGen.Core;
using KulGen.DataModels;
using KulGen.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.Adapters.RandomMagicItem
{
	public class RandomMagicListItemModel : BaseViewModel
	{
		public ICommand ShowDescription { get { return new MvxCommand (DoShowDescription); } }

		public readonly INC<string> ItemName = new NC<string> ();
		public readonly INC<string> Description = new NC<string> ();
		public readonly INC<string> Location = new NC<string> ();
		public readonly INC<bool> Attune = new NC<bool> ();
		public readonly INC<int> Rarity = new NC<int> ();
		public readonly INC<int> Type = new NC<int> ();
		public readonly INC<bool> ShowDescriptionWindow = new NC<bool> ();

		public RandomMagicListItemModel (ILocalSettings settings, MagicItem magicItem) : base (settings)
		{
			ItemName.Value = magicItem.Name;
			Description.Value = magicItem.Description;
			Location.Value = magicItem.Location;
			Attune.Value = magicItem.Attune;
			Rarity.Value = magicItem.Rarity;
			Type.Value = magicItem.Type;
		}

		public void DoShowDescription ()
		{
			if (ShowDescriptionWindow.Value == true) {
				ShowDescriptionWindow.Value = false;
			} else {
				ShowDescriptionWindow.Value = true;
			}
		}
	}
}
