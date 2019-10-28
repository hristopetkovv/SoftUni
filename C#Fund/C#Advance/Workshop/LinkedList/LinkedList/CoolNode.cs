using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CoolNode
    {
        public CoolNode(object value)
        {
            this.Value = value;
        }

        public object Value { get;  set; }

        public CoolNode Next { get;  set; }

        public CoolNode Previous { get;  set; }
    }
}
