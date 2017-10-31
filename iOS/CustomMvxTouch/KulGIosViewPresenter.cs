using System;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace KulGen.iOS.CustomMvxTouch
{
	public class KulGIosViewPresenter : MvxIosViewPresenter
	{
		public KulGIosViewPresenter(UIApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
		{
		}

        public override MvvmCross.Core.Views.MvxBasePresentationAttribute GetPresentationAttribute(Type viewModelType)
        {
            return base.GetPresentationAttribute(viewModelType);
        }

        protected override MvvmCross.iOS.Views.MvxNavigationController CreateNavigationController(UIViewController viewController)
        {
            return base.CreateNavigationController(viewController);
        }

		public UINavigationController MasterNavigationController {
            get {
                return new UINavigationController();
            } 
        }
        
	}
}
