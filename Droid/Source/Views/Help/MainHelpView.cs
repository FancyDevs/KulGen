using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using KulGen.Droid.Views;
using KulGen.Source.ViewModels.Help;
using MvvmCross.Binding.BindingContext;
using Uri = Android.Net.Uri;

namespace KulGen.Droid.Source.Views.Help
{
	[Activity (
		Label = "Help",
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class MainHelpView : NavigationBarView<MainHelpView, MainHelpViewModel>
	{
		protected override int LayoutResId => Resource.Layout.main_help_layout;

		TextView textGreyHawkLink;
		TextView textNarritiveLink;

		protected override void OnInitializeComponents ()
		{
			base.OnInitializeComponents ();

			textGreyHawkLink = FindViewById<TextView> (Resource.Id.text_help_greyhawk_link);
			textNarritiveLink = FindViewById<TextView> (Resource.Id.text_help_narrative_link);

			FindViewById<TextView> (Resource.Id.help_init_title).Text = ViewModel.InitTitle;
			FindViewById<TextView> (Resource.Id.help_init_standard).Text = ViewModel.InitStandard;
			FindViewById<TextView> (Resource.Id.help_init_standard_desc).Text = ViewModel.InitStandardDesc;
			FindViewById<TextView> (Resource.Id.help_init_greyhawk).Text = ViewModel.InitGreyHawk;
			FindViewById<TextView> (Resource.Id.help_init_greyhawk_desc).Text = ViewModel.InitGreyHawkDesc;
			FindViewById<TextView> (Resource.Id.help_init_narrative).Text = ViewModel.InitNarrative;
			FindViewById<TextView> (Resource.Id.help_init_narrative_desc).Text = ViewModel.InitNarrativeDesc;
			FindViewById<TextView> (Resource.Id.help_multi_title).Text = ViewModel.MultiTitle;
			FindViewById<TextView> (Resource.Id.help_multi_desc).Text = ViewModel.MultiDesc;
			textGreyHawkLink.Text = ViewModel.HelpLink;
			textNarritiveLink.Text = ViewModel.HelpLink;

			SetupActionBar ("Help");
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<MainHelpView, MainHelpViewModel> bindingSet)
		{
			base.SetupBindings (bindingSet);
		}

		protected override void OnResume ()
		{
			textGreyHawkLink.Click += GreyHawkLinkClicked;
			textNarritiveLink.Click += NarrativeLinkClicked;
			base.OnResume ();
		}

		protected override void OnPause ()
		{
			textGreyHawkLink.Click -= GreyHawkLinkClicked;
			textNarritiveLink.Click -= NarrativeLinkClicked;
			base.OnPause ();
		}

		void GreyHawkLinkClicked (Object sender, EventArgs e)
		{
			var uri = Uri.Parse (ViewModel.GreyHawkLink);
			var intent = new Intent (Intent.ActionView, uri);
			StartActivity (intent);
		}

		void NarrativeLinkClicked (Object sender, EventArgs e)
		{
			var uri = Uri.Parse (ViewModel.NarrativeLink);
			var intent = new Intent (Intent.ActionView, uri);
			StartActivity (intent);
		}
	}
}
