using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using KulGen.Adapters.CombatTracker;
using KulGen.Droid.MvxBindings;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;

namespace KulGen.Droid.Adapters.CombatTracker
{
	public class CombatantAdapter : MvxListViewAdapter<CombatListItemModel>
	{
		readonly Context context;
		public override int ItemTemplateId => Resource.Layout.combat_item;

		public CombatantAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public CombatantAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext, Resource.Layout.combat_item)
		{
			this.context = context;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = base.GetView(position, convertView, parent);

			if (position % 2 == 1) {
				view.SetBackgroundColor(new Color(ContextCompat.GetColor(context, Resource.Color.secondary_color)));
			} else {
				view.SetBackgroundColor(Color.White);
			}

			return view;
		}


		protected override IMvxListItemView CreateViewBasedOnInfo(CombatListItemModel dataContext, int templateId)
		{
			var item = new CombatListItem(Context);
			item.DataContext = dataContext;
			return item;
		}
	}
}
