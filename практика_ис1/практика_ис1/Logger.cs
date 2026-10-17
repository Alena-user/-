using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace практика_ис1
{
    public sealed class Logger
    {
        private static Logger instance;
        private static readonly object sync = new object();

        private readonly string logFilePath;
        private Logger()
        {
            logFilePath = "errors.log";
        }
        public static Logger Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock(sync)
                    {
                        if(instance == null)
                            instance = new Logger();
                    }
                }
                return instance;
            }
        }

        public void LogError(string message)
        {
            string line = $"[{DateTime.Now}] Error: {message}";
            Console.Error.WriteLine(line);
            lock (sync)
            {
                File.AppendAllText(logFilePath, line+Environment.NewLine);
            }
        }

    }
}
