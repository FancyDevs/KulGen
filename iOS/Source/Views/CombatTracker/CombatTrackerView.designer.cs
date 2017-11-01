// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace KulGen.iOS.Source.Views.CombatTracker
{
    [Register ("CombatTrackerView")]
    partial class CombatTrackerView
    {
        [Outlet]
        UIKit.UIButton btnAdd { get; set; }

        [Outlet]
        UIKit.UITableView combatantTable { get; set; }

        [Outlet]
        UIKit.UIView viewMenu { get; set; }

        [Action ("AddCombatantAction:")]
        partial void AddCombatantAction (Foundation.NSObject sender);

        [Action ("ClearAction:")]
        partial void ClearAction (Foundation.NSObject sender);

        [Action ("HelpAction:")]
        partial void HelpAction (Foundation.NSObject sender);

        [Action ("OptionsAction:")]
        partial void OptionsAction (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAdd != null) {
                btnAdd.Dispose ();
                btnAdd = null;
            }

            if (combatantTable != null) {
                combatantTable.Dispose ();
                combatantTable = null;
            }

            if (viewMenu != null) {
                viewMenu.Dispose ();
                viewMenu = null;
            }
        }
    }
}