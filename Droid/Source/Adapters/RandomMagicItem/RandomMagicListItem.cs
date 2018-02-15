using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KulGen.Adapters.RandomMagicItem;
using KulGen.Droid.MvxBindings;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Adapters.RandomMagicItem
{
	public class RandomMagicListItem : LinearLayout, IMvxListItem
	{
		public IMvxBindingContext BindingContext { get; set; }

		public int TemplateId => Resource.Layout.random_magic_item;

		public View Content { get; set; }

		public object DataContext
		{
			get {
				return BindingContext.DataContext;
			}
			set {
				if (BindingContext.DataContext == value) {
					return;
				}
				BindingContext.DataContext = value;
			}
		}

		TextView TextName;
		TextView TextDescription;
		TextView TextRarity;
		TextView TextType;
		CheckBox checkBoxAttune;
		LinearLayout LayoutDescriptionBox;

		public RandomMagicListItem (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
			Init ();
		}

		public RandomMagicListItem (Context context) : base (context)
		{
			Init (context);
		}

		void Init (Context context = null)
		{
			Clickable = true;
			Content = LayoutInflater.From (context).Inflate (TemplateId, this, true);

			TextName = FindViewById<TextView> (Resource.Id.text_item_name);
			TextDescription = FindViewById<TextView> (Resource.Id.text_item_description);
			TextRarity = FindViewById<TextView> (Resource.Id.text_rarity);
			TextType = FindViewById<TextView> (Resource.Id.text_item_type);
			LayoutDescriptionBox = FindViewById<LinearLayout> (Resource.Id.layout_expand_description);
			checkBoxAttune = FindViewById<CheckBox> (Resource.Id.checkbox_attune);

			this.CreateBindingContext ();
			BindingContext.DelayBind (() => {
				var set = this.CreateBindingSet<RandomMagicListItem, RandomMagicListItemModel> ();
				set.Bind (TextName).For (x => x.Text).To (vm => vm.ItemName);
				set.Bind (TextDescription).For (x => x.Text).To (vm => vm.Description);
				set.Bind (TextRarity).For (x => x.Text).To (vm => vm.Rarity).OneWay ().WithConversion ("IntToRarityValueConverter");
				set.Bind (TextType).For (x => x.Text).To (vm => vm.Type).OneWay ().WithConversion ("IntToItemTypeValueConverter");
				set.Bind (checkBoxAttune).For (x => x.Checked).To (vm => vm.Attune);

				set.Bind (LayoutDescriptionBox).For ("Visibility").To (vm => vm.ShowDescriptionWindow).WithConversion ("Visibility");

				set.Bind (this).For (this.ClickEvent ()).To (vm => vm.ShowDescription);
				set.Apply ();
			});
		}

		protected override void Dispose (bool disposing)
		{
			BindingContext?.ClearAllBindings ();
			base.Dispose (disposing);
		}
	}
}
