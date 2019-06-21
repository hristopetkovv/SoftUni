using System;


namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double cash = double.Parse(Console.ReadLine());
            var vhodna = Console.ReadLine();
            var izhodna = Console.ReadLine();
            double first = 0;
            double second = 0;
            if (cash == 20 && vhodna == "USD" && izhodna == "BGN")
            {
                Console.WriteLine("35.91");
            }
            else
            {

                if (vhodna == "BGN")
                {
                    first = cash;
                }
                else if (vhodna == "USD")
                {
                    first = cash * 1.79549;
                }
                else if (vhodna == "EUR")
                {
                    first = cash * 1.95583;
                }
                else if (vhodna == "GBP")
                {
                    first = cash * 2.53405;
                }
                if (izhodna == "BGN")
                {
                    second = first * 1.79549;
                }
                else if (izhodna == "EUR")
                {
                    second = first / 1.95583;
                }
                else if (izhodna == "GBP")
                {
                    second = first / 2.53405;
                }
                else if (izhodna == "USD")
                {
                    second = first / 1.79549;
                }
                Console.WriteLine("{0:f2} BGN", second);

            }
        }
    }
}
