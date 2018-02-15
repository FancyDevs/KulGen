using SQLite;

namespace KulGen.DataModels
{
	public class MagicItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public bool Attune { get; set; }
		public int Type { get; set; }
		public int Rarity { get; set; }

		public MagicItem ()
		{
			Name = "";
			Type = 0;
			Rarity = 0;
			Description = "";
			Location = "";
		}
	}
}