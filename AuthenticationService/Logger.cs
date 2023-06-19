using System;
using System.IO;

namespace AuthenticationService
{
	public class Logger : ILogger
	{
		private static readonly string logsDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
		private readonly string currentLogsDir;
		private readonly string eventFile;
		private readonly string errorFile;
		public Logger() {
			currentLogsDir = Path.Combine(logsDir, GenerateDTString());
			Directory.CreateDirectory(currentLogsDir);
			eventFile = Path.Combine(currentLogsDir, "events.txt");
			errorFile = Path.Combine(currentLogsDir, "errors.txt");
		}

		private static string GenerateDTString() => DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");

		public void WriteEvent(string eventMessage)
		{
			File.AppendAllText(eventFile, eventMessage + '\n');
		}
		public void WriteError(string errorMessage)
		{
			File.AppendAllText(errorFile, errorMessage + '\n');
		}
	}
}