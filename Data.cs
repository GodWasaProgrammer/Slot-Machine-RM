namespace Slot_Machine_RM
{
    public static class Data
    {
        public const int MAX_VALUE = 4;
        public const int MINVALUE = 1;
        public const int MAXBET = 3;
        public const int BROKE = 0;
        public const int WINPAYOUT = 2;
        public const int DIAGONALBET = 2;
        public const int SINGLEBET = 1;
        public const int ATMREFILL = 100;

        public enum Bets
        {
            invalid,
            Horizontals,
            Verticals,
            Diagonals,
            FirstHorizontal,
            SecondHorizontal,
            ThirdHorizontal,
            FirstVertical,
            SecondVertical,
            ThirdVertical,
            TopToBottomDiagonal,
            BottomToTopDiagonal,
        };

        public static int choiceInt;
        public static int cash;
        public static int round = 0;
        public static int[,] slotArray = new int[3, 3];

    }
}
