namespace Slot_Machine_RM
{
    internal class GameCalculations
    {
        public static int InputVerification()
        {
            var names = Enum.GetNames(typeof(Data.Bets));

            for (int i = 1; i < names.Length; i++)
            {
                Console.WriteLine($"{i} {names[i]},");
            }

            Console.WriteLine("Insert the number of the line you would like to play.");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input) == false)
                {
                    Console.WriteLine("Nein Nein Nein! Das ist not a numbah!");
                }

                if (input < 1 || input > 11)
                {
                    Console.WriteLine("between 1 and 11");
                    continue;
                }

                return input;
            }

        }
        public static int ReturnCostOfBet(Data.Bets yourchoice)
        {
            if (yourchoice < Data.Bets.Diagonals)
            {
                return Data.MAXBET;
            }
            else if (yourchoice == Data.Bets.Diagonals)
            {
                return Data.DIAGONALBET;
            }
            else
            {
                return Data.SINGLEBET;
            }

        }
        public static int CalculateWinningLines(int[,] slotArray, Data.Bets choice)
        {
            int amountOfWonLines = 0;

            if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
            {
                if (choice == Data.Bets.TopToBottomDiagonal)
                {
                    amountOfWonLines++;
                }

                if (choice == Data.Bets.Diagonals)
                {
                    amountOfWonLines++;
                }

            }

            if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
            {
                if (choice == Data.Bets.BottomToTopDiagonal)
                {
                    amountOfWonLines++;
                }

                if (choice == Data.Bets.Diagonals)
                {
                    amountOfWonLines++;
                }

            }

            for (int row = 0; row < slotArray.GetLength(0); row++)
            {

                if (slotArray[row, 0] == slotArray[row, 1] && slotArray[row, 1] == slotArray[row, 2])
                {
                    if (choice == Data.Bets.Horizontals)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Data.Bets.FirstHorizontal && row == 0)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Data.Bets.SecondHorizontal && row == 1)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Data.Bets.ThirdHorizontal && row == 2)
                    {
                        amountOfWonLines++;
                    }

                }

            }

            for (int col = 0; col < slotArray.GetLength(1); col++)
            {
                if (slotArray[0, col] == slotArray[1, col] && slotArray[1, col] == slotArray[2, col])
                {
                    if (choice == Data.Bets.Verticals)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Data.Bets.FirstVertical && col == 0)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Data.Bets.SecondVertical && col == 1)
                    {
                        amountOfWonLines++;
                    }

                    if (choice == Data.Bets.ThirdVertical && col == 2)
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