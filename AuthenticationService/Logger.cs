using System;
using System.IO;
using System.Threading;

namespace AuthenticationService
{
	public class Logger : ILogger
	{
		private readonly ReaderWriterLockSlim lock_ = new();

		private string LogDirectory { get; set; }

		public Logger()
		{
			LogDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

			if (!Directory.Exists(LogDirectory))
				Directory.CreateDirectory(LogDirectory);
		}

		public void WriteEvent(string eventMessage)
		{
			lock_.EnterWriteLock();
			try
			{
				using StreamWriter writer = new(LogDirectory + "events.txt", append: true);
				writer.WriteLine(eventMessage);
			}
			finally
			{
				lock_.ExitWriteLock();
			}
		}

		public void WriteError(string errorMessage)
		{
			lock_.EnterWriteLock();
			try
			{
				using StreamWriter writer = new("errors.txt", append: true);
				writer.WriteLine(errorMessage);
			}
			finally
			{
				lock_.ExitWriteLock();
			}
		}
	}
}