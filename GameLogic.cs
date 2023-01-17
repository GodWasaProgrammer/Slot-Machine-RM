namespace Slot_Machine_RM
{
    internal class GameLogic
    {
        public static int ReturnCostOfBet(Enums.Bets yourchoice)
        {
            if (yourchoice < Enums.Bets.Diagonals)
            {
                return Data.MAXBET;
            }
            else if (yourchoice == Enums.Bets.Diagonals)
            {
                return Data.DIAGONALBET;
            }
            else
            {
                return Data.SINGLEBET;
            }

        }

        public static int CalculateWinningLines(int[,] slotArray, Enums.Bets choice)
        {
            int amountOfWonLines = 0;

            if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
            {
                if (choice == Enums.Bets.TopToBottomDiagonal)
                {
                    amountOfWonLines++;
                }

                if (choice == Enums.Bets.Diagonals)
                {
                    amountOfWonLines++;
                }

            }

            if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
            {
                if (choice == Enums.Bets.BottomToTopDiagonal)
                {
                    amountOfWonLines++;
                }

                if (choice == Enums.Bets.Diagonals)
                {
                    amountOfWonLines++;
                }

            }

            for (int row = 0; row < slotArray.GetLength(0); row++)
            {

                if (slotArray[row, 0] == slotArray[row, 1] && slotArray[row, 1] == slotArray[row, 2])
                {
                    if (choice == Enums.Bets.Horizontals)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Enums.Bets.FirstHorizontal && row == 0)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Enums.Bets.SecondHorizontal && row == 1)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Enums.Bets.ThirdHorizontal && row == 2)
                    {
                        amountOfWonLines++;
                    }

                }

            }

            for (int col = 0; col < slotArray.GetLength(1); col++)
            {
                if (slotArray[0, col] == slotArray[1, col] && slotArray[1, col] == slotArray[2, col])
                {
                    if (choice == Enums.Bets.Verticals)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Enums.Bets.FirstVertical && col == 0)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Enums.Bets.SecondVertical && col == 1)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Enums.Bets.ThirdVertical && col == 2)
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