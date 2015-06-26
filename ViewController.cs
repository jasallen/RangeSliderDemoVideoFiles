using System;

using UIKit;

namespace sliderDemo
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{

			int margin = 20;
			View.AddSubview (new RangeSliderView (new CoreGraphics.CGRect (margin, margin, View.Frame.Width - margin * 2, 50)));
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

