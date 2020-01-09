using System;
using System.IO;
using System.Reflection;

namespace Kulgen.Source.Util
{
	public static class EmbeddedAssetUtil
	{
		public static string ReadEmbeddedResourceText (Type classType, string resourceName)
		{
			try {
				var assembly = classType.GetTypeInfo ().Assembly;
				string result = null;

				using (var stream = assembly.GetManifestResourceStream (resourceName))
				using (var reader = new StreamReader (stream)) {
					result = reader.ReadToEnd ();
					return result;
				}
			} catch (Exception e) {
				return "";
			}
		}
	}
}
