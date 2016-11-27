using System;
using Android.Content;
using Android.Graphics;
using Android.Widget;

namespace mobile_irc.Droid
{
	public class SendMessageView : LinearLayout
	{
		EditText message;
		public SendButton Button { get; private set; }

		public string Text { get { return message.Text; } }

		public SendMessageView(Context context) : base(context)
		{
			SetBackgroundColor(Colors.NearWhite);

			message = new EditText(context);
			message.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent, 1);
			message.SetPadding(10, 10, 10, 10);

			AddView(message);

			Button = new SendButton(context);
			Button.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent, 3);
			//Button.SetPadding(10, 5, 10, 5);

			AddView(Button);
		}

		public void Clear()
		{
			message.Text = "";
		}
	}
}
