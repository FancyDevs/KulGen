using System;
using Android.App;
using Android.Content.PM;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using KulGen.Droid.Adapters.CombatTracker;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;

namespace KulGen.Droid.Views.CombatTracker
{
	[Activity (
		Label = "Combat Tracker",
		LaunchMode = LaunchMode.SingleTask,
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class CombatTrackerView : NavigationBarView<CombatTrackerView, CombatTrackerViewModel>
	{
		protected override int LayoutResId => Resource.Layout.combat_tracker_layout;

		MvxListView combatantList;
		FloatingActionButton fabClear;
		FloatingActionButton fabAdd;
		RelativeLayout loading;

		protected override void OnInitializeComponents ()
		{
			base.OnInitializeComponents ();

			var toolbar = FindViewById<Toolbar> (Resource.Id.toptoolbar);
			fabAdd = FindViewById<FloatingActionButton> (Resource.Id.fab_add);
			fabClear = FindViewById<FloatingActionButton> (Resource.Id.fab_clear_checkboxes);
			combatantList = FindViewById<MvxListView> (Resource.Id.list_combat);
			loading = FindViewById<RelativeLayout> (Resource.Id.tracker_loading);

			combatantList.Adapter = new CombatantAdapter (this, BindingContext as IMvxAndroidBindingContext);

			SetupActionBar (ViewModel.Title);
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<CombatTrackerView, CombatTrackerViewModel> bindingSet)
		{
			base.SetupBindings (bindingSet);

			bindingSet.Bind (combatantList).For (x => x.ItemsSource).To (vm => vm.CombatantList);
			bindingSet.Bind (loading).For ("Visibility").To (vm => vm.Loading).WithConversion ("Visibility");
			bindingSet.Bind (fabClear).For ("Visibility").To (vm => vm.IsCheckBoxInitiative).WithConversion ("Visibility");
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.combat_tracker_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		protected override void OnResume ()
		{
			fabAdd.Click += AddCombatant;
			fabClear.Click += ClearCheckboxes;
			ViewModel.UpdateCombatantList.Execute (null);
			base.OnResume ();
		}

		protected override void OnPause()
		{
			fabAdd.Click -= AddCombatant;
			fabClear.Click -= ClearCheckboxes;
			base.OnPause ();
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.menu_clear:
					ViewModel.ClearCombatants.Execute (null);
					break;
				case Resource.Id.menu_options:
					ViewModel.GoToOptions.Execute (null);
					break;
				case Resource.Id.menu_help:
					ViewModel.GoToHelp.Execute (null);
					break;
			}

			return base.OnOptionsItemSelected (item);
		}

		void AddCombatant (object sender, EventArgs e)
		{
			ViewModel.AddCombatItem.Execute (null);
		}

		void ClearCheckboxes (object sender, EventArgs e)
		{
			ViewModel.ClearCheckBoxes.Execute (null);
		}
	}
}
