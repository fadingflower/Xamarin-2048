using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Xamarin2048
{
	public class NumberTileGameViewController:UIViewController
	{

		public NumberTileGameViewController (int d,int t):base(null,null)
		{
			if (d > 2)
				dimension = 2;
			else
				dimension = d;
			if (t > 8)
				threshold = 8;
			else
				threshold = t;
			View.BackgroundColor = UIColor.White;
			setupSwipeControls();

		}


		// How many tiles in both directions the gameboard contains
		int dimension;
		// The value of the winning tile
		int threshold;


		private void setupSwipeControls()
		{
			UISwipeGestureRecognizer upswipe = new UISwipeGestureRecognizer (this, new Selector ("up:"));
			upswipe.NumberOfTouches = 1;
			upswipe.Direction = UISwipeGestureRecognizerDirection.Up;
			View.AddGestureRecognizer (upswipe);

			UISwipeGestureRecognizer downswipe = new UISwipeGestureRecognizer (this, new Selector ("down:"));
			downswipe.NumberOfTouches = 1;
			downswipe.Direction = UISwipeGestureRecognizerDirection.Down;
			View.AddGestureRecognizer (downswipe);


			UISwipeGestureRecognizer leftswipe = new UISwipeGestureRecognizer (this, new Selector ("left:"));
			leftswipe.NumberOfTouches = 1;
			leftswipe.Direction = UISwipeGestureRecognizerDirection.Left;
			View.AddGestureRecognizer (leftswipe);

			UISwipeGestureRecognizer rightswipe = new UISwipeGestureRecognizer (this, new Selector ("right:"));
			rightswipe.NumberOfTouches = 1;
			rightswipe.Direction = UISwipeGestureRecognizerDirection.Left;
			View.AddGestureRecognizer (rightswipe);

		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			setupGame ();
		} 

		private void setupGame()
		{

		}

		private float xPositionToCenterView(UIView v)
		{


			float vcHeight = View.Bounds.Size.Height;
			float vcWidth = View.Bounds.Size.Width;
			float viewWidth= v.Bounds.Size.Width;
			float tentativeX = 0.5 * (vcWidth - viewWidth);
			if (tentativeX >= 0)
				return tentativeX;
			else
				return 0;

		}

	}
}

