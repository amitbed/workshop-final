using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForumSystem
{
    class Logger
    {
        private static StreamWriter log;
        private static Object lockWrite;
        public Logger()
        {
            Logger.log = new StreamWriter("log.txt");
            lockWrite = new object();
        }

        public static void logError(string toWrite)
        {
            lock (lockWrite)
            {
                string line = String.Format("{0} Error: {1}", System.DateTime.Now, toWrite);
                log.WriteLine(line);
            }
        }

        public static void logDebug(string toWrite)
        {
            lock (lockWrite)
            {
                string line = String.Format("{0} Debug: {1}", System.DateTime.Now, toWrite);
                log.WriteLine(line);
            }
        }

        public static void shutDown()
        {
            log.Close();
        }
    }
}