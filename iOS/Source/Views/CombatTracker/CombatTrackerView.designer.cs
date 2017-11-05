// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace KulGen.iOS.Source.Views.CombatTracker
{
	[Register ("CombatTrackerView")]
	partial class CombatTrackerView
	{
		[Outlet]
		UIKit.UIButton btnAdd { get; set; }

		[Outlet]
		UIKit.UIButton btnClear { get; set; }

		[Outlet]
		UIKit.UITableView combatantTable { get; set; }

		[Outlet]
		UIKit.UIView viewMenu { get; set; }

		[Action ("AddCombatantAction:")]
		partial void AddCombatantAction (Foundation.NSObject sender);

		[Action ("ClearAction:")]
		partial void ClearAction (Foundation.NSObject sender);

		[Action ("ClearCheckboxes:")]
		partial void ClearCheckboxes (Foundation.NSObject sender);

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

			if (btnClear != null) {
				btnClear.Dispose ();
				btnClear = null;
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
