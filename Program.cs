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
            Console.WriteLine("Welcome to our slot machine");

            int cash = 100;
            Console.WriteLine($"you have {cash} to play with");

            int round = 0;

            do
            {
                var names = Enum.GetNames(typeof(Bets));

                for (int i = 1; i < names.Length; i++)
                {
                    Console.WriteLine($"{i} {names[i]},");
                }

                Console.WriteLine("Insert the number of the line you would like to play.");

                int choice;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out choice) == false)
                    {
                        Console.WriteLine("Nein Nein Nein! Das ist not a numbah!");
                    }

                    if (choice < 1 || choice > 11)
                    {
                        Console.WriteLine("between 1 and 11");
                        continue;
                    }

                    break;
                }

                // makes a variable of type Bets, and reads a position of Bets by using the index of choice
                Bets choiceCasted = (Bets)choice;

                if (choiceCasted < Bets.Diagonals)
                {
                    cash -= MAXBET;
                }

                else if (choiceCasted == Bets.Diagonals)
                {
                    cash -= DIAGONALBET;
                }

                else
                {
                    cash -= SINGLEBET;
                }

                round++;
                Console.WriteLine($"Current round:{round}");

                Console.WriteLine("-------");
                int[,] slotArray = new int[3, 3];
                int amountOfWonLines = 0;
                int iterationCounter = 0;
                for (int row = 0; row < slotArray.GetLength(0); row++)
                {
                    for (int col = 0; col < slotArray.GetLength(1); col++)
                    {
                        Random rng = new();
                        slotArray[row, col] = rng.Next(MINVALUE, MAX_VALUE);
                        Console.Write($" {slotArray[row, col]}");
                        iterationCounter++;

                        if (slotArray[row, 0] == slotArray[row, 1] && slotArray[row, 1] == slotArray[row, 2])
                        {
                            if (choiceCasted == Bets.Horizontals)
                            {
                                amountOfWonLines++;
                            }

                            if (choiceCasted == Bets.FirstHorizontal && row == 0)
                            {
                                amountOfWonLines++;
                            }

                            if (choiceCasted == Bets.SecondHorizontal && row == 1)
                            {
                                amountOfWonLines++;
                            }

                            if (choiceCasted == Bets.ThirdHorizontal && row == 2)
                            {
                                amountOfWonLines++;
                            }

                        }

                        if (slotArray[0, col] == slotArray[1, col] && slotArray[1, col] == slotArray[2, col])
                        {
                            if (choiceCasted == Bets.Verticals)
                            {
                                amountOfWonLines++;
                            }

                            if (choiceCasted == Bets.FirstVertical && col == 0)
                            {
                                amountOfWonLines++;
                            }

                            if (choiceCasted == Bets.SecondVertical && col == 1)
                            {
                                amountOfWonLines++;
                            }

                            if (choiceCasted == Bets.ThirdVertical && col == 2)
                            {
                                amountOfWonLines++;
                            }

                        }

                        if (iterationCounter == 9)
                        {
                            if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
                            {
                                if (choiceCasted == Bets.TopToBottomDiagonal)
                                {
                                    amountOfWonLines++;
                                }

                                if (choiceCasted == Bets.Diagonals)
                                {
                                    amountOfWonLines++;
                                }

                            }

                            if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
                            {

                                if (choiceCasted == Bets.BottomToTopDiagonal)
                                {
                                    amountOfWonLines++;
                                }

                                if (choiceCasted == Bets.Diagonals)
                                {
                                    amountOfWonLines++;
                                }

                            }

                        }

                    }

                    Console.WriteLine();
                }

                Console.WriteLine("-------");

                if (amountOfWonLines > 0)
                {
                    string printBetChoice = Enum.GetName(typeof(Bets), choice);

                    switch (choice)
                    {
                        case int i when choice >= 0 && i <= 10:
                            Console.WriteLine($"You have won on the {printBetChoice} bet!");
                            break;
                    }

                    int roundPayOut = amountOfWonLines * WINPAYOUT;
                    Console.WriteLine($"Payout for {amountOfWonLines} Lines won is : {roundPayOut}");

                    cash += roundPayOut;
                }

                Console.WriteLine($"Current cash is:{cash}");
            }
            while (cash > BROKE);

            Console.WriteLine("you ran out of money!");

            Console.WriteLine("Game over!");
        }
    }
}