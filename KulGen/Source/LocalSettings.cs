using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Akavache.Sqlite3.Internal;
using KulGen.DataModels;
using KulGen.Source.Util;

namespace KulGen.Core
{
	public interface ILocalSettings
	{
		SQLiteConnection SQLiteDatabase { get; set; }
		List<Combatant> CombatantsList { get; set; }
		Combatant CurrentCombatant { get; set; }
		InitiativeOptions InitiativeOption { get; set; }
		MultiNpcSuffixOptions MultiNpcSuffixOption { get; set; }
		string MultiNpcCustomSuffix { get; set; }
	}

	public class LocalSettings : ILocalSettings
	{
		public SQLiteConnection SQLiteDatabase { get; set; }
		public List<Combatant> CombatantsList { get; set; }
		public Combatant CurrentCombatant { get; set; }

		//Persistent Values
		MultiNpcSuffixOptions _savedMuliNpc;
		public MultiNpcSuffixOptions MultiNpcSuffixOption
		{
			get {
				return _savedMuliNpc;
			}
			set {
				if (_savedMuliNpc == value) return;
				_savedMuliNpc = value;
				BlobCache.LocalMachine.InsertObject ("multipleNpcOption", value);
			}
		}

		InitiativeOptions _savedInitiative;
		public InitiativeOptions InitiativeOption
		{
			get {
				return _savedInitiative;
			}
			set {
				if (_savedInitiative == value) return;
				_savedInitiative = value;
				BlobCache.LocalMachine.InsertObject ("savedInitiative", value);
			}
		}

		string _multiNpcCustomSuffix;
		public string MultiNpcCustomSuffix
		{
			get {
				return _multiNpcCustomSuffix;
			}
			set {
				if (_multiNpcCustomSuffix == value) return;
				_multiNpcCustomSuffix = value;
				BlobCache.LocalMachine.InsertObject ("multiNpcCustomSuffix", value);
			}
		}
		//End Persistent Values

		public LocalSettings (string dbPath)
		{
			SetupCache ();
			CreateDatabase (dbPath);
		}

		async Task SetupCache ()
		{
			BlobCache.ApplicationName = "kulgen";
			MultiNpcCustomSuffix = await BlobCache.LocalMachine.GetObject<String> ("multiNpcCustomSuffix");
			InitiativeOption = await BlobCache.LocalMachine.GetObject<InitiativeOptions> ("savedInitiative");
			MultiNpcSuffixOption = await BlobCache.LocalMachine.GetObject<MultiNpcSuffixOptions> ("multipleNpcOption");
		}

		public static async Task<LocalSettings> LoadLocalSettings (string dbPath)
		{
			return new LocalSettings (dbPath);
		}

		void CreateDatabase (string dbPath)
		{
            try{
                SQLiteDatabase = new SQLiteConnection(dbPath);
                SQLiteDatabase.CreateTable<Combatant>();    
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
            }
			
		}
	}
}
