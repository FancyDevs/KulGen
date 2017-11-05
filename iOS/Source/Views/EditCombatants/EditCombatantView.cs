using System;
using KulGen.ViewModels.EditCombatants;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace KulGen.iOS.Source.Views.EditCombatants
{
	public partial class EditCombatantView : BaseViewController<EditCombatantView, EditCombatantViewModel>
	{
		public EditCombatantView () : base ("EditCombatantView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SetupNavBar (ViewModel.Title);

			UIBarButtonItem updateItem = new UIBarButtonItem ("UPDATE",
														  UIBarButtonItemStyle.Done,
														  (sender, e) => {
															  ViewModel.UpdateClicked.Execute (null);
														  });
			updateItem.SetTitleTextAttributes (GetNavButtonAttributes (), UIControlState.Normal);

			UIBarButtonItem killItem = new UIBarButtonItem ("KILL",
														  UIBarButtonItemStyle.Done,
														  (sender, e) => {
															  ViewModel.DeleteClicked.Execute (null);
														  });
			killItem.SetTitleTextAttributes (GetNavButtonAttributes (), UIControlState.Normal);

			NavigationItem.RightBarButtonItems = new UIBarButtonItem[] { updateItem, killItem };
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<EditCombatantView, EditCombatantViewModel> bindingSet)
		{
			bindingSet.Bind (txtCombatant).For (x => x.Text).To (vm => vm.CharacterName);
			bindingSet.Bind (txtPlayerName).For (x => x.Text).To (vm => vm.PlayerName);
			bindingSet.Bind (viewPlayer).For ("Hidden").To (vm => vm.IsPlayer).WithConversion ("Visibility");
			bindingSet.Bind (txtInitiative).For (x => x.Text).To (vm => vm.Initiative).WithConversion ("StringToIntConverter");
			bindingSet.Bind (txtMaxHealth).For (x => x.Text).To (vm => vm.MaxHealth).WithConversion ("StringToIntConverter");
			bindingSet.Bind (txtPerception).For (x => x.Text).To (vm => vm.PassivePerception).WithConversion ("StringToIntConverter");
			bindingSet.Bind (txtArmor).For (x => x.Text).To (vm => vm.ArmorClass).WithConversion ("StringToIntConverter");
		}
	}
}

