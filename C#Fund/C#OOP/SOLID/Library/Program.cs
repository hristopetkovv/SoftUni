using Library.Appenders;
using Library.Appenders.Contracts;
using Library.Layouts;
using Library.Layouts.Contracts;
using Library.Loggers;
using Library.Loggers.Contracts;
using System;

namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger(consoleAppender);

            logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

        }
    }
}
