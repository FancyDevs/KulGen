using System;

using UIKit;

namespace KulGen.iOS.Source.Views.Options
{
	public partial class MainOptionsView : UIViewController
	{
		public MainOptionsView () : base ("MainOptionsView", null)
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

