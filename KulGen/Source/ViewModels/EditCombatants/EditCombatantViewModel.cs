using System.Windows.Input;
using KulGen.Core;
using KulGen.DataModels;
using KulGen.Resources;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.ViewModels.EditCombatants
{
	public class EditCombatantViewModel : NavigationBarViewModel
	{
		public readonly INC<string> CharacterName = new NC<string> ();
		public readonly INC<string> PlayerName = new NC<string> ();
		public readonly INC<int> Initiative = new NC<int> ();
		public readonly INC<int> MaxHealth = new NC<int> ();
		public readonly INC<int> ArmorClass = new NC<int> ();
		public readonly INC<int> PassivePerception = new NC<int> ();
		public readonly INC<bool> IsPlayer = new NC<bool> ();

		public ICommand UpdateClicked => new MvxCommand (DoUpdate);
		public ICommand DeleteClicked => new MvxCommand (DoDelete);

		public string Title => AppStrings.edit_title;
		public string PlayerText => AppStrings.add_edit_player;
		public string NpcText => AppStrings.add_edit_npc;
		public string NameText => AppStrings.add_edit_name;
		public string InitText => AppStrings.add_edit_init;
		public string MaxHpText => AppStrings.add_edit_max_hp;
		public string PercText => AppStrings.add_edit_perc;
		public string AcText => AppStrings.add_edit_ac;
		public string NumberText => AppStrings.add_edit_number;
		public string PlayerNameText => AppStrings.add_edit_player_name;

		Combatant combatant;

		public EditCombatantViewModel (ILocalSettings settings) : base (settings) {
			combatant = settings.CurrentCombatant;
		}

		public void Init ()
		{
			if (combatant != null) {
				CharacterName.Value = combatant.Name;
				IsPlayer.Value = combatant.IsPlayer;
				PlayerName.Value = combatant.PlayerName;
				Initiative.Value = combatant.Initiative;
				MaxHealth.Value = combatant.MaxHealth;
				ArmorClass.Value = combatant.ArmorClass;
				PassivePerception.Value = combatant.PassivePerception;
			}
		}

		void DoUpdate ()
		{
			combatant.Name = CharacterName.Value;
			combatant.IsPlayer = IsPlayer.Value;
			combatant.PlayerName = PlayerName.Value;
			combatant.Initiative = Initiative.Value;
			combatant.MaxHealth = MaxHealth.Value;
			combatant.ArmorClass = ArmorClass.Value;
			combatant.PassivePerception = PassivePerception.Value;

			settings.SQLiteDatabase.Update (combatant);
			ShowViewModel<CombatTrackerViewModel> ();
		}

		void DoDelete ()
		{
			settings.SQLiteDatabase.Delete (combatant);
			ShowViewModel<CombatTrackerViewModel> ();
		}
	}
}
