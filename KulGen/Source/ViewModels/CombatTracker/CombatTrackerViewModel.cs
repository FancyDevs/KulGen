using System.Collections.Generic;
using System.Windows.Input;
using KulGen.Adapters;
using KulGen.Adapters.CombatTracker;
using KulGen.Core;
using KulGen.DataModels;
using KulGen.Resources;
using KulGen.Source.Util;
using KulGen.ViewModels.AddCombatants;
using KulGen.ViewModels.Help;
using KulGen.ViewModels.Options;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;
using SQLite;

namespace KulGen.ViewModels.CombatTracker
{
	public class CombatTrackerViewModel : NavigationBarViewModel
	{
		public ICommand AddCombatItem { get { return new MvxCommand (DoAddCombatItem); } }
		public ICommand UpdateCombatantList { get { return new MvxCommand (DoUpdateCombatantList); } }
		public ICommand ClearCombatants { get { return new MvxCommand (DoClearCombatants); } }
		public ICommand GoToOptions { get { return new MvxCommand (DoGoToOptions); } }
		public ICommand GoToHelp { get { return new MvxCommand (DoGoToHelp); } }
		public ICommand ClearCheckBoxes { get { return new MvxCommand (DoClearCheckBoxes); } }

		public INCList<CombatListItemModel> CombatantList = new NCList<CombatListItemModel> ();
		public INC<bool> IsCheckBoxInitiative = new NC<bool> ();

		public string Title => AppStrings.ct_title;

		public CombatTrackerViewModel (ILocalSettings settings) : base (settings)
		{
		}

		public override void ViewAppeared ()
		{
			base.ViewAppeared ();
			DoUpdateCombatantList ();
		}

		void DoAddCombatItem ()
		{
			ShowViewModel<AddCombatantViewModel> ();
		}

		void DoUpdateCombatantList ()
		{
			IsCheckBoxInitiative.Value = settings.GetSavedInitiate () == InitiativeOptions.Checkbox;
			var combatantList = new List<CombatListItemModel> ();

			//Figure out which sort order is needed from the settings
			TableQuery<Combatant> combatantTableSorted = null;
			switch (settings.GetSavedInitiate ()) {
				case InitiativeOptions.Descending:
					combatantTableSorted = settings.SQLiteDatabase.Table<Combatant> ().OrderByDescending (x => x.Initiative);
					break;
				case InitiativeOptions.Ascending:
					combatantTableSorted = settings.SQLiteDatabase.Table<Combatant> ().OrderBy (x => x.Initiative);
					break;
				default:
					combatantTableSorted = settings.SQLiteDatabase.Table<Combatant> ().OrderBy (x => x.IsPlayer);
					break;
			}

			foreach (Combatant c in combatantTableSorted) {
				combatantList.Add (new CombatListItemModel (settings, c));
			}

			CombatantList.Value = combatantList;
		}

		void DoClearCombatants ()
		{
			settings.SQLiteDatabase.DeleteAll<Combatant> ();
			CombatantList.Value = new List<CombatListItemModel> ();
		}

		void DoGoToOptions ()
		{
			ShowViewModel<MainOptionsViewModel> ();
		}

		void DoGoToHelp()
		{
			ShowViewModel<MainHelpViewModel> ();
		}

		void DoClearCheckBoxes ()
		{
			foreach (CombatListItemModel c in CombatantList.Value) {
				c.HasGone.Value = false;
				c.combatant.HasGone = false;
				settings.SQLiteDatabase.Update (c.combatant);
			}
		}
	}
}
