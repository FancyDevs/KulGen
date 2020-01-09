using Android.Widget;
using KulGen.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Views
{
	public abstract class NavigationBarView<TView, TViewModel> : BaseView<TView, TViewModel>
		where TView : class, IMvxBindingContextOwner
		where TViewModel : NavigationBarViewModel
	{
		ImageButton buttonCombat;
		ImageButton buttonNames;

		protected override void OnInitializeComponents ()
		{
			buttonCombat = FindViewById<ImageButton> (Resource.Id.button_navbar_combat);
			buttonNames = FindViewById<ImageButton> (Resource.Id.button_navbar_names);
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<TView, TViewModel> bindingSet)
		{
			bindingSet.Bind (buttonCombat).For (buttonCombat.ClickEvent ()).To (vm => vm.GoToCombat);
			bindingSet.Bind (buttonNames).For (buttonNames.ClickEvent ()).To (vm => vm.GoToNames);
		}
	}
}
