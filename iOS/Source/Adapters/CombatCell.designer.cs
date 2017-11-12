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
        UIKit.UIButton btnBackground { get; set; }


        [Outlet]
        UIKit.UIButton btnExpand { get; set; }


        [Outlet]
        UIKit.UIButton btnMaxHealth { get; set; }


        [Outlet]
        UIKit.UIButton btnMinus { get; set; }


        [Outlet]
        UIKit.UIButton btnPlus { get; set; }


        [Outlet]
        UIKit.UIButton btnUpdate { get; set; }


        [Outlet]
        UIKit.NSLayoutConstraint constraintExpand { get; set; }


        [Outlet]
        KulGen.iOS.Controls.Checkbox InitiativeCheckbox { get; set; }


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


        [Outlet]
        UIKit.UITextField txtHealth { get; set; }


        [Outlet]
        UIKit.UIView viewExpanded { get; set; }


        [Action ("ExpandAction:")]
        partial void ExpandAction (Foundation.NSObject sender);


        [Action ("HealthMinusAction:")]
        partial void HealthMinusAction (Foundation.NSObject sender);


        [Action ("HealthPlusAction:")]
        partial void HealthPlusAction (Foundation.NSObject sender);


        [Action ("MaxHealthAction:")]
        partial void MaxHealthAction (Foundation.NSObject sender);


        [Action ("updateAction:")]
        partial void updateAction (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnBackground != null) {
                btnBackground.Dispose ();
                btnBackground = null;
            }

            if (btnExpand != null) {
                btnExpand.Dispose ();
                btnExpand = null;
            }

            if (btnMaxHealth != null) {
                btnMaxHealth.Dispose ();
                btnMaxHealth = null;
            }

            if (btnMinus != null) {
                btnMinus.Dispose ();
                btnMinus = null;
            }

            if (btnPlus != null) {
                btnPlus.Dispose ();
                btnPlus = null;
            }

            if (btnUpdate != null) {
                btnUpdate.Dispose ();
                btnUpdate = null;
            }

            if (constraintExpand != null) {
                constraintExpand.Dispose ();
                constraintExpand = null;
            }

            if (InitiativeCheckbox != null) {
                InitiativeCheckbox.Dispose ();
                InitiativeCheckbox = null;
            }

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

            if (txtHealth != null) {
                txtHealth.Dispose ();
                txtHealth = null;
            }

            if (viewExpanded != null) {
                viewExpanded.Dispose ();
                viewExpanded = null;
            }
        }
    }
}