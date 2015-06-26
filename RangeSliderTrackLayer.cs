using System;

using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace sliderDemo
{
	class RangeSliderTrackLayer : CALayer
	{

		public override void DrawInContext (CGContext ctx)
		{
			base.DrawInContext (ctx);



			// clip
			var cornerRadius = Bounds.Height / 2.0f;
			UIBezierPath switchOutline =  UIBezierPath.FromRoundedRect( (CGRect)Bounds, (nfloat)cornerRadius);
			ctx.AddPath (switchOutline.CGPath);
			ctx.Clip ();

			// 1) fill the track
			ctx.SetFillColor (UIColor.Green.CGColor);
			ctx.AddPath(switchOutline.CGPath);
			ctx.FillPath ();

			// 2) fill the highlighed range //Skipped for demo

			// 3) add a highlight over the track
			CGRect highlight = new CGRect(cornerRadius/2, Bounds.Height/2,
				Bounds.Width - cornerRadius, Bounds.Height/2);
			UIBezierPath highlightPath = UIBezierPath.FromRoundedRect ((CGRect)highlight, (nfloat)highlight.Height / 2.0f);
			ctx.AddPath(highlightPath.CGPath);
			ctx.SetFillColor( UIColor.FromWhiteAlpha((nfloat)1.0f, (nfloat)0.4f).CGColor);
			ctx.FillPath ();

			// 4) inner shadow
			ctx.SetShadow( new CGSize(0f, 2.0f), 3.0f, UIColor.Gray.CGColor);
			ctx.AddPath (switchOutline.CGPath);
			ctx.SetStrokeColor(UIColor.Gray.CGColor);
			ctx.StrokePath ();

			// 5) outline the track
			ctx.AddPath( switchOutline.CGPath);
			ctx.SetStrokeColor(UIColor.Black.CGColor);
			ctx.SetLineWidth ((nfloat)0.5f);
			ctx.StrokePath ();

//
//			ctx.SetFillColor (UIColor.Blue.CGColor);
//			ctx.FillRect (Bounds);
		}
	}


}

