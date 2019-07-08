using System;
using KulGen.Core;
using KulGen.Resources;
using KulGen.ViewModels;
using MvvmCross.Navigation;

namespace KulGen.ViewModels.Help
{
	public class MainHelpViewModel : BaseViewModel
	{
		public string Title => AppStrings.help_title;
		public string InitTitle => AppStrings.help_init_title;
		public string InitStandard => AppStrings.help_init_standard;
		public string InitStandardDesc => AppStrings.help_init_standard_desc;
		public string InitGreyHawk => AppStrings.help_init_greyhawk;
		public string InitGreyHawkDesc => AppStrings.help_init_greyhawk_desc;
		public string InitNarrative => AppStrings.help_init_narrative;
		public string InitNarrativeDesc => AppStrings.help_init_narrative_desc;
		public string MultiTitle = AppStrings.help_multi_title;
		public string MultiDesc = AppStrings.help_multi_desc;
		public string HelpLink = AppStrings.help_click_here;
		public string GreyHawkLink = AppStrings.help_greyhawk_link;
		public string NarrativeLink = AppStrings.help_narrative_link;
		                                     
		public MainHelpViewModel (ILocalSettings settings, IMvxNavigationService navigation) : base (settings, navigation)
		{
		}
	}
}
