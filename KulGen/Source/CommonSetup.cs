﻿using System.Threading.Tasks;
using MvvmCross.Platform;

namespace KulGen.Core
{
	public static class CommonSetup
	{
		public static async Task SharedSetup(string dbPath)
		{
            var settings = await LocalSettings.LoadLocalSettings (dbPath);
            Mvx.RegisterSingleton<ILocalSettings> (settings);
		}
	}
}