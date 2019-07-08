using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace KulGen.Core.Util
{
	public class ImprovedObservableCollection<T> : ObservableCollection<T>, INotifyCollectionChanged
	{
		public ImprovedObservableCollection (IEnumerable<T> collection) : base (collection)
		{
		}

		public ImprovedObservableCollection ()
		{
		}

		public void ReplaceItems (IEnumerable<T> newItems)
		{
			CheckReentrancy ();
			using (BlockReentrancy ()) {
				Items.Clear ();
				AddRange (newItems);
            }
		}

		public void AddRange (IEnumerable<T> range)
		{
			CheckReentrancy ();
			using (BlockReentrancy ()) {
				foreach (var item in range) {
					Items.Add (item);
				}

				OnCollectionChanged (new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Add, range.ToList()));
			}
		}

		public void RemoveAll (Func<T, bool> filter)
		{
			CheckReentrancy ();
			using (BlockReentrancy ()) {
				var removeElements = this.Where (filter).ToList ();

				foreach (var item in removeElements) {
					Items.Remove (item);
				}

				OnCollectionChanged (new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Remove, removeElements));
			}
		}

		public void RemoveRange (int index, int count)
		{
			CheckReentrancy ();

			var toRemove = this.Skip (index).Take (count).ToList ();

			foreach (var item in toRemove) {
				Items.Remove (item);
			}

			OnCollectionChanged (new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Remove, toRemove, index));
		}
	}
}
