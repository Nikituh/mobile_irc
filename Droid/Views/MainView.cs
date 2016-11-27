using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using ChatSharp;

namespace mobile_irc.Droid
{
	public class MainView : RelativeLayout
	{
		public SendMessageView SendMessage { get; private set; }

		public MessageListAdapter Adapter { get { return list.Adapter as MessageListAdapter; } }

		public ConnectionIndicator Indicator { get; private set; }

		ListView list;

		LinearLayout content;

		public MainView(Context context) : base(context)
		{
			Background = new ColorDrawable(Color.White);

			LayoutParameters = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

			content = new LinearLayout(context);
			content.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
			content.Orientation = Orientation.Vertical;

			AddView(content);

			int w = context.Resources.DisplayMetrics.WidthPixels;
			int h = context.Resources.DisplayMetrics.HeightPixels;

			list = new ListView(context);
			list.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent, 1);

			content.AddView(list);

			SendMessage = new SendMessageView(context);
			SendMessage.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent, 9);

			content.AddView(SendMessage);

			list.Adapter = new MessageListAdapter(context);

			Indicator = new ConnectionIndicator(context);

			AddView(Indicator);
		}
	}
}
