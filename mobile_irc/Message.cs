
using System;
using ChatSharp;

namespace mobile_irc
{
	public class Message
	{
		public string Text { get; set; }

		public string Sender { get; set; }

		public long Date { get; set; }

		public bool IsFromSelf { get; set; }

		public string ParsedDate
		{
			get 
			{
				var date = TimeSpan.FromMilliseconds(Date);

				string result = "";

				if (date.Hours < 10)
				{
					result += "0" + date.Hours;
				}
				else
				{
					result += date.Hours;
				}

				result += ":";

				if (date.Minutes < 10)
				{
					result += "0" + date.Minutes;
				}
				else
				{
					result += date.Minutes;
				}

				return result;
			}
		}

		public static Message FromPrivateMessage(PrivateMessage pm)
		{
			return new Message
			{
				Text = pm.Message,
				Sender = pm.User.Nick,
				Date = DateTime.Now.TotalMilliseconds(),
				IsFromSelf = false
			};
		}

		public static Message FromSelf(string message, string user)
		{
			return new Message
			{
				Text = message,
				Sender = user,
				Date = DateTime.Now.TotalMilliseconds(),
				IsFromSelf = true
			};
		}
	}
}
