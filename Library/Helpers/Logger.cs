using System;
using System.IO;
using System.Text;

namespace Oadr.Library
{
    public class Logger
    {
        private static readonly string _lock = string.Empty;

        public static void LogMessage(string strMessage)
        {
            using (var fs = File.Open("ven.log", FileMode.Append))
            {
                var encoding = new UTF8Encoding();
                var bytes = encoding.GetBytes(strMessage);
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        public static void LogError(string message)
        {
            lock (_lock)
            {
                message = $"[ {DateTime.Now} ] [ ERROR ]: {message}\r\n";
                LogMessage(message);
            }
        }

        public static void LogException(Exception ex)
        {
            lock (_lock)
            {
                var message = ex.Message + "\n" + ex.StackTrace;
                message = $"[ {DateTime.Now} ] [ ERROR ]: {message}\r\n";
                LogMessage(message);
            }
        }
    }
}
