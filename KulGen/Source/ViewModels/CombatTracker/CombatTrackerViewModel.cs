using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Akavache.Sqlite3.Internal;
using KulGen.Adapters.CombatTracker;
using KulGen.Core;
using KulGen.Core.Util;
using KulGen.DataModels;
using KulGen.Resources;
using KulGen.Source.Util;
using KulGen.ViewModels.AddCombatants;
using KulGen.ViewModels.Help;
using KulGen.ViewModels.Options;
using MvvmCross.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;

namespace KulGen.ViewModels.CombatTracker
{
	public class CombatTrackerViewModel : NavigationBarViewModel
	{
		public ICommand AddCombatItem { get { return new MvxAsyncCommand (DoAddCombatItem); } }
		public ICommand UpdateCombatantList { get { return new MvxAsyncCommand (DoUpdateCombatantList); } }
		public ICommand ClearCombatants { get { return new MvxAsyncCommand (DoClearCombatants); } }
		public ICommand GoToOptions { get { return new MvxAsyncCommand (DoGoToOptions); } }
		public ICommand GoToHelp { get { return new MvxAsyncCommand (DoGoToHelp); } }
		public ICommand ClearCheckBoxes { get { return new MvxCommand (DoClearCheckBoxes); } }

		public ImprovedObservableCollection<CombatListItemModel> CombatantList { get; } = new ImprovedObservableCollection<CombatListItemModel> ();

		public INC<bool> IsCheckBoxInitiative = new NC<bool> ();

		public string Title => AppStrings.ct_title;

		readonly IMvxMainThreadAsyncDispatcher mainThread;

		public CombatTrackerViewModel (ILocalSettings settings, IMvxNavigationService navigation, IMvxMainThreadAsyncDispatcher mainThread) : base (settings, navigation)
		{
			this.mainThread = mainThread;
		}

		public override void ViewAppeared ()
		{
			base.ViewAppeared ();
			DoUpdateCombatantList ();
		}

		async Task DoAddCombatItem ()
		{
			await navigation.Navigate<AddCombatantViewModel> ();
		}

		async Task DoUpdateCombatantList ()
		{
			Loading.Value = true;

			IsCheckBoxInitiative.Value = settings.InitiativeOption == InitiativeOptions.Checkbox;

			//Figure out which sort order is needed from the settings
			TableQuery<Combatant> combatantTableSorted = null;
			switch (settings.InitiativeOption) {
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

			await mainThread.ExecuteOnMainThreadAsync (() => {
				CombatantList.Clear ();
				foreach (var c in combatantTableSorted) {
					CombatantList.Add (new CombatListItemModel (settings, navigation, c));
				}
			});

			Loading.Value = false;
		}

		async Task DoClearCombatants ()
		{
			var list = settings.SQLiteDatabase.Table<Combatant> ();
			foreach(var combatant in list) {
				if(!combatant.IsPlayer){
					settings.SQLiteDatabase.Delete (combatant);
				}
			}

			await DoUpdateCombatantList ();
		}

		async Task DoGoToOptions ()
		{
			await navigation.Navigate<MainOptionsViewModel> ();
		}

		async Task DoGoToHelp()
		{
			await navigation.Navigate<MainHelpViewModel> ();
		}

		void DoClearCheckBoxes ()
		{
			foreach (CombatListItemModel c in CombatantList) {
				c.HasGone.Value = false;
				c.combatant.HasGone = false;
				settings.SQLiteDatabase.Update (c.combatant);
			}
		}
	}
}
