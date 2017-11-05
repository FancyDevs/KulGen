using System;

using Foundation;
using KulGen.Adapters;
using KulGen.iOS.Source.Converters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace KulGen.iOS.Source.Adapters
{
	public partial class CombatCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString ("CombatCell");
		public static readonly UINib Nib;
		public UITableView TableView;

		static CombatCell ()
		{
			Nib = UINib.FromName ("CombatCell", NSBundle.MainBundle);
		}

		protected CombatCell (IntPtr handle) : base (handle)
		{
			this.DelayBind ((() => {

				InitiativeCheckbox.Initialize (UIImage.FromFile ("CheckboxEnabled.png"), UIImage.FromFile ("CheckboxDisabled.png"), false);

				var set = this.CreateBindingSet<CombatCell, CombatListItemModel> ();
				set.Bind (InitiativeCheckbox).For (x => x.IsChecked).To (vm => vm.HasGone);
				set.Bind (lblInitiative).For (x => x.Text).To (vm => vm.Initiative).WithConversion ("IntToStringConverter");
				set.Bind (lblCharacterName).For (x => x.Text).To (vm => vm.CharacterName);
				set.Bind (lblPlayerName).For (x => x.Text).To (vm => vm.PlayerName);
				set.Bind (lblArmorClass).For (x => x.Text).To (vm => vm.ArmorClass).WithConversion ("IntToStringConverter");
				set.Bind (lblPassive).For (x => x.Text).To (vm => vm.PassivePerception).WithConversion ("IntToStringConverter");
				set.Bind (lblHealth).For (x => x.Text).To (vm => vm.Health).WithConversion ("IntToStringConverter");
				set.Bind (txtHealth).For (x => x.Text).To (vm => vm.Damage).WithConversion ("IntToStringConverter");
				set.Bind (InitiativeCheckbox).For ("Hidden").To (vm => vm.IsCheckBoxInitiative).WithConversion ("Visibility");
				set.Bind (lblInitiative).For ("Hidden").To (vm => vm.IsCheckBoxInitiative).WithConversion ("InvertedVisibility");
				set.Bind (viewExpanded).For ("Hidden").To (vm => vm.ShowCombatWindow).WithConversion ("Visibility");

				set.Bind (btnMinus).To (vm => vm.MinusDamage);
				set.Bind (btnPlus).To (vm => vm.AddDamage);
				set.Bind (btnUpdate).To (vm => vm.UpdateHealth);
				set.Bind (btnMaxHealth).To (vm => vm.SetMaxHealth);
				set.Bind (btnExpand).To (vm => vm.ShowHideCombatWindow);
				set.Bind (btnBackground).To (vm => vm.EditItem);
				set.Apply ();
			}));


		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			btnExpand.TouchUpInside += (sender, e) => {
				TableView.ReloadData ();
			};

			btnMaxHealth.TouchUpInside += (sender, e) => {
				TableView.ReloadData ();
			};

			btnUpdate.TouchUpInside += (sender, e) => {
				TableView.ReloadData ();
			};
		}
	}
}
