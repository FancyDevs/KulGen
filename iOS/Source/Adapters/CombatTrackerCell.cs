using System;
using KulGen.Adapters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;

namespace KulGen.iOS.Source.Adapters
{
    public partial class CombatTrackerCell : MvxTableViewCell
	{
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			SelectionStyle = UIKit.UITableViewCellSelectionStyle.None;
			SeparatorInset = new UIKit.UIEdgeInsets (0, Bounds.Width, 0, 0);

			var bindingSet = this.CreateBindingSet<CombatTrackerCell, CombatListItemModel> ();
			bindingSet.Apply ();
		}
	}
}
