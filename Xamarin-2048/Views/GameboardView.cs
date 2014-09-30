using System;
using System.Collections;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.PushKit;

namespace Xamarin2048
{
	public class GameboardView
	{
		int dimension;
		float tileWidth;
		float tilePadding;
		float cornerRadius;

		int tilePopStartScale = 0.1;
		int tilePopMaxScale = 1.1;
		float tilePopDelay = 0.05;
		float tileExpandTime = 0.18;
		float tileContractTime = 0.08;

		float tileMergeStartScale = 1.0;
		float tileMergeExpandTime = 0.08;
		float tileMergeContractTime = 0.08;

		let perSquareSlideDuration: NSTimeInterval = 0.08
		public GameboardView (int d,float width,float padding,float radius, UIColor backgroundColor, UIColor foregroundColor)
		{
			if (d > 0) {

			} else
				throw new Exception ();
		}
	}
}

