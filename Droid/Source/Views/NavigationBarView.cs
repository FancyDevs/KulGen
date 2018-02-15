using Android.Views;
using Android.Widget;
using KulGen.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Views
{
	public abstract class NavigationBarView<TView, TViewModel> : BaseView<TView, TViewModel>
        where TView : class, IMvxBindingContextOwner
        where TViewModel : NavigationBarViewModel
	{
		ImageButton combatTrackerButton;
		ImageButton randomGenButton;

        protected override void OnInitializeComponents()
		{
			combatTrackerButton = FindViewById<ImageButton> (Resource.Id.button_toolbar_combat);
			randomGenButton = FindViewById<ImageButton> (Resource.Id.button_toolbar_random);
			randomGenButton.Visibility = ViewStates.Gone;
      	}

        protected override void SetupBindings(MvxFluentBindingDescriptionSet<TView, TViewModel> bindingSet)
		{
			bindingSet.Bind (combatTrackerButton).For (combatTrackerButton.ClickEvent ()).To (vm => vm.GoToCombat);
			bindingSet.Bind (randomGenButton).For (randomGenButton.ClickEvent ()).To (vm => vm.GoToRandom);
        }
    }
}
