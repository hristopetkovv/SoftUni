using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Balanced_Parantheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stackOfParantheses = new Stack<char>();

            char[] input = Console.ReadLine().ToCharArray();

            char[] openParantheses = new char[] { '(', '{', '[' };

            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var item in input)
                {
                    if (openParantheses.Contains(item))
                    {
                        stackOfParantheses.Push(item);
                        continue;
                    }

                    if (stackOfParantheses.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    if (stackOfParantheses.Peek() == '(' && item == ')')
                    {
                        stackOfParantheses.Pop();
                    }
                    else if (stackOfParantheses.Peek() == '[' && item == ']')
                    {
                        stackOfParantheses.Pop();
                    }
                    else if (stackOfParantheses.Peek() == '{' && item == '}')
                    {
                        stackOfParantheses.Pop();
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }

            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
