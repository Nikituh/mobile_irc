using System;
namespace mobile_irc
{
	public static class Extensions
	{
		public static long TotalMilliseconds(this DateTime date)
		{
			//DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			//return (long)date.ToUniversalTime().Subtract(epoch).TotalMilliseconds;
			return (long)(date - new DateTime(1970, 1, 1)).TotalMilliseconds;
		}
	}
}
