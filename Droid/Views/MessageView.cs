using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using ChatSharp;

namespace mobile_irc.Droid
{
	public class MessageView : LinearLayout
	{
		TextView message, sender, date;

		LinearLayout dataContainer;

		public MessageView(Context context) : base(context)
		{
			Orientation = Orientation.Vertical;

			var background = new GradientDrawable();
			background.SetColor(Colors.NearWhite);
			background.SetCornerRadius(10);

			Background = background;
			message = new TextView(context);
			message.SetTextColor(Color.Black);

			AddView(message);

			LayoutParameters = new AbsListView.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

			var messageLayout = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
			messageLayout.SetMargins(5, 5, 5, 5);
			message.LayoutParameters = messageLayout;

			dataContainer = new LinearLayout(context);
			dataContainer.Orientation = Orientation.Horizontal;

			AddView(dataContainer);

			sender = GetSubtitle(context);
			sender.Gravity = Android.Views.GravityFlags.CenterVertical;

			date = GetSubtitle(context);
			date.Gravity = Android.Views.GravityFlags.CenterVertical | Android.Views.GravityFlags.Right;

			dataContainer.AddView(sender);
			dataContainer.AddView(date);
		}

		TextView GetSubtitle(Context context)
		{
			TextView subtitle = new TextView(context);
			subtitle.SetTextColor(Color.Gray);
			subtitle.TextSize = 12;

			var layout = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent, 1);
			layout.SetMargins(10, 5, 10, 5);

			subtitle.LayoutParameters = layout;

			return subtitle;
		}

		public void Update(Message message)
		{
			this.message.Text = message.Text;

			sender.Text = message.Sender;
			date.Text = message.ParsedDate;
		}
	}
}
