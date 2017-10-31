using System;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace KulGen
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        public AppStart(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public void Start(object hint = null)
        {
            _mvxNavigationService.Navigate<CombatTrackerViewModel>();
        }
    }
}
