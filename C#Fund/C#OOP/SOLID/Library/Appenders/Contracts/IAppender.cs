using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, string reportLevel, string message);
    }
}
