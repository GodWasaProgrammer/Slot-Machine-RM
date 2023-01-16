namespace Slot_Machine_RM
{
    internal class Program
    {
        const int MAX_VALUE = 4;
        const int MINVALUE = 1;
        const int MAXBET = 3;
        const int BROKE = 0;
        const int WINPAYOUT = 2;
        const int DIAGONALBET = 2;
        const int SINGLEBET = 1;
        const int ATMREFILL = 100;

        enum Bets
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

        
        static void Main()
        {
            int choiceInt;
            int cash = ATMREFILL;
            int round = 0;
            int[,] slotArray = new int[3, 3];

            WelcomeAndCashPrint(cash);
            do
            {
                choiceInt = InputVerification();
                Bets choice = (Bets)choiceInt;

                cash -= ReturnCostOfBet(choice);

                PrintSlotArray(slotArray);

                int amountOfWonLines = CalculateWinningLines(slotArray, choice);

                PrintWonLines(amountOfWonLines, choice);

                cash += PayOut(amountOfWonLines);

                round++;

                CurrentCashAndRound(cash,round);
            }
            while (cash > BROKE);

            Console.WriteLine("you ran out of money!");

            Console.WriteLine("Game over!");
        }
        static void WelcomeAndCashPrint(int cash)
        {
            Console.WriteLine("Welcome to our slot machine");
            Console.WriteLine($"you have {cash} to play with");
        }
        static int InputVerification()
        {
            var names = Enum.GetNames(typeof(Bets));

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
        static int ReturnCostOfBet(Bets yourchoice)
        {
            if (yourchoice < Bets.Diagonals)
            {
                return MAXBET;
            }
            else if (yourchoice == Bets.Diagonals)
            {
                return DIAGONALBET;
            }
            else
            {
                return SINGLEBET;
            }

        }
        static void PrintSlotArray(int[,] slotArray)
        {
            Console.WriteLine("-------");

            for (int row = 0; row < slotArray.GetLength(0); row++)
            {
                for (int col = 0; col < slotArray.GetLength(1); col++)
                {
                    Random rng = new();
                    slotArray[row, col] = rng.Next(MINVALUE, MAX_VALUE);
                    Console.Write($" {slotArray[row, col]}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("-------");
        }
        static int CalculateWinningLines(int[,] slotArray, Bets choice)
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
        static void PrintWonLines(int WonLines, Bets choice)
        {
            if (WonLines > 0)
            {
                Console.WriteLine($"You have won on the {choice} bet!");

                int localPayout = PayOut(WonLines);
                Console.WriteLine($"Payout for {WonLines} Lines won is : {localPayout}");
            }

        }
        static int PayOut(int WonLines)
        {
            int roundPayOut = WonLines * WINPAYOUT;
            return roundPayOut;
        }
        static void CurrentCashAndRound(int cash, int round)
        {
            Console.WriteLine($"Current cash is:{cash}");

            Console.WriteLine($"Current round:{round}");
        }
    }
}
