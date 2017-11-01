using System;
using Foundation;
using KulGen.iOS.Source.Adapters;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace KulGen.iOS.Source.Views.CombatTracker
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class CombatTrackerView : BaseViewController<CombatTrackerView, CombatTrackerViewModel>
    {
        private CombatantTableSource combatantSource;

        public CombatTrackerView() : base("CombatTrackerView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIBarButtonItem menuItem = new UIBarButtonItem("Menu",
                                                           UIBarButtonItemStyle.Done,
                                                          (sender, e) =>
                                                          {
                                                              viewMenu.Hidden = !viewMenu.Hidden;
                                                          });

            NavigationItem.RightBarButtonItem = menuItem;

            ViewModel.UpdateCombatantList.Execute(null);

            combatantTable.Source = combatantSource;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        protected override void SetupBindings(MvxFluentBindingDescriptionSet<CombatTrackerView, CombatTrackerViewModel> bindingSet)
        {
            combatantSource = new CombatantTableSource(combatantTable);
            bindingSet.Bind(combatantSource).To(vm => vm.CombatantList);
            //bindingSet.Bind(fabClear).For("Visibility").To(vm => vm.IsCheckBoxInitiative).WithConversion("Visibility");
            //base.SetupBindings(bindingSet);
        }

        partial void AddCombatantAction(Foundation.NSObject sender) {
            viewMenu.Hidden = true;
            ViewModel.AddCombatItem.Execute(null);
        }

        partial void ClearAction(Foundation.NSObject sender) {
            viewMenu.Hidden = true;
            ViewModel.ClearCombatants.Execute(null);
        }

        partial void HelpAction(Foundation.NSObject sender) {
            viewMenu.Hidden = true;
            ViewModel.GoToHelp.Execute(null);
        }

        partial void OptionsAction(Foundation.NSObject sender) {
            viewMenu.Hidden = true;
            ViewModel.GoToOptions.Execute(null);
        }
    }

    public class CombatantTableSource : MvxTableViewSource     {         private static readonly NSString cellIdentifier = new NSString("CombatCell");          public CombatantTableSource(UITableView tableView) : base(tableView)
        {             tableView.RegisterNibForCellReuse(UINib.FromName(cellIdentifier, NSBundle.MainBundle), cellIdentifier);         }          protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)         {             CombatCell cell = (CombatCell)tableView.DequeueReusableCell(cellIdentifier, indexPath);             return cell;         }     }
}

