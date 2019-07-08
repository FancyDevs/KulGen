using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KulGen.Adapters.CombatTracker;
using KulGen.Droid.MvxBindings;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Adapters.CombatTracker
{
	public class CombatListItem : LinearLayout, IMvxListItem
	{
		public IMvxBindingContext BindingContext { get; set; }

		public int TemplateId => Resource.Layout.combat_item;

		public View Content { get; set; }

		public object DataContext
		{
			get {
				return BindingContext.DataContext;
			}
			set {
				if (BindingContext.DataContext == value) {
					return;
				}
				BindingContext.DataContext = value;
			}
		}

		TextView TextReset;
		TextView TextEdit;
		TextView TextDoHeal;
		TextView TextDoDamage;

		TextView TextInitiative;
		TextView TextCharacterName;
		TextView TextPlayerName;
		TextView TextArmorClass;
		TextView TextPassivePerception;
		TextView TextHealth;
		TextView TextMinusDamage;
		TextView TextPlusDamage;
		EditText EditDamage;
		ImageView ImgCombatWindow;
		LinearLayout LayoutEditBox;
		LinearLayout LayoutCombatBox;
		CheckBox checkBoxInitiative;

		public CombatListItem (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
			Init ();
		}

		public CombatListItem (Context context) : base (context)
		{
			Init (context);
		}

		void Init (Context context = null)
		{
			Clickable = true;
			Content = LayoutInflater.From (context).Inflate (TemplateId, this, true);

			//Buttons
			TextReset = FindViewById<TextView> (Resource.Id.reset_character);
			TextEdit = FindViewById<TextView> (Resource.Id.edit_character);
			TextDoHeal = FindViewById<TextView> (Resource.Id.heal_character);
			TextDoDamage = FindViewById<TextView> (Resource.Id.damage_character);
			TextMinusDamage = FindViewById<TextView> (Resource.Id.change_health_minus);
			TextPlusDamage = FindViewById<TextView> (Resource.Id.change_health_plus);

			TextInitiative = FindViewById<TextView> (Resource.Id.text_initiative);
			TextCharacterName = FindViewById<TextView> (Resource.Id.text_character_name);
			TextPlayerName = FindViewById<TextView> (Resource.Id.text_player_name);
			TextArmorClass = FindViewById<TextView> (Resource.Id.text_armor_class);
			TextPassivePerception = FindViewById<TextView> (Resource.Id.text_passive_perception);
			TextHealth = FindViewById<TextView> (Resource.Id.text_health);
			EditDamage = FindViewById<EditText> (Resource.Id.change_health_amount);
			ImgCombatWindow = FindViewById<ImageView> (Resource.Id.img_combat_window);
			LayoutEditBox = FindViewById<LinearLayout> (Resource.Id.layout_edit_box);
			LayoutCombatBox = FindViewById<LinearLayout> (Resource.Id.layout_expand_combat);
			checkBoxInitiative = FindViewById<CheckBox> (Resource.Id.checkbox_initiative);

			this.CreateBindingContext ();
			BindingContext.DelayBind (() => {
				var set = this.CreateBindingSet<CombatListItem, CombatListItemModel> ();
				set.Bind (checkBoxInitiative).For (x => x.Checked).To (vm => vm.HasGone);
				set.Bind (TextInitiative).For (x => x.Text).To (vm => vm.Initiative).WithConversion ("IntToStringConverter");
				set.Bind (TextCharacterName).For (x => x.Text).To (vm => vm.CharacterName);
				set.Bind (TextPlayerName).For (x => x.Text).To (vm => vm.PlayerName);
				set.Bind (TextArmorClass).For (x => x.Text).To (vm => vm.ArmorClass).WithConversion ("IntToStringConverter");
				set.Bind (TextPassivePerception).For (x => x.Text).To (vm => vm.PassivePerception).WithConversion ("IntToStringConverter");
				set.Bind (TextHealth).For (x => x.Text).To (vm => vm.Health).WithConversion ("IntToStringConverter");
				set.Bind (EditDamage).For (x => x.Text).To (vm => vm.Damage).WithConversion ("IntToStringConverter");

				set.Bind (checkBoxInitiative).For ("Visibility").To (vm => vm.IsCheckBoxInitiative).WithConversion ("Visibility");
				set.Bind (LayoutCombatBox).For ("Visibility").To (vm => vm.ShowCombatWindow).WithConversion ("Visibility");
				set.Bind (TextInitiative).For ("Visibility").To (vm => vm.IsCheckBoxInitiative).WithConversion ("InvertedVisibility"); 

				set.Bind (checkBoxInitiative).For (checkBoxInitiative.ClickEvent ()).To (vm => vm.CombatantHasGone);
				set.Bind (TextMinusDamage).For (TextMinusDamage.ClickEvent ()).To (vm => vm.MinusDamage);
				set.Bind (TextPlusDamage).For (TextPlusDamage.ClickEvent ()).To (vm => vm.AddDamage);
				set.Bind (TextEdit).For (TextEdit.ClickEvent ()).To (vm => vm.EditItem);
				set.Bind (TextDoHeal).For (TextDoHeal.ClickEvent ()).To (vm => vm.SetHeal);
				set.Bind (TextDoDamage).For (TextDoDamage.ClickEvent ()).To (vm => vm.SetDamage);
				set.Bind (TextReset).For (TextReset.ClickEvent ()).To (vm => vm.SetMaxHealth);
				set.Bind (ImgCombatWindow).For (ImgCombatWindow.ClickEvent ()).To (vm => vm.ShowHideCombatWindow);
				set.Bind (LayoutEditBox).For (LayoutEditBox.ClickEvent ()).To (vm => vm.EditItem);
				set.Apply ();
			});
		}

		protected override void Dispose (bool disposing)
		{
			BindingContext?.ClearAllBindings ();
			base.Dispose (disposing);
		}
	}
}
