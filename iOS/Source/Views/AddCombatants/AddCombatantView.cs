using System;
using KulGen.ViewModels.AddCombatants;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace KulGen.iOS.Source.Views.AddCombatants
{
    public partial class AddCombatantView : BaseViewController<AddCombatantView, AddCombatantViewModel>
	{
		public AddCombatantView () : base ("AddCombatantView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            UIBarButtonItem addItem = new UIBarButtonItem("Add", 
                                                          UIBarButtonItemStyle.Done,
                                                          (sender, e) => {
                ViewModel.AddClicked.Execute(null);
            });

            NavigationItem.RightBarButtonItem = addItem;

            smgType.ValueChanged += (sender, e) => {
                if (smgType.SelectedSegment == 0)
                    ViewModel.IsPlayer.Value = true;
                else
                    ViewModel.IsPlayer.Value = false;
            };

            smgType.SelectedSegment = 1;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        protected override void SetupBindings(MvxFluentBindingDescriptionSet<AddCombatantView, AddCombatantViewModel> bindingSet)
        {
            bindingSet.Bind(txtCombatant).For(x => x.Text).To(vm => vm.CharacterName);
            bindingSet.Bind(txtPlayerName).For(x => x.Text).To(vm => vm.PlayerName);
            bindingSet.Bind(viewPlayer).For("Hidden").To(vm => vm.IsPlayer).WithConversion("Visibility");
            bindingSet.Bind(txtInitiative).For(x => x.Text).To(vm => vm.Initiative).WithConversion("StringToIntConverter");
            bindingSet.Bind(txtHealth).For(x => x.Text).To(vm => vm.Health).WithConversion("StringToIntConverter");
            bindingSet.Bind(txtPassiverPerception).For(x => x.Text).To(vm => vm.PassivePerception).WithConversion("StringToIntConverter");
            bindingSet.Bind(txtAmorClass).For(x => x.Text).To(vm => vm.ArmorClass).WithConversion("StringToIntConverter");
            bindingSet.Bind(txtCreateNumber).For(x => x.Text).To(vm => vm.CreateNumber).WithConversion("StringToIntConverter");
        }
    }
}

