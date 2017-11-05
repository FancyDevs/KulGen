﻿using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace KulGen.iOS.Source.Views
{
	public class BaseViewController : MvxViewController
	{
        public BaseViewController() {
            
        }

        public BaseViewController(string nibName, NSBundle bundle) : base (nibName, bundle) {

        }

        public BaseViewController(IntPtr handle) : base(handle) {

        }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetupView ();
		}

		protected virtual void SetupView () { }
	}

	public abstract class BaseViewController<TViewModel> : BaseViewController where TViewModel : class, IMvxViewModel
	{
        public BaseViewController()
        {

        }

        public BaseViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
        {

        }

		public new TViewModel ViewModel
		{
			get => (TViewModel)base.ViewModel;
			set { base.ViewModel = value; }
		}
	}

	public abstract class BaseViewController<TView, TViewModel> : BaseViewController<TViewModel>
		where TViewModel : class, IMvxViewModel
		where TView : class, IMvxBindingContextOwner
	{
		public BaseViewController ()
		{

		}

		public BaseViewController (string nibName, NSBundle bundle) : base (nibName, bundle)
		{

		}

		protected override void SetupView ()
		{
			base.SetupView ();

			OnInitializeComponents ();

			var bindingSet = (this as TView).CreateBindingSet<TView, TViewModel> ();
			SetupBindings (bindingSet);
			bindingSet.Apply ();
		}

		void SetupNavBar (string title)
		{
			NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB (36,38,37);
			NavigationController.NavigationBar.TintColor = UIColor.White;
			NavigationItem.Title = title;
		}

		// Used to initialize UI 
		protected virtual void OnInitializeComponents () { }

		//Set up the Mvvm Bindings
		protected abstract void SetupBindings (MvxFluentBindingDescriptionSet<TView, TViewModel> bindingSet);
	}
}
