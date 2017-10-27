using System;
using KulGen.iOS.Source.Adapters;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Binding.BindingContext;
using Shire.iOS.Views;
using UIKit;

namespace KulGen.iOS.Source.Views.CombatTracker
{
	public partial class CombatTrackerView : BaseViewController<CombatTrackerView, CombatTrackerViewModel>
	{
		TypedCellMvxSimpleTableViewSource<CombatTrackerCell> tableSource;

		protected override void OnInitializeComponents ()
		{
			base.OnInitializeComponents ();
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<CombatTrackerView, CombatTrackerViewModel> bindingSet)
		{
			
		}
	}
}

