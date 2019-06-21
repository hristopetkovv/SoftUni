using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractFile3
{
    class Program
    {
        static void Main(string[] args)
                {
            string path = Console.ReadLine();

            int startIndexOfFile = path.LastIndexOf("\\") + 1;

            string file = path.Substring(startIndexOfFile);

            int startIndexOfExtension = file.LastIndexOf('.') + 1;

            string name = file.Substring(0, startIndexOfExtension - 1);

            string extension = file.Substring(startIndexOfExtension);

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
