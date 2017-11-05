using System;
using KulGen.Source.ViewModels.Help;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace KulGen.iOS.Source.Views.Help
{
    public partial class MainHelpView : BaseViewController<MainHelpView, MainHelpViewModel>
	{
		public MainHelpView () : base ("MainHelpView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetupNavBar (ViewModel.Title);
			// Perform any additional setup after loading the view, typically from a nib.

            lblInitTitle.Text = ViewModel.InitTitle;
            lblStandard.Text = ViewModel.InitStandard;
            lblStandardDesc.Text = ViewModel.InitStandardDesc;
            lblGrayHawk.Text = ViewModel.InitGreyHawk;
            lblGrayHawkDesk.Text = ViewModel.InitGreyHawkDesc;
            lblNarrative.Text = ViewModel.InitNarrative;
            lblNarrativeDesk.Text = ViewModel.InitNarrativeDesc;
            lblMultipletitle.Text = ViewModel.MultiTitle;
            lblMultipleDesk.Text = ViewModel.MultiDesc;
            lblGrayHwakLink.Text = ViewModel.HelpLink;
            lblNarrativeLink.Text = ViewModel.HelpLink;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        protected override void SetupBindings(MvxFluentBindingDescriptionSet<MainHelpView, MainHelpViewModel> bindingSet)
        {
            //base.SetupBindings(bindingSet);
        }
    }
}

