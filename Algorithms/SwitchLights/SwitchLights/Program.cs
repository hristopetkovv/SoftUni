using System;

namespace SwitchLights
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = new int[] { 0, 1, 1, 0};
        //    SwitchLights(arr);
        //}

        int[] SwitchLights(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 1)
                {
                    a[i] = 0;
                }
                else
                {
                    continue;
                }

                for (int j = 0; j < i; j++)
                {
                    if (a[j] == 0)
                    {
                        a[j] = 1;
                    }
                    else
                    {
                        a[j] = 0;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", a));
            return a;
        }
    }
}
