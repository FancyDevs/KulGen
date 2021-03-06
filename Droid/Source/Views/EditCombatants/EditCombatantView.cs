﻿using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using KulGen.ViewModels.EditCombatants;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Views.EditCombatants
{
	[Activity (
		LaunchMode = LaunchMode.SingleTask,
		Theme = "@style/Theme.Main",
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class EditCombatantView : BaseView<EditCombatantView, EditCombatantViewModel>
	{
		protected override int LayoutResId => Resource.Layout.edit_combatant_layout;

		EditText editCharacterName;
		EditText editPlayerName;
		EditText editInitiative;
		EditText editMaxHealth;
		EditText editPassivePerception;
		EditText editArmorClass;
		LinearLayout layoutPlayerName;

		protected override void OnInitializeComponents ()
		{
			base.OnInitializeComponents ();

			editCharacterName = FindViewById<EditText> (Resource.Id.edit_character_name);
			editPlayerName = FindViewById<EditText> (Resource.Id.edit_player_name);
			editInitiative = FindViewById<EditText> (Resource.Id.edit_initiative);
			editMaxHealth = FindViewById<EditText> (Resource.Id.edit_max_health);
			editPassivePerception = FindViewById<EditText> (Resource.Id.edit_perception);
			editArmorClass = FindViewById<EditText> (Resource.Id.edit_armor);
			layoutPlayerName = FindViewById<LinearLayout> (Resource.Id.layout_edit_player_name);

			FindViewById<TextView> (Resource.Id.edit_text_character_name).Text = ViewModel.NameText;
			FindViewById<TextView> (Resource.Id.edit_text_initiative).Text = ViewModel.InitText;
			FindViewById<TextView> (Resource.Id.edit_text_max_health).Text = ViewModel.MaxHpText;
			FindViewById<TextView> (Resource.Id.edit_text_perception).Text = ViewModel.PercText;
			FindViewById<TextView> (Resource.Id.edit_text_armor).Text = ViewModel.AcText;
			FindViewById<TextView> (Resource.Id.edit_text_player_name).Text = ViewModel.PlayerNameText;

			SetupActionBar (ViewModel.Title);
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<EditCombatantView, EditCombatantViewModel> bindingSet)
		{
			bindingSet.Bind (editCharacterName).For (x => x.Text).To (vm => vm.CharacterName);
			bindingSet.Bind (editPlayerName).For (x => x.Text).To (vm => vm.PlayerName);
			bindingSet.Bind (layoutPlayerName).For ("Visibility").To (vm => vm.IsPlayer).WithConversion ("Visibility");
			bindingSet.Bind (editInitiative).For (x => x.Text).To (vm => vm.Initiative).WithConversion ("StringToIntConverter");
			bindingSet.Bind (editMaxHealth).For (x => x.Text).To (vm => vm.MaxHealth).WithConversion ("StringToIntConverter");
			bindingSet.Bind (editPassivePerception).For (x => x.Text).To (vm => vm.PassivePerception).WithConversion ("StringToIntConverter");
			bindingSet.Bind (editArmorClass).For (x => x.Text).To (vm => vm.ArmorClass).WithConversion ("StringToIntConverter");
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.edit_combatant_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == Resource.Id.menu_update) {
				ViewModel.UpdateClicked.Execute (null);
			} else if (item.ItemId == Resource.Id.menu_delete) {
				ViewModel.DeleteClicked.Execute (null);
			}

			return base.OnOptionsItemSelected (item);
		}
	}
}
