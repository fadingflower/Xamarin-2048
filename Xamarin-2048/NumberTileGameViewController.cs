using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Xamarin2048
{
	public class NumberTileGameViewController:UIViewController
	{

		float viewPadding=10.0;
		float verticalViewOffset=0.0;
		float thinPadding = 3.0;
		float thickPadding = 6.0;
		float boardWidth = 230.0;

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


		private float vcHeight;
		private float vcWidth;
		private void setupGame()
		{
			vcHeight = View.Bounds.Size.Height;
			vcWidth = View.Bounds.Size.Width;
			ScoreView scoreview = new ScoreView (UIColor.Black, UIColor.White, UIFont.FromName ("HelveticaNeue-Bold", 16.0), 6);
			scoreview.Score = 0;
			float padding;
			if (dimension > 5)
				padding = thinPadding;
			else
				padding = thickPadding;
			float v1 = boardWidth - padding * (dimension + 1);
			float width = v1 / dimension;


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

		private float[] GetBoudHeight(UIView[] views)
		{
			float[] heights=new float[views.Length];
			for (int i = 0; i < views.Length; i++) {
				heights [i] = views [i].Bounds.Size.Height;
			}
			return heights;
		}

		private float GetTotalHeight(float[] Heights)
		{
			float sum=verticalViewOffset;
			foreach (float f in Heights) {
				sum += f;
			}
			return sum;
		}

		private float yPositionForViewAtPosition(int order,UIView[] views)
		{
			if (views.Length > 0) 
			{
				if (order > 0 && order < views.Length) {
					float viewHeight = views [order].Bounds.Size.Height;
					float totalHeight = (views.Length - 1) * viewPadding + GetTotalHeight(GetBoudHeight (views));
					float viewsTop = 0.0;
					if ((vcHeight - vcWidth) >= 0.0) {
						viewsTop = 0.5 * (vcHeight - vcWidth);
					}
					float acc = 0.0;
					for(int i=0;i<order;i++)
					{
						acc += viewPadding + views [i].Bounds.Size.Height;
					}
					return viewsTop + acc;
				} else {
					throw new Exception ();
				}
			} else 
			{
				throw new Exception ();
			}
		}

	}
}

