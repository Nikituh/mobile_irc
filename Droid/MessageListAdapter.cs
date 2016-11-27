using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using ChatSharp;

namespace mobile_irc.Droid
{
	public class MessageListAdapter : BaseAdapter<string>
	{
		public List<Message> Items { get; set; }

		public override string this[int position] { get { return Items[position] + ""; } }

		public override int Count { get { return Items.Count; } }

		Context context;

		public MessageListAdapter(Context context)
		{
			this.context = context;

			Items = new List<Message>();
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			MessageView view = (MessageView)convertView;
			Message item = Items[position];

			if (view == null)
			{
				view = new MessageView(context);
			}

			view.Update(item);

			return view;
		}
	}
}
