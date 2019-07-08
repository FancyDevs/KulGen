using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using KulGen.Core;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;

namespace KulGen.Droid
{
	public class Setup : MvxAppCompatSetup<App>
	{
		protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly> (base.AndroidViewAssemblies)
		{
			typeof(NavigationView).Assembly,
			typeof(CoordinatorLayout).Assembly,
			typeof(FloatingActionButton).Assembly,
			typeof(Toolbar).Assembly,
			typeof(DrawerLayout).Assembly,
			typeof(ViewPager).Assembly,
			typeof(MvxRecyclerView).Assembly,
			typeof(MvxSwipeRefreshLayout).Assembly,
		};

		Context AppContext;

		public static INC<bool> SetupComplete { get; } = new NC<bool> ();

		protected override async void InitializeIoC()
		{
			base.InitializeIoC ();

			CurrentPlatform.Init ();

			string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"appofmanythings.db3");

			await CommonSetup.SharedSetup (dbPath);

			SetupComplete.Value = true;
		}

		protected override IMvxApplication CreateApp ()
		{
			return new App ();
		}

		protected override IMvxAndroidViewPresenter CreateViewPresenter ()
		{
			return new MvxAppCompatViewPresenter (AndroidViewAssemblies);
		}
	}
}
