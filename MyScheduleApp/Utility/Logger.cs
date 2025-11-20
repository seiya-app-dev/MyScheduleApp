using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduleApp.Utility
{
    public class Logger
    {
        private static string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        private static string logFileName = Path.Combine(logDir, "app.log");

        static Logger()
        {
            if(!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
        }

        public static void Log(string message)
        {
            try
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}";
                File.AppendAllText(logFileName, logMessage + Environment.NewLine);
            }
            catch
            {

            }
        }
    }
}
