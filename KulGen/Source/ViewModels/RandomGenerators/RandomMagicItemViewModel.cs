using System.Collections.Generic;
using System.Windows.Input;
using KulGen.Adapters.RandomMagicItem;
using KulGen.Core;
using KulGen.DataModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.ViewModels.Options
{
	public class RandomMagicItemViewModel : NavigationBarViewModel
	{
		public readonly INC<string> FilterText = new NC<string> ();

		public readonly INCList<RandomMagicListItemModel> ItemList = new NCList<RandomMagicListItemModel> ();

		public ICommand OpenFilter => new MvxCommand (DoOpenFilter);
		public ICommand UpdateRandomList { get { return new MvxCommand (DoUpdateRandomList); } }

		public string Title => "Random Magic Item";

		public RandomMagicItemViewModel (ILocalSettings settings) : base (settings)
		{
			FilterText.Value = "Click Here To Add Filter";
		}

		public override void ViewAppeared ()
		{
			base.ViewAppeared ();
			DoUpdateRandomList ();
		}

		void DoOpenFilter ()
		{
		}

		void DoUpdateRandomList()
		{
			var items = new List<RandomMagicListItemModel> ();
			items.Add (new RandomMagicListItemModel (settings, new MagicItem { ID = 1, Name = "HelloWorld", Description = "Hi", Rarity = 2, Attune = false, Type = 3 }));
			items.Add (new RandomMagicListItemModel (settings, new MagicItem { ID = 1, Name = "HelloWorld", Description = "Hi", Rarity = 2, Attune = false, Type = 3 }));

			ItemList.Value = items;
		}
	}
}
