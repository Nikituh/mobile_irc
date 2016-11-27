using Android.App;
using Android.Widget;
using Android.OS;

using System.Linq;
using System;

using ChatSharp;
using ChatSharp.Events;
using Android.Graphics.Drawables;

namespace mobile_irc.Droid
{
	[Activity(Label = "#õlidnd", MainLauncher = true)]
	public class MainActivity : Activity
	{
		const string Server = "irc.quakenet.org";

		static string Channel = "#õlidnd";
		static string Nickname = "NikiMobile";
		static string User = "niki";

		MainView ContentView { get; set; }

		IrcClient Client;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			ContentView = new MainView(this);
			SetContentView(ContentView);

			Client = new IrcClient(Server, new IrcUser(Nickname, User));

			Window.SetSoftInputMode(Android.Views.SoftInput.StateHidden | Android.Views.SoftInput.AdjustResize);

			ActionBar.SetBackgroundDrawable(new ColorDrawable(Colors.CustomRed));

			Connect();

			ContentView.SendMessage.Button.Pressed += SendMessage;
		}

		void Connect()
		{
			Client.ConnectAsync();

			Client.ConnectionComplete += OnConnectionComplete;

			Client.ChannelMessageRecieved += OnMessageReceived;
		}

		void SendMessage(object sender, EventArgs e)
		{
			string message = (string)sender;

			if (!Client.Channels.Contains(Channel))
			{
				Alert("Whoops! This channel doesn't appear to be in your list");
				return;
			}

			var channel = Client.Channels[Channel];
			channel.SendMessage(message);

			ContentView.SendMessage.Clear();

			Reload(Message.FromSelf(message, Nickname));
		}

		void OnConnectionComplete(object sender, EventArgs e)
		{
			Client.JoinChannel(Channel);
			ContentView.Indicator.SetConnected();
		}

		void OnMessageReceived(object sender, PrivateMessageEventArgs e)
		{
			Reload(Message.FromPrivateMessage(e.PrivateMessage));
		}

		void Reload(Message message)
		{
			ContentView.Adapter.Items.Add(message);

			RunOnUiThread(delegate
			{
				ContentView.Adapter.NotifyDataSetChanged();
			});
		}

		void Alert(string message)
		{
			Toast.MakeText(this, message, ToastLength.Short).Show();
		}
	}
}

