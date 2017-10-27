using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;

namespace KulGen.iOS.Source.Views
{
	public class BaseViewController : MvxViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetupView ();
		}

		protected virtual void SetupView () { }
	}

	public abstract class BaseViewController<TViewModel> : BaseViewController where TViewModel : class, IMvxViewModel
	{
		public new TViewModel ViewModel
		{
			get => (TViewModel)base.ViewModel;
			set { base.ViewModel = value; }
		}
	}

	public abstract class BaseViewController<TView, TViewModel> : BaseViewController 
		where TViewModel : class, IMvxViewModel
		where TView : class, IMvxBindingContextOwner
	{
		protected override void SetupView ()
		{
			base.SetupView ();

			OnInitializeComponents ();

			var bindingSet = (this as TView).CreateBindingSet<TView, TViewModel> ();
			SetupBindings (bindingSet);
			bindingSet.Apply ();
		}

		// Used to initialize UI 
		protected virtual void OnInitializeComponents () { }

		//Set up the Mvvm Bindings
		protected abstract void SetupBindings (MvxFluentBindingDescriptionSet<TView, TViewModel> bindingSet);
	}
}
