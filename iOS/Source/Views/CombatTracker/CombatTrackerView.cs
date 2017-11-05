using System;
using System.Collections.Generic;
using Foundation;
using KulGen.Adapters;
using KulGen.iOS.Source.Adapters;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.FieldBinding;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace KulGen.iOS.Source.Views.CombatTracker
{
	[MvxRootPresentation (WrapInNavigationController = true)]
	public partial class CombatTrackerView : BaseViewController<CombatTrackerView, CombatTrackerViewModel>
	{
		CombatantTableSource combatantSource;

		public CombatTrackerView () : base ("CombatTrackerView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SetupNavBar (ViewModel.Title);

			UIBarButtonItem menuItem = new UIBarButtonItem ("Menu",
														   UIBarButtonItemStyle.Done,
														  (sender, e) => {
															  viewMenu.Hidden = !viewMenu.Hidden;
														  });
			menuItem.SetTitleTextAttributes (GetNavButtonAttributes (), UIControlState.Normal);

			NavigationItem.RightBarButtonItem = menuItem;

			combatantTable.Source = combatantSource;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			ViewModel.UpdateCombatantList.Execute (null);
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<CombatTrackerView, CombatTrackerViewModel> bindingSet)
		{
			combatantSource = new CombatantTableSource (combatantTable);
			bindingSet.Bind (combatantSource).To (vm => vm.CombatantList);
			bindingSet.Bind (btnClear).For ("Hidden").To (vm => vm.IsCheckBoxInitiative).WithConversion ("Visibility");
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		partial void AddCombatantAction (Foundation.NSObject sender)
		{
			viewMenu.Hidden = true;
			ViewModel.AddCombatItem.Execute (null);
		}

		partial void ClearAction (Foundation.NSObject sender)
		{
			viewMenu.Hidden = true;
			ViewModel.ClearCombatants.Execute (null);
		}

		partial void HelpAction (Foundation.NSObject sender)
		{
			viewMenu.Hidden = true;
			ViewModel.GoToHelp.Execute (null);
		}

		partial void OptionsAction (Foundation.NSObject sender)
		{
			viewMenu.Hidden = true;
			ViewModel.GoToOptions.Execute (null);
		}

		partial void ClearCheckboxes (NSObject sender)
		{
			ViewModel.ClearCheckBoxes.Execute (null);
		}
	}

	public class CombatantTableSource : MvxTableViewSource
	{
		readonly int expandedHeight = 150;
		readonly int collapsedHeight = 55;
		static readonly NSString cellIdentifier = new NSString ("CombatCell");
		Dictionary<int, bool> expandedData;

		public CombatantTableSource (UITableView tableView) : base (tableView)
		{
			expandedData = new Dictionary<int, bool> ();
			tableView.RegisterNibForCellReuse (UINib.FromName (cellIdentifier, NSBundle.MainBundle), cellIdentifier);
		}

		protected override UITableViewCell GetOrCreateCellFor (UITableView tableView, NSIndexPath indexPath, object item)
		{
			var combatModel = (CombatListItemModel)item;
			if (expandedData.ContainsKey (indexPath.Row)) {
				expandedData[indexPath.Row] = combatModel.ShowCombatWindow.Value;
			} else {
				expandedData.Add (indexPath.Row, (combatModel.ShowCombatWindow.Value));
			}

			CombatCell cell = (CombatCell)tableView.DequeueReusableCell (cellIdentifier, indexPath);
			cell.TableView = tableView;
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;

			if (indexPath.Row % 2 == 1) {
				cell.BackgroundColor = UIColor.FromRGB (240, 240, 240);
			} else {
				cell.BackgroundColor = UIColor.White;
			}

			return cell;
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			if (expandedData[indexPath.Row])
				return expandedHeight;

			return collapsedHeight;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			base.RowSelected (tableView, indexPath);
		}
	}
}

