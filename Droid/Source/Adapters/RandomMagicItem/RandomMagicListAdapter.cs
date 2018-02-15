using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using KulGen.Adapters.RandomMagicItem;
using KulGen.Droid.Adapters.RandomMagicItem;
using KulGen.Droid.MvxBindings;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace KulGen.Droid.Adapters.RandomMagicItem
{
	public class RandomMagicListAdapter : MvxListViewAdapter<RandomMagicListItemModel>
	{
		readonly Context context;
		public override int ItemTemplateId => Resource.Layout.random_magic_item;

		public RandomMagicListAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public RandomMagicListAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext, Resource.Layout.random_magic_item)
		{
			this.context = context;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view;

			if (convertView == null){
				view = LayoutInflater.FromContext(context).Inflate(ItemTemplateId, null);
			} else {
				view = base.GetView(position, convertView, parent);
			}

			if (position % 2 == 1) {
				view.SetBackgroundColor(new Color(ContextCompat.GetColor(context, Resource.Color.secondary_color)));
			} else {
				view.SetBackgroundColor(Color.White);
			}

			return view;
		}


		protected override IMvxListItemView CreateViewBasedOnInfo(RandomMagicListItemModel dataContext, int templateId)
		{
			var item = new RandomMagicListItem(Context);
			item.DataContext = dataContext;
			return item;
		}
	}
}
