using System;
using Android.App;
using Android.Content.PM;
using Android.Widget;
using KulGen.Droid.Adapters.RandomMagicItem;
using KulGen.Droid.Views;
using KulGen.ViewModels.Options;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace KulGen.Droid.Source.Views.RandomGenerators
{
	[Activity (
		Label = "Options",
		LaunchMode = LaunchMode.SingleTask,
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class RandomMagicItemView : NavigationBarView<RandomMagicItemView, RandomMagicItemViewModel>
	{
		protected override int LayoutResId => Resource.Layout.random_magic_gen_layout;

		TextView buttonFilter;
		MvxListView itemList;

		protected override void OnInitializeComponents ()
		{
			base.OnInitializeComponents ();

			buttonFilter = FindViewById<TextView> (Resource.Id.text_random_magic_filter);
			itemList = FindViewById<MvxListView> (Resource.Id.list_random_magic);

			itemList.Adapter = new RandomMagicListAdapter (this, BindingContext as IMvxAndroidBindingContext);

			SetupActionBar (ViewModel.Title);
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<RandomMagicItemView, RandomMagicItemViewModel> bindingSet)
		{
			bindingSet.Bind (buttonFilter).For (v => v.Text).To (vm => vm.FilterText);
			bindingSet.Bind (itemList).For (x => x.ItemsSource).To (vm => vm.ItemList);
			base.SetupBindings (bindingSet);
		}

		protected override void OnResume ()
		{
			//fabAdd.Click += GenerateRandomList;
			ViewModel.UpdateRandomList.Execute (null);
			base.OnResume ();
		}

		protected override void OnPause ()
		{
			//fabAdd.Click -= GenerateRandomList;
			base.OnPause ();
		}

		void GenerateRandomList (object sender, EventArgs e)
		{
			//ViewModel.AddCombatItem.Execute (null);
		}
	}
}
