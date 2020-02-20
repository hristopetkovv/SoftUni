namespace LogoPrinter
{
    using System;

    public class LogoPrinter
    {
        private int figureSize;
        private int leftRightDashesCount;
        private int middleRowIndex;
        private int starsCount;
        private int dashesCount;
        private int midDashesCount;
        private int starsInBottomMiddle;
        private int dashesInBottomMiddle;

        public LogoPrinter(int figureSize, int middleRowIndex, int leftRightDashesCount, int starsCount, int dashesCount, int midDashesCount)
        {
            this.FigureSize = figureSize;
            this.MiddleRowIndex = middleRowIndex;
            this.LeftRightDashesCount = leftRightDashesCount;
            this.StarsCount = starsCount;
            this.DashesCount = dashesCount;
            this.MidDashesCount = midDashesCount;
        }

        public int FigureSize
        {
            get { return this.figureSize; }
            set { this.figureSize = value; }
        }
        public int LeftRightDashesCount
        {
            get { return this.leftRightDashesCount; }
            set { this.leftRightDashesCount = value; }
        }
        public int MiddleRowIndex
        {
            get { return this.middleRowIndex; }
            set { this.middleRowIndex = value; }
        }
        public int StarsCount
        {
            get { return this.starsCount; }
            set { this.starsCount = value; }
        }
        public int DashesCount
        {
            get { return this.dashesCount; }
            set { this.dashesCount = value; }
        }
        public int MidDashesCount
        {
            get { return this.midDashesCount; }
            set { this.midDashesCount = value; }
        }
        public int StarsInBottomMiddle
        {
            get { return this.starsInBottomMiddle; }
            set { this.starsInBottomMiddle = value; }
        }
        public int DashesInBottomMiddle
        {
            get { return this.dashesInBottomMiddle; }
            set { this.dashesInBottomMiddle = value; }
        }


        public void PrintUpperPartOfLogo()
        {
            for (int i = 0; i <= this.MiddleRowIndex; i++)
            {
                Console.WriteLine(
                    new string('-', this.LeftRightDashesCount)
                    + new string('*', this.StarsCount)
                    + new string('-', this.DashesCount)
                    + new string('*', this.StarsCount)
                    + new string('-', this.MidDashesCount)
                    + new string('*', this.StarsCount)
                    + new string('-', this.DashesCount)
                    + new string('*', this.StarsCount)
                    + new string('-', this.LeftRightDashesCount));
                this.LeftRightDashesCount--;
                this.StarsCount += 2;
                this.DashesCount -= 2;
                this.MidDashesCount -= 2;
            }
        }

        public void PrintBottomPartOfLogo(int middleDashesCount)
        {
            this.StarsCount = this.FigureSize;
            this.StarsInBottomMiddle = this.FigureSize * 2 - 1;
            this.DashesInBottomMiddle = middleDashesCount;
            this.DashesCount = 1;

            for (int i = 0; i <= this.MiddleRowIndex; i++)
            {
                Console.WriteLine(
                     new string('-', this.LeftRightDashesCount)
                     + new string('*', this.StarsCount)
                     + new string('-', this.DashesCount)
                     + new string('*', this.StarsInBottomMiddle)
                     + new string('-', this.DashesCount)
                     + new string('*', this.StarsCount)
                     + new string('-', this.DashesInBottomMiddle)
                     + new string('*', this.StarsCount)
                     + new string('-', this.DashesCount)
                     + new string('*', this.StarsInBottomMiddle)
                     + new string('-', this.DashesCount)
                     + new string('*', this.StarsCount)
                     + new string('-', this.LeftRightDashesCount));
                this.LeftRightDashesCount--;
                this.DashesCount += 2;
                this.StarsInBottomMiddle -= 2;
                this.DashesInBottomMiddle -= 2;
            }
        }
    }
}
