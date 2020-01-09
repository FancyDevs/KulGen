using System.Collections.Generic;

namespace KulGen.DataModels
{
	public class NameTypeList
	{
		public List<NameType> NameTypes { get; set; }
	}

	public class NameType
	{
		public string Type { get; set; }
		public string Gender { get; set; }
		public string FirstOrLast { get; set; }
		public List<NameValue> Names { get; set; }
	}

	public class NameValue
	{
		public string Name { get; set; }
	}
}
