using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;

namespace mobile_irc.Droid
{
	public class ConnectionIndicator : RelativeLayout
	{
		GradientDrawable background;

		Activity context;

		public ConnectionIndicator(Context context) : base(context)
		{
			this.context = (Activity)context;

			int width = context.Resources.DisplayMetrics.WidthPixels / 25;
			int height = width;

			int half = width / 2;

			background = new GradientDrawable();
			background.SetCornerRadius(half);

			Background = background;

			var layout = new RelativeLayout.LayoutParams(width, height);
			layout.SetMargins(0, half, half, 0);
			layout.AddRule(LayoutRules.AlignParentTop);
			layout.AddRule(LayoutRules.AlignParentRight);

			LayoutParameters = layout;

			SetDisconnected();
		}

		public void SetConnected()
		{
			ChangeBackground(Colors.Connected);
		}

		public void SetDisconnected()
		{
			ChangeBackground(Colors.Disconnected);
		}

		void ChangeBackground(Color color)
		{
			context.RunOnUiThread(delegate
			{
				background.SetColor(color);	
			});
		}
	}
}
