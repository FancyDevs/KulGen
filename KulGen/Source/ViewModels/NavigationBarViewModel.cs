using System.Windows.Input;
using KulGen.Core;
using KulGen.ViewModels.CombatTracker;
using KulGen.ViewModels.Options;
using MvvmCross.Core.ViewModels;

namespace KulGen.ViewModels
{
	public class NavigationBarViewModel : BaseViewModel
	{
		public ICommand GoToCombat { get { return new MvxCommand (DoGoToCombat); } }
		public ICommand GoToRandom { get { return new MvxCommand (DoGoToRandom); } }

		public NavigationBarViewModel (ILocalSettings settings) : base (settings)
		{
		}

		void DoGoToCombat ()
		{
			ShowViewModel<CombatTrackerViewModel> ();
		}

		void DoGoToRandom ()
		{
			ShowViewModel<RandomMagicItemViewModel> ();
		}
	}
}
