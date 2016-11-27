using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace mobile_irc.Droid
{
	public class SendButton : RelativeLayout
	{
		public new EventHandler<EventArgs> Pressed;

		TextView text;

		public SendButton(Context context) : base(context)
		{
			var background = new GradientDrawable();
			background.SetCornerRadius(5);
			background.SetColor(Colors.CustomRed);
			//Background = background;

			text = new TextView(context);
			text.Gravity = Android.Views.GravityFlags.Center;
			text.Typeface = Typeface.Create("HelveticaNeue", TypefaceStyle.Bold);
			text.Text = "Send";
			text.SetTextColor(Color.White);

			var layout = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
			layout.SetMargins(10, 10, 10, 10);
			text.LayoutParameters = layout;

			text.Background = background;

			AddView(text);
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			if (e.Action == MotionEventActions.Down)
			{
				text.Alpha = 0.6f;
			}
			else if (e.Action == MotionEventActions.Up)
			{
				text.Alpha = 1f;
				if (Pressed != null) 
				{
					SendMessageView parent = (SendMessageView)Parent;
					Pressed(parent.Text.Trim(), EventArgs.Empty);
				}
			}
			else if (e.Action == MotionEventActions.Cancel)
			{
				text.Alpha = 1f;
			}

			return true;
		}
	}
}
