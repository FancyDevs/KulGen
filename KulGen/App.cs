using KulGen.ViewModels.CombatTracker;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace KulGen
{
	public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

			RegisterAppStart<CombatTrackerViewModel>();
        }
    }
}
