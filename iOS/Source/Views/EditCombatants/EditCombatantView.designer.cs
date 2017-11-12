// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace KulGen.iOS.Source.Views.EditCombatants
{
    [Register ("EditCombatantView")]
    partial class EditCombatantView
    {
        [Outlet]
        UIKit.UITextField txtArmor { get; set; }


        [Outlet]
        UIKit.UITextField txtCombatant { get; set; }


        [Outlet]
        UIKit.UITextField txtInitiative { get; set; }


        [Outlet]
        UIKit.UITextField txtMaxHealth { get; set; }


        [Outlet]
        UIKit.UITextField txtPerception { get; set; }


        [Outlet]
        UIKit.UITextField txtPlayerName { get; set; }


        [Outlet]
        UIKit.UIView viewPlayer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (txtArmor != null) {
                txtArmor.Dispose ();
                txtArmor = null;
            }

            if (txtCombatant != null) {
                txtCombatant.Dispose ();
                txtCombatant = null;
            }

            if (txtInitiative != null) {
                txtInitiative.Dispose ();
                txtInitiative = null;
            }

            if (txtMaxHealth != null) {
                txtMaxHealth.Dispose ();
                txtMaxHealth = null;
            }

            if (txtPerception != null) {
                txtPerception.Dispose ();
                txtPerception = null;
            }

            if (txtPlayerName != null) {
                txtPlayerName.Dispose ();
                txtPlayerName = null;
            }

            if (viewPlayer != null) {
                viewPlayer.Dispose ();
                viewPlayer = null;
            }
        }
    }
}