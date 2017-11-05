using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace KulGen.iOS.Controls
{
	[Register ("Checkbox")]
	public class Checkbox : UIButton
	{
		const UIControlState CheckedState = (UIControlState)(1 << 16);
		UIControlState customState;

		bool _isChecked;
		public bool IsChecked { 
			get { return _isChecked; }
			set {
				_isChecked = value;
				if (_isChecked) {
					customState |= CheckedState;
				} else {
					customState &= ~CheckedState;
				}
				SetNeedsLayout ();
				IsCheckedChanged?.Invoke (this, EventArgs.Empty);
			}
		}

		public override UIControlState State => base.State | customState;

		public event EventHandler IsCheckedChanged;

		[Export ("init")]
		public Checkbox ()
		{
		}

		[Export ("initWithCoder:")]
		public Checkbox (NSCoder coder)
			: base (coder)
		{
		}

		[Export ("initWithFrame:")]
		public Checkbox (CGRect frame)
			: base (frame)
		{
		}

		public Checkbox (NSObjectFlag flags)
			: base (flags)
		{
		}

		public Checkbox (IntPtr handle)
			: base (handle)
		{
		}

		public void Initialize (UIImage checkImg, UIImage unCheckImg, bool initialState)
		{
			SetImage (checkImg, CheckedState);
			SetImage (checkImg, UIControlState.Highlighted);
			SetImage (unCheckImg, UIControlState.Normal);
			AddTarget (ToggleCheckState, UIControlEvent.TouchUpInside);
			IsChecked = initialState;
		}

		protected override void Dispose (bool disposing)
		{
			RemoveTarget (ToggleCheckState, UIControlEvent.TouchUpInside);
			base.Dispose (disposing);
		}

		void ToggleCheckState (object sender, EventArgs e)
		{
			IsChecked = !IsChecked;
		}
	}
}
