﻿using System.Threading.Tasks;
using System.Windows.Input;
using KulGen.Core;
using KulGen.DataModels;
using KulGen.Resources;
using KulGen.Source.Util;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;

namespace KulGen.ViewModels.AddCombatants
{
	public class AddCombatantViewModel : BaseViewModel
	{
		const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		public readonly INC<string> CharacterName = new NC<string> ();
		public readonly INC<string> PlayerName = new NC<string> ();
		public readonly INC<int> Initiative = new NC<int> ();
		public readonly INC<int> Health = new NC<int> ();
		public readonly INC<int> ArmorClass = new NC<int> ();
		public readonly INC<int> PassivePerception = new NC<int> ();
		public readonly INC<int> CreateNumber = new NC<int> (1);
		public readonly INC<bool> IsPlayer = new NC<bool> (false);

		public ICommand AddClicked => new MvxAsyncCommand (DoAdd);

		public string Title => AppStrings.add_title;
		public string PlayerText => AppStrings.add_edit_player;
		public string NpcText => AppStrings.add_edit_npc;
		public string NameText => AppStrings.add_edit_name;
		public string InitText => AppStrings.add_edit_init;
		public string MaxHpText => AppStrings.add_edit_max_hp;
		public string PercText => AppStrings.add_edit_perc;
		public string AcText => AppStrings.add_edit_ac;
		public string NumberText => AppStrings.add_edit_number;
		public string PlayerNameText => AppStrings.add_edit_player_name;

		public AddCombatantViewModel (ILocalSettings settings, IMvxNavigationService navigation) : base (settings, navigation) { }

		async Task DoAdd ()
		{
			if (!IsPlayer.Value) {
				AddNPC ();
			} else {
				AddPlayer ();
			}

			await navigation.Navigate<CombatTrackerViewModel> ();
		}

		void AddNPC ()
		{
			for (int x = 1; x <= CreateNumber.Value; x++) {

				//Check the settings for which suffix to add
				var multiNpcSuffix = "";
				switch (settings.MultiNpcSuffixOption) {
					case MultiNpcSuffixOptions.Numeric:
						multiNpcSuffix = x.ToString ();
						break;
					case MultiNpcSuffixOptions.Alphabetic:
						//Check to see if we need to go through the list multiple times
						var firstletter = x / letters.Length;
						if (firstletter < 1) {
							multiNpcSuffix = letters[x - 1].ToString ();
						} else {
							var remainder = x % letters.Length;
							//This should get us AA, AB, AC ... 
							multiNpcSuffix = letters[firstletter - 1].ToString () + letters[remainder].ToString ();
						}
						break;
					case MultiNpcSuffixOptions.Custom:
						var list = settings.MultiNpcCustomSuffix.Split (',');
						//For now if they go over the number in the settings then don't add anything
						if (x <= list.Length) {
							multiNpcSuffix = list[x-1];
						}
						break;
				}

				var tempCharacterName = CharacterName.Value;
				if (CreateNumber.Value > 1) {
					tempCharacterName = tempCharacterName + " " + multiNpcSuffix;
				}

				var combatant = new Combatant {
					Name = tempCharacterName,
					IsPlayer = false,
					Initiative = Initiative.Value,
					MaxHealth = Health.Value,
					Health = Health.Value,
					ArmorClass = ArmorClass.Value,
					PassivePerception = PassivePerception.Value
				};

				settings.SQLiteDatabase.Insert (combatant);
			}
		}

		void AddPlayer ()
		{
			var combatant = new Combatant {
				Name = CharacterName.Value,
				IsPlayer = true,
				PlayerName = PlayerName.Value,
				Initiative = Initiative.Value,
				MaxHealth = Health.Value,
				Health = Health.Value,
				ArmorClass = ArmorClass.Value,
				PassivePerception = PassivePerception.Value
			};

			settings.SQLiteDatabase.Insert (combatant);
		}
	}
}
