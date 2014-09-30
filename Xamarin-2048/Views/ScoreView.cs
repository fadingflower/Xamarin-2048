using System;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;

namespace Xamarin2048
{
	public class ScoreView:UIView;
	{
		RectangleF defaultFrame = new RectangleF (0, 0, 140, 40);
		UILabel label;
		public ScoreView (UIColor bgcolor, UIColor tcolor, UIFont font, float r):base()
		{
			MonoTouch.CoreGraphics.
			label = new UILabel (defaultFrame);
			label.TextAlignment = UITextAlignment.Center;
			BackgroundColor = bgcolor;
			label.TextColor = tcolor;
			label.Font = font;
			Layer.CornerRadius = r;
			this.AddSubview (label);
		
		}

		private int p_score = 0;
		public int Score {
			get {
				return p_score;

			}

			set {
				p_score = value;
				label.Text = String.Format ("Score: {0}", value);
			}
		}
	}
}

