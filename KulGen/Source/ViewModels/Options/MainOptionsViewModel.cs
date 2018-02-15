using System.Windows.Input;
using KulGen.Core;
using KulGen.Resources;
using KulGen.Source.Util;
using KulGen.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.ViewModels.Options
{
	public class MainOptionsViewModel : NavigationBarViewModel
	{
		public readonly INC<InitiativeOptions> Initiative = new NC<InitiativeOptions> ();
		public readonly INC<MultiNpcSuffixOptions> MultiNpcSuffix = new NC<MultiNpcSuffixOptions> ();
		public readonly INC<bool> IsCustomNpcSuffix = new NC<bool> ();
		public readonly INC<string> MultiNpcCustomSuffix = new NC<string> ();

		public ICommand SaveOptions => new MvxCommand (DoSaveOptions);

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

		public MainOptionsViewModel (ILocalSettings settings) : base (settings)
		{
			Initiative.Value = settings.GetSavedInitiate ();
			MultiNpcSuffix.Value = settings.GetMultipleNpcOption ();
			IsCustomNpcSuffix.Value = MultiNpcSuffix.Value == MultiNpcSuffixOptions.Custom;
			MultiNpcCustomSuffix.Value = settings.MultiNpcCustomSuffix;
		}

		void DoSaveOptions ()
		{
			settings.SetSavedInitiate (Initiative.Value);
			settings.SetMultipleNpcOption (MultiNpcSuffix.Value);
			settings.SetMultiNpcCustomSuffix (MultiNpcCustomSuffix.Value);
			Close (this);
		}
	}
}
