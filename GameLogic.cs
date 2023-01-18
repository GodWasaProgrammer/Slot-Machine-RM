namespace Slot_Machine_RM
{
    public class GameLogic
    {

        static readonly Random rng = new();

        public static void FillSlotArray(int[,] slotArray)
        {
            for (int row = 0; row < slotArray.GetLength(0); row++)
            {
                for (int col = 0; col < slotArray.GetLength(1); col++)
                {
                    slotArray[row, col] = rng.Next(Data.MINVALUE, Data.MAX_VALUE);
                }

            }
        }

        public static int ReturnCostOfBet(Bets yourchoice)
        {
            if (yourchoice < Bets.Diagonals)
            {
                return Data.MAXBET;
            }
            else if (yourchoice == Bets.Diagonals)
            {
                return Data.DIAGONALBET;
            }
            else
            {
                return Data.SINGLEBET;
            }

        }

        public static int CalculateWinningLines(int[,] slotArray, Bets choice)
        {
            int amountOfWonLines = 0;

            if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
            {
                if (choice == Bets.TopToBottomDiagonal)
                {
                    amountOfWonLines++;
                }

                if (choice == Bets.Diagonals)
                {
                    amountOfWonLines++;
                }

            }

            if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
            {
                if (choice == Bets.BottomToTopDiagonal)
                {
                    amountOfWonLines++;
                }

                if (choice == Bets.Diagonals)
                {
                    amountOfWonLines++;
                }

            }

            for (int row = 0; row < slotArray.GetLength(0); row++)
            {

                if (slotArray[row, 0] == slotArray[row, 1] && slotArray[row, 1] == slotArray[row, 2])
                {
                    if (choice == Bets.Horizontals)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Bets.FirstHorizontal && row == 0)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Bets.SecondHorizontal && row == 1)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Bets.ThirdHorizontal && row == 2)
                    {
                        amountOfWonLines++;
                    }

                }

            }

            for (int col = 0; col < slotArray.GetLength(1); col++)
            {
                if (slotArray[0, col] == slotArray[1, col] && slotArray[1, col] == slotArray[2, col])
                {
                    if (choice == Bets.Verticals)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Bets.FirstVertical && col == 0)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Bets.SecondVertical && col == 1)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Bets.ThirdVertical && col == 2)
                    {
                        amountOfWonLines++;
                    }

                }

            }
            return amountOfWonLines;
        }

        public static int PayOut(int WonLines)
        {
            int roundPayOut = WonLines * Data.WINPAYOUT;
            return roundPayOut;
        }
    }
}