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

		RelativeLayout content;

		Context context;

		public MainView(Context context) : base(context)
		{
			this.context = context;

			Background = new ColorDrawable(Color.White);
			LayoutParameters = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

			content = new RelativeLayout(context);
			content.LayoutParameters = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

			AddView(content);


			list = new ListView(context);
			list.SetPadding(10, 10, 10, 10);
			list.DividerHeight = 10;

			content.AddView(list);

			SendMessage = new SendMessageView(context);
			content.AddView(SendMessage);

			list.Adapter = new MessageListAdapter(context);

			Indicator = new ConnectionIndicator(context);

			AddView(Indicator);

			SetLayout();
		}

		int initialSize;

		void SetLayout()
		{
			int w = context.Resources.DisplayMetrics.WidthPixels;
			int h = context.Resources.DisplayMetrics.HeightPixels;

			if (initialSize == 0)
			{
				initialSize = h / 12;
			}

			var layout = new RelativeLayout.LayoutParams(w, initialSize);
			layout.AddRule(LayoutRules.AlignParentBottom);

			SendMessage.LayoutParameters = layout;

			h -= initialSize;

			list.LayoutParameters = new RelativeLayout.LayoutParams(w, h);
		}
	}
}
