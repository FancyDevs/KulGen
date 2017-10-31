using System;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace KulGen.iOS.Source.Views.CombatTracker
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class CombatTrackerView : MvxViewController<CombatTrackerViewModel>
    {
        public CombatTrackerView() : base("CombatTrackerView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

