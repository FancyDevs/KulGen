// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace KulGen.iOS.Source.Adapters
{
    [Register ("CombatTrackerCell")]
    partial class CombatTrackerCell
    {
        [Outlet]
        UIKit.UILabel lblAmorClass { get; set; }

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
            if (lblAmorClass != null) {
                lblAmorClass.Dispose ();
                lblAmorClass = null;
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
