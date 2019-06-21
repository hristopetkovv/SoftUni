using System;
using System.Collections.Generic;

namespace DemoDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database database = new Database(1, 2, 3, 4, 5);
            Database database2 = new Database(new List<int>() { 1, 2, 3, 4, 5 });
        }
    }
}
