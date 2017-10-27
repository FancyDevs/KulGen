using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Shire.iOS.Views
{
	public class TypedCellMvxSimpleTableViewSource<TCellView> : MvxSimpleTableViewSource where TCellView : MvxTableViewCell
	{
		public event EventHandler<TCellView> CellDisplayed;
		public event EventHandler<TCellView> CellHidden;

		public TypedCellMvxSimpleTableViewSource (UITableView tableView, string nibName, string cellIdentifier, NSBundle bundle = null)
			: base (tableView, nibName, cellIdentifier, bundle)
		{
		}

		public override void WillDisplay (UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			CellDisplayed?.Invoke (this, cell as TCellView);
		}

		public override void CellDisplayingEnded (UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			CellHidden?.Invoke (this, cell as TCellView);
		}
	}
}
