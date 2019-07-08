using KulGen.Core;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;

namespace KulGen.ViewModels
{
	public abstract class BaseViewModel : MvxViewModel
	{
		public readonly INC<bool> Loading = new NC<bool>();
		public readonly INC<string> ErrorMessage = new NC<string>();

		public readonly ILocalSettings settings;
		public readonly IMvxNavigationService navigation;

		public BaseViewModel (ILocalSettings settings, IMvxNavigationService navigation)
		{
			this.settings = settings;
			this.navigation = navigation;
		}
	}
}
