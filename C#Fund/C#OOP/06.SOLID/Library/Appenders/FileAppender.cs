using Library.Appenders.Contracts;
using Library.Layouts.Contracts;
using Library.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library.Appenders
{
    public class FileAppender : IAppender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILayout layout;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public void Append(string dateTime, string reportLevel, string message)
        {
            string content = string.Format(this.layout.Format, dateTime, reportLevel, message) + Environment.NewLine;

            File.AppendAllText(Path,content );
        }
    }
}
