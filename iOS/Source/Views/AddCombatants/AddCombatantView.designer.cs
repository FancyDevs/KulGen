// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace KulGen.iOS.Source.Views.AddCombatants
{
    [Register ("AddCombatantView")]
    partial class AddCombatantView
    {
        [Outlet]
        UIKit.UISegmentedControl sgmPlayer { get; set; }


        [Outlet]
        UIKit.UISegmentedControl smgType { get; set; }


        [Outlet]
        UIKit.UITextField txtAmorClass { get; set; }


        [Outlet]
        UIKit.UITextField txtCombatant { get; set; }


        [Outlet]
        UIKit.UITextField txtCreateNumber { get; set; }


        [Outlet]
        UIKit.UITextField txtHealth { get; set; }


        [Outlet]
        UIKit.UITextField txtInitiative { get; set; }


        [Outlet]
        UIKit.UITextField txtPassiverPerception { get; set; }


        [Outlet]
        UIKit.UITextField txtPlayerName { get; set; }


        [Outlet]
        UIKit.UIView viewPlayer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (sgmPlayer != null) {
                sgmPlayer.Dispose ();
                sgmPlayer = null;
            }

            if (smgType != null) {
                smgType.Dispose ();
                smgType = null;
            }

            if (txtAmorClass != null) {
                txtAmorClass.Dispose ();
                txtAmorClass = null;
            }

            if (txtCombatant != null) {
                txtCombatant.Dispose ();
                txtCombatant = null;
            }

            if (txtCreateNumber != null) {
                txtCreateNumber.Dispose ();
                txtCreateNumber = null;
            }

            if (txtHealth != null) {
                txtHealth.Dispose ();
                txtHealth = null;
            }

            if (txtInitiative != null) {
                txtInitiative.Dispose ();
                txtInitiative = null;
            }

            if (txtPassiverPerception != null) {
                txtPassiverPerception.Dispose ();
                txtPassiverPerception = null;
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