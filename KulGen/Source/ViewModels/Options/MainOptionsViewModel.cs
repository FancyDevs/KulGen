using System.Threading.Tasks;
using System.Windows.Input;
using KulGen.Core;
using KulGen.Resources;
using KulGen.Source.Util;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;

namespace KulGen.ViewModels.Options
{
	public class MainOptionsViewModel : BaseViewModel
	{
		public readonly INC<InitiativeOptions> Initiative = new NC<InitiativeOptions> ();
		public readonly INC<MultiNpcSuffixOptions> MultiNpcSuffix = new NC<MultiNpcSuffixOptions> ();
		public readonly INC<bool> IsCustomNpcSuffix = new NC<bool> ();
		public readonly INC<string> MultiNpcCustomSuffix = new NC<string> ();

		public ICommand SaveOptions => new MvxAsyncCommand (DoSaveOptions);

		public string Title => AppStrings.actionbar_options;
		public string InitTitle => AppStrings.init_title;
		public string InitDesc => AppStrings.init_desc;
		public string InitAsc => AppStrings.init_asc;
		public string InitCheckBox => AppStrings.init_checkbox;
		public string MultiNpcTitle => AppStrings.multi_npc_title;
		public string MultiNpcNum => AppStrings.multi_npc_num;
		public string MultiNpcAlpha => AppStrings.multi_npc_alpha;
		public string MultiNpcCustom => AppStrings.multi_npc_custom;
		public string MultiNpcCustomHint => AppStrings.multi_npc_custom_hint;

		public MainOptionsViewModel (ILocalSettings settings, IMvxNavigationService navigation) : base (settings, navigation)
		{
			Initiative.Value = settings.InitiativeOption;
			MultiNpcSuffix.Value = settings.MultiNpcSuffixOption;
			IsCustomNpcSuffix.Value = MultiNpcSuffix.Value == MultiNpcSuffixOptions.Custom;
			MultiNpcCustomSuffix.Value = settings.MultiNpcCustomSuffix;
		}

		async Task DoSaveOptions ()
		{
			settings.InitiativeOption = Initiative.Value;
			settings.MultiNpcSuffixOption = MultiNpcSuffix.Value;
			settings.MultiNpcCustomSuffix = MultiNpcCustomSuffix.Value;
			await navigation.Close (this);
		}
	}
}
