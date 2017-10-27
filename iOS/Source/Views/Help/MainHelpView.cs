using System;

using UIKit;

namespace KulGen.iOS.Source.Views.Help
{
	public partial class MainHelpView : UIViewController
	{
		public MainHelpView () : base ("MainHelpView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

