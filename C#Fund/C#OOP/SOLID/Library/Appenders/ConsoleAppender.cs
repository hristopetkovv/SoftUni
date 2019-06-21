using Library.Appenders.Contracts;
using Library.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public void Append(string dateTime, string reportLevel, string message)
        {
            Console.WriteLine(string.Format(this.layout.Format, dateTime,reportLevel,message));                
        }
    }
}
