// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace KulGen.iOS.Source.Views.Options
{
	[Register ("MainOptionsView")]
	partial class MainOptionsView
	{
		[Outlet]
		UIKit.UISegmentedControl smgInitiative { get; set; }

		[Outlet]
		UIKit.UISegmentedControl smgMultiple { get; set; }

		[Outlet]
		UIKit.UITextField txtComma { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (smgInitiative != null) {
				smgInitiative.Dispose ();
				smgInitiative = null;
			}

			if (smgMultiple != null) {
				smgMultiple.Dispose ();
				smgMultiple = null;
			}

			if (txtComma != null) {
				txtComma.Dispose ();
				txtComma = null;
			}
		}
	}
}
