using System;

using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace sliderDemo
{
	public class RangeSliderView : UIControl
	{
		RangeSliderTrackLayer _trackLayer;

		RangeSliderKnobLayer _leftKnobLayer;

		RangeSliderKnobLayer _rightKnobLayer;

		CGPoint _leftTouchPoint;

		CGPoint _rightTouchPoint;

		public RangeSliderView ()
		{
			init ();
		}
		public RangeSliderView (CGRect frame) : base(frame)
		{
			init ();	
		}

		private void init(){
			_trackLayer = new RangeSliderTrackLayer ();
			Layer.AddSublayer (_trackLayer);

			_leftKnobLayer = new RangeSliderKnobLayer ();
			Layer.AddSublayer (_leftKnobLayer);

			_rightKnobLayer = new RangeSliderKnobLayer ();
			Layer.AddSublayer (_rightKnobLayer);

			SetLayerFrames ();
		}

		void SetLayerFrames ()
		{

			_trackLayer.Frame = new CGRect (0, (Bounds.Height * 0.25), Bounds.Width, Bounds.Height / 2);
			_trackLayer.SetNeedsDisplay ();

			var leftX = _leftTouchPoint == CGPoint.Empty ? 50 : _leftTouchPoint.X;

			_leftKnobLayer.Frame = new CGRect (leftX, 0, Bounds.Height, Bounds.Height);
			_leftKnobLayer.SetNeedsDisplay ();

			var rightX = _rightTouchPoint == CGPoint.Empty ? Bounds.Width - (50 + Bounds.Height) : _rightTouchPoint.X;

			_rightKnobLayer.Frame = new CGRect (rightX, 0, Bounds.Height, Bounds.Height);
			_rightKnobLayer.SetNeedsDisplay ();
		}

		public override bool BeginTracking (UITouch uitouch, UIEvent uievent)
		{
			var TouchPoint = uitouch.LocationInView (this);

			if (_leftKnobLayer.Frame.Contains (TouchPoint)) {
				_leftTouchPoint = TouchPoint;
				_leftKnobLayer.Highlighted = true;
				_leftKnobLayer.SetNeedsDisplay ();
			}
			else if (_rightKnobLayer.Frame.Contains (TouchPoint)) {
				_rightTouchPoint = TouchPoint;
				_rightKnobLayer.Highlighted = true;
				_rightKnobLayer.SetNeedsDisplay ();
			}

			return _leftKnobLayer.Highlighted || _rightKnobLayer.Highlighted;
		}

		public override bool ContinueTracking (UITouch uitouch, UIEvent uievent)
		{
			var TouchPoint = uitouch.LocationInView (this);

			if (_leftKnobLayer.Highlighted) {
				_leftTouchPoint = TouchPoint;
			} else if (_rightKnobLayer.Highlighted) {
				_rightTouchPoint = TouchPoint;
			}

			CATransaction.Begin ();
			CATransaction.DisableActions = true;

			SetLayerFrames ();

			CATransaction.Commit ();

			return _leftKnobLayer.Highlighted || _rightKnobLayer.Highlighted;
		}

		public override void EndTracking (UITouch uitouch, UIEvent uievent)
		{
			_leftKnobLayer.Highlighted = false;
			_rightKnobLayer.Highlighted = false;

			_leftKnobLayer.SetNeedsDisplay ();
			_rightKnobLayer.SetNeedsDisplay ();
		}
	}

}

