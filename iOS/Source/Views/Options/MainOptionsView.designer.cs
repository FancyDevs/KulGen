// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
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