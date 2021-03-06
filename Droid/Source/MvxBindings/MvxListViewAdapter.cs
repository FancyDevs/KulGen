﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;

namespace KulGen.Droid.MvxBindings
{
	public abstract class MvxListViewAdapter<T> : MvxAdapter where T : class
	{
		protected List<T> lookup = new List<T> ();

		public int templateId;

		public MvxListViewAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		public MvxListViewAdapter (Context context, IMvxAndroidBindingContext bindingContext, int templateId = int.MinValue) : base (context, bindingContext)
		{
			this.templateId = templateId;
		}


		protected abstract IMvxListItemView CreateViewBasedOnInfo (T dataContext, int templateId);

		protected virtual int GetTemplateIdForPosition (int position)
		{
			var toReturn = templateId;
			if (toReturn == int.MinValue) {
				throw new MissingFieldException ("Please pass in `templateId` or override `GetTemplateIdForPosition`!!");
			}

			return toReturn;
		}

		protected virtual List<T> FlattenList (IEnumerable itemsSource)
		{
			try {
				return itemsSource?.Cast<T> ().ToList (); //TODO: Double check if this is the right method to use here!!
			} catch (Exception e) {
				int a = 0;
				return null;
			}

		}

		public override IEnumerable ItemsSource
		{
			get {
				return base.ItemsSource;
			}
			set {
				var oldObservable = base.ItemsSource as ObservableCollection<T>;
				if (oldObservable != null) {
					oldObservable.CollectionChanged -= Observable_CollectionChanged;
				}

				var observable = value as ObservableCollection<T>;
				if (observable != null) {
					observable.CollectionChanged += Observable_CollectionChanged;
				}

				SetFlattenedList (value);
			}
		}

		void Observable_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			var value = sender as ObservableCollection<T>;
			SetFlattenedList (value);
		}

		void SetFlattenedList (IEnumerable value)
		{
			var flattenedList = FlattenList (value);
			base.ItemsSource = flattenedList;
			lookup = flattenedList;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			return GetView (position, convertView, parent, GetTemplateIdForPosition (position));
		}

		protected override IMvxListItemView CreateBindableView (object dataContext, ViewGroup parent, int templateId)
		{
			var obj = dataContext as T;
			if (obj == null) {
				throw new ArgumentException ($"Invalid dataContext type! Expected: {typeof (T)}, Actual: {dataContext?.GetType ()}!");
			}

			return CreateViewBasedOnInfo (obj, templateId);
		}
	}
}
