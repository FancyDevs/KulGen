// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace KulGen.iOS.Source.Adapters
{
    [Register ("CombatCell")]
    partial class CombatCell
    {
        [Outlet]
        UIKit.UILabel lblArmorClass { get; set; }

        [Outlet]
        UIKit.UILabel lblCharacterName { get; set; }

        [Outlet]
        UIKit.UILabel lblHealth { get; set; }

        [Outlet]
        UIKit.UILabel lblInitiative { get; set; }

        [Outlet]
        UIKit.UILabel lblPassive { get; set; }

        [Outlet]
        UIKit.UILabel lblPlayerName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblArmorClass != null) {
                lblArmorClass.Dispose ();
                lblArmorClass = null;
            }

            if (lblCharacterName != null) {
                lblCharacterName.Dispose ();
                lblCharacterName = null;
            }

            if (lblHealth != null) {
                lblHealth.Dispose ();
                lblHealth = null;
            }

            if (lblInitiative != null) {
                lblInitiative.Dispose ();
                lblInitiative = null;
            }

            if (lblPassive != null) {
                lblPassive.Dispose ();
                lblPassive = null;
            }

            if (lblPlayerName != null) {
                lblPlayerName.Dispose ();
                lblPlayerName = null;
            }
        }
    }
}