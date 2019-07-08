using System.Threading.Tasks;
using System.Windows.Input;
using KulGen.Core;
using KulGen.DataModels;
using KulGen.Source.Util;
using KulGen.ViewModels;
using KulGen.ViewModels.EditCombatants;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;

namespace KulGen.Adapters.CombatTracker
{
	public class CombatListItemModel : BaseViewModel
	{
		public ICommand EditItem { get { return new MvxAsyncCommand (DoEditItem); } }
		public ICommand SetHeal { get { return new MvxCommand (DoSetHeal); } }
		public ICommand SetDamage { get { return new MvxCommand (DoSetDamage); } }
		public ICommand SetMaxHealth { get { return new MvxCommand (DoSetMaxHealth); } }
		public ICommand MinusDamage { get { return new MvxCommand (DoMinusDamage); } }
		public ICommand AddDamage { get { return new MvxCommand (DoAddDamage); } }
		public ICommand ShowHideCombatWindow { get { return new MvxCommand (DoShowHideCombatWindow); } }
		public ICommand CombatantHasGone { get { return new MvxCommand (DoCombatantHasGone); } }

		public readonly INC<int> Initiative = new NC<int> ();
		public readonly INC<string> CharacterName = new NC<string> ();
		public readonly INC<string> PlayerName = new NC<string> ();
		public readonly INC<int> ArmorClass = new NC<int> ();
		public readonly INC<int> PassivePerception = new NC<int> ();
		public readonly INC<bool> HasGone = new NC<bool> ();
		public readonly INC<int> Health = new NC<int> ();
		public readonly INC<int> Damage = new NC<int> (1);
		public readonly INC<bool> ShowCombatWindow = new NC<bool> (false);
		public readonly INC<bool> IsCheckBoxInitiative = new NC<bool> (false);

		public Combatant combatant;

		public CombatListItemModel (ILocalSettings settings, IMvxNavigationService navigation, Combatant combatant) : base (settings, navigation)
		{
			this.combatant = combatant;
			IsCheckBoxInitiative.Value = settings.InitiativeOption == InitiativeOptions.Checkbox;

			Initiative.Value = combatant.Initiative;
			CharacterName.Value = combatant.Name;
			ArmorClass.Value = combatant.ArmorClass;
			PassivePerception.Value = combatant.PassivePerception;
			Health.Value = combatant.Health;
			HasGone.Value = combatant.HasGone;

			if (combatant.IsPlayer) {
				PlayerName.Value = combatant.PlayerName;
			} else {
				PlayerName.Value = "NPC";
			}
		}

		public async Task DoEditItem ()
		{
			settings.CurrentCombatant = combatant;
			await navigation.Navigate<EditCombatantViewModel> ();
		}

		void DoShowHideCombatWindow ()
		{
			Damage.Value = 1;
			if (ShowCombatWindow.Value == true) {
				ShowCombatWindow.Value = false;
			} else {
				ShowCombatWindow.Value = true;
			}
		}

		void DoMinusDamage ()
		{
			if(Damage.Value > 0){
				Damage.Value--;
			}
		}

		void DoAddDamage ()
		{
			Damage.Value++;
		}

		void DoSetHeal ()
		{
			Health.Value = Health.Value + Damage.Value;
			if(Health.Value > combatant.MaxHealth) {
				Health.Value = combatant.MaxHealth;
			}

			UpdateCombatantHealth ();
			DoShowHideCombatWindow ();
		}

		void DoSetDamage ()
		{
			Health.Value = Health.Value - Damage.Value;
			if (Health.Value < 0) Health.Value = 0;

			UpdateCombatantHealth ();
			DoShowHideCombatWindow ();
		}

		void DoSetMaxHealth ()
		{
			Health.Value = combatant.MaxHealth;
			UpdateCombatantHealth ();
			DoShowHideCombatWindow ();
		}

		void UpdateCombatantHealth ()
		{
			combatant.Health = Health.Value;
			settings.SQLiteDatabase.Update (combatant);
		}

		void DoCombatantHasGone ()
		{
			combatant.HasGone = HasGone.Value;
			settings.SQLiteDatabase.Update (combatant);
		}
	}
}
