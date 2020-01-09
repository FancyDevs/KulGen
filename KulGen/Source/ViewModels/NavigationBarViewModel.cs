using System.Windows.Input;
using Kulgen.Source.ViewModels.RandomNames;
using KulGen.Core;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace KulGen.ViewModels
{
	public class NavigationBarViewModel : BaseViewModel
	{
		public ICommand GoToCombat { get { return new MvxCommand (DoGoToCombat); } }
		public ICommand GoToNames { get { return new MvxCommand (DoGoToNames); } }

		public NavigationBarViewModel (ILocalSettings settings, IMvxNavigationService navigation) : base (settings, navigation)
		{
		}

		void DoGoToCombat ()
		{
			navigation.Navigate<CombatTrackerViewModel> ();
		}

		void DoGoToNames ()
		{
			navigation.Navigate<RandomNamesViewModel> ();
		}
	}
}
