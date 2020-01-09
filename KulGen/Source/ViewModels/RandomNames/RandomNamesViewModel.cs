using System.Windows.Input;
using KulGen.Core;
using KulGen.Core.Util;
using KulGen.DataModels;
using KulGen.ViewModels;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Kulgen.Source.ViewModels.RandomNames
{
	public class RandomNamesViewModel : BaseViewModel
	{
		public ImprovedObservableCollection<string> FirstNameTypes { get; } = new ImprovedObservableCollection<string> ();
		public ImprovedObservableCollection<string> LastNameTypes { get; } = new ImprovedObservableCollection<string> ();

		public ICommand FirstNameSelected { get { return new MvxCommand (DoFirstNameSelected); } }

		public RandomNamesViewModel (ILocalSettings settings, IMvxNavigationService navigation) : base (settings, navigation)
		{
			foreach(var name in settings.NameTypes) {

				var nameType = name.Type;

				if (name.FirstOrLast == "first" && !FirstNameTypes.Contains(nameType)) {
					FirstNameTypes.Add (name.Type);

				} else if(name.FirstOrLast == "last" && !LastNameTypes.Contains (nameType)) {
					LastNameTypes.Add (name.Type);
				}
			}
		}

		void DoFirstNameSelected()
		{

		}
	}
}
