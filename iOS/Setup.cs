using System;
using System.IO;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace KulGen.iOS
{
	public class Setup : MvxIosSetup
	{
		public static INC<bool> SetupComplete { get; } = new NC<bool> ();

		public Setup (MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base (applicationDelegate, window)
		{
		}

		public Setup (MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
			: base (applicationDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new App ();
		}

		protected override async void InitializeIoC ()
		{
			base.InitializeIoC ();
			CurrentPlatform.Init ();

			string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "appofmanythings.db3");

			await Core.Setup.SharedSetup (dbPath);

			SetupComplete.Value = true;
		}
	}
}
