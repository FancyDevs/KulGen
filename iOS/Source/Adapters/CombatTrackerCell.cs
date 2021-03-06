﻿using System;
using Foundation;
using KulGen.Adapters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace KulGen.iOS.Source.Adapters
{
    public partial class CombatTrackerCell : MvxTableViewCell
	{
        public static readonly NSString Key = new NSString("CombatTrackerCell");
        public static readonly UINib Nib;

        static CombatTrackerCell()
        {
            Nib = UINib.FromName("CombatTrackerCell", NSBundle.MainBundle);
        }

        protected CombatTrackerCell(IntPtr handle) : base (handle) {
            this.DelayBind((() =>{
                var set = this.CreateBindingSet<CombatTrackerCell, CombatListItemModel>();
                //set.Bind(checkBoxInitiative).For(x => x.Checked).To(vm => vm.HasGone);
                //set.Bind(lblInitiative).For(x => x.Text).To(vm => vm.Initiative).WithConversion("IntToStringConverter");
                //set.Bind(lblCharacterName).For(x => x.Text).To(vm => vm.CharacterName);
                //set.Bind(lblPlayerName).For(x => x.Text).To(vm => vm.PlayerName);
                //set.Bind(lblAmorClass).For(x => x.Text).To(vm => vm.ArmorClass).WithConversion("IntToStringConverter");
                //set.Bind(lblPassive).For(x => x.Text).To(vm => vm.PassivePerception).WithConversion("IntToStringConverter");
                //set.Bind(lblHealth).For(x => x.Text).To(vm => vm.Health).WithConversion("IntToStringConverter");
                //set.Bind(EditDamage).For(x => x.Text).To(vm => vm.Damage).WithConversion("IntToStringConverter");

                //set.Bind(checkBoxInitiative).For("Visibility").To(vm => vm.IsCheckBoxInitiative).WithConversion("Visibility"); ;
                //set.Bind(LayoutCombatBox).For("Visibility").To(vm => vm.ShowCombatWindow).WithConversion("Visibility");
                //set.Bind(TextInitiative).For("Visibility").To(vm => vm.IsCheckBoxInitiative).WithConversion("InvertedVisibility"); ;

                //set.Bind(TextMinusDamage).For(TextMinusDamage.ClickEvent()).To(vm => vm.MinusDamage);
                //set.Bind(TextPlusDamage).For(TextPlusDamage.ClickEvent()).To(vm => vm.AddDamage);
                //set.Bind(TextUpdate).For(TextUpdate.ClickEvent()).To(vm => vm.UpdateHealth);
                //set.Bind(TextSetMaxHealth).For(TextSetMaxHealth.ClickEvent()).To(vm => vm.SetMaxHealth);
                //set.Bind(ImgCombatWindow).For(ImgCombatWindow.ClickEvent()).To(vm => vm.ShowHideCombatWindow);
                //set.Bind(LayoutEditBox).For(LayoutEditBox.ClickEvent()).To(vm => vm.EditItem);
                set.Apply();
            }));
        }

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			SelectionStyle = UIKit.UITableViewCellSelectionStyle.None;
			SeparatorInset = new UIKit.UIEdgeInsets (0, Bounds.Width, 0, 0);
		}
	}
}
