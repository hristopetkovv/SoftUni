namespace LogoPrinter
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.Write("Please enter and odd number between 2 and 10 000: ");
            var figureSize = int.Parse(Console.ReadLine());

            var mid = figureSize * 2;
            var leftRightDasheshCount = figureSize;
            var middleRowIndex = figureSize / 2;
            var starsCount = figureSize;
            var dashesCount = figureSize;

            var logoPrinter = new LogoPrinter(figureSize, middleRowIndex, leftRightDasheshCount, starsCount, dashesCount, mid);

            logoPrinter.PrintUpperPartOfLogo();

            logoPrinter.PrintBottomPartOfLogo(logoPrinter.MidDashesCount);

        }
    }
}

