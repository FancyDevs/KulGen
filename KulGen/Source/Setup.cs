﻿using System.Threading.Tasks;
using MvvmCross.Platform;

namespace KulGen.Core
{
	public static class Setup
	{
		public static async Task SharedSetup(string dbPath)
		{
            try{
                var settings = await LocalSettings.LoadLocalSettings (dbPath);
                Mvx.RegisterSingleton<ILocalSettings> (settings);
            }
            catch (System.Exception ex)
            {
            }
		}
	}
}
