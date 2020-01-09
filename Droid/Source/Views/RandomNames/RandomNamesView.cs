using Android.App;
using Android.Content.PM;
using Kulgen.Source.ViewModels.RandomNames;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;

namespace KulGen.Droid.Views.RandomNames
{
	[Activity (
		   Label = "Random Names",
		   LaunchMode = LaunchMode.SingleTask,
		   Theme = "@style/Theme.Main",
		   ScreenOrientation = ScreenOrientation.Portrait
    )]
	public class RandomNamesView : BaseView<RandomNamesView, RandomNamesViewModel>
	{
		protected override int LayoutResId => Resource.Layout.random_names_layout;

		MvxSpinner spinnerFirstNames;

		protected override void OnInitializeComponents ()
		{
			spinnerFirstNames = FindViewById<MvxSpinner> (Resource.Id.spinner_first_names);
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<RandomNamesView, RandomNamesViewModel> bindingSet)
		{
			bindingSet.Bind (spinnerFirstNames).For (v => v.ItemsSource).To (vm => vm.FirstNameTypes);
			bindingSet.Bind (spinnerFirstNames).For (v => v.HandleItemSelected).To (vm => vm.FirstNameSelected);
		}
	}
}
