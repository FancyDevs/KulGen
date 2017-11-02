using System;
using KulGen.Source.Util;
using KulGen.Source.ViewModels.Options;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace KulGen.iOS.Source.Views.Options
{
    public partial class MainOptionsView : BaseViewController<MainOptionsView, MainOptionsViewModel>
	{
		public MainOptionsView () : base ("MainOptionsView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

            UIBarButtonItem addItem = new UIBarButtonItem("Save",
                                                          UIBarButtonItemStyle.Done,
                                                          (sender, e) => {
                ViewModel.SaveOptions.Execute(null);
                                                          });

            NavigationItem.RightBarButtonItem = addItem;

            smgInitiative.ValueChanged += (sender, e) => {
                switch (smgInitiative.SelectedSegment) {
                    case 0:
                        ViewModel.Initiative.Value = InitiativeOptions.Descending;
                        break;
                    case 1:
                        ViewModel.Initiative.Value = InitiativeOptions.Ascending;
                        break;
                    case 2:
                        ViewModel.Initiative.Value = InitiativeOptions.Checkbox;
                        break;
                }
            };

            smgMultiple.ValueChanged += (sender, e) => {
                switch (smgMultiple.SelectedSegment)
                {
                    case 0:
                        ViewModel.MultiNpcSuffix.Value = MultiNpcSuffixOptions.Numeric;
                        ViewModel.IsCustomNpcSuffix.Value = false; ;
                        break;
                    case 1:
                        ViewModel.MultiNpcSuffix.Value = MultiNpcSuffixOptions.Alphabetic;
                        ViewModel.IsCustomNpcSuffix.Value = false;
                        break;
                    case 2:
                        ViewModel.MultiNpcSuffix.Value = MultiNpcSuffixOptions.Custom;
                        ViewModel.IsCustomNpcSuffix.Value = true;
                        break;
                }
            };

            smgInitiative.SelectedSegment = (int)ViewModel.Initiative.Value;
            smgMultiple.SelectedSegment = (int)ViewModel.MultiNpcSuffix.Value;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        protected override void SetupBindings(MvxFluentBindingDescriptionSet<MainOptionsView, MainOptionsViewModel> bindingSet)
        {
            bindingSet.Bind(txtComma).For("Hidden").To(vm => vm.IsCustomNpcSuffix).WithConversion("Visibility");
            bindingSet.Bind(txtComma).For(v => v.Text).To(vm => vm.MultiNpcCustomSuffix);
        }
    }
}

