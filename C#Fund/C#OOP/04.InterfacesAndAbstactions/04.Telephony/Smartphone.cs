using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string website)
        {
            if(website.Any(w => char.IsDigit(w)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {website}!";
        }

        public string Call(string number)
        {
            if(!number.All(n => char.IsDigit(n)))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }
    }
}
