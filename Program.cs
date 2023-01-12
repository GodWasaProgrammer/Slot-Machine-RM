

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

                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {names[i]},");
                }

                //int i = 1;
                //foreach (var Choice in Enum.GetNames(typeof(Bets)))
                //{
                //    Console.WriteLine($"{i + 1} {Choice},");
                //    i++;
                //}

                Console.WriteLine("Insert the number of the line you would like to play.");

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                if (choice == (int)Bets.Horizontals)
                {
                    cash -= MAXBET;
                }

                if (choice == (int)Bets.Verticals)
                {
                    cash -= MAXBET;
                }

                if (choice == (int)Bets.Diagonals)
                {
                    cash -= DIAGONALBET;
                }

                if (choice == (int)Bets.FirstHorizontal)
                {
                    cash -= SINGLEBET;
                }

                if (choice == (int)Bets.SecondHorizontal)
                {
                    cash -= SINGLEBET;
                }

                if (choice == (int)Bets.ThirdHorizontal)
                {
                    cash -= SINGLEBET;
                }

                if (choice == (int)Bets.FirstVertical)
                {
                    cash -= SINGLEBET;
                }

                if (choice == (int)Bets.SecondVertical)
                {
                    cash -= SINGLEBET;
                }

                if (choice == (int)Bets.ThirdVertical)
                {
                    cash -= SINGLEBET;
                }

                if (choice == (int)Bets.TopToBottomDiagonal)
                {
                    cash -= SINGLEBET;
                }

                if (choice == (int)Bets.BottomToTopDiagonal)
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
                            if (choice == (int)Bets.Horizontals)
                            {
                                amountOfWonLines++;
                            }

                            if (choice == (int)Bets.FirstHorizontal && row == 0)
                            {
                                amountOfWonLines++;
                            }

                            if (choice == (int)Bets.SecondHorizontal)
                            {
                                if (row == 1)
                                {
                                    amountOfWonLines++;
                                }

                            }

                            if (choice == (int)Bets.ThirdHorizontal)
                            {
                                if (row == 2)
                                {
                                    amountOfWonLines++;
                                }

                            }

                        }

                        if (slotArray[0, col] == slotArray[1, col] && slotArray[1, col] == slotArray[2, col])
                        {
                            if (choice == (int)Bets.Verticals)
                            {
                                amountOfWonLines++;
                            }

                            if (choice == (int)Bets.FirstVertical)
                            {
                                if (col == 0)
                                {
                                    amountOfWonLines++;
                                }

                            }

                            if (choice == (int)Bets.SecondVertical)
                            {
                                if (col == 1)
                                {
                                    amountOfWonLines++;
                                }

                            }

                            if (choice == (int)Bets.ThirdVertical)
                            {
                                if (col == 2)
                                {
                                    amountOfWonLines++;
                                }

                            }

                        }

                        if (iterationCounter == 9)
                        {
                            if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
                            {
                                if (choice == (int)Bets.TopToBottomDiagonal)
                                {
                                    amountOfWonLines++;
                                }

                                if (choice == (int)Bets.Diagonals)
                                {
                                    amountOfWonLines++;
                                }

                            }

                            if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
                            {

                                if (choice == (int)Bets.BottomToTopDiagonal)
                                {
                                    amountOfWonLines++;
                                }

                                if (choice == (int)Bets.Diagonals)
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
                    int roundPayOut = 0;

                    // var eChoice = Bets.Diagonals;

                    //Console.WriteLine($"You won: {eChoice.ToString()}");
                    //roundPayOut = amountOfWonLines * WINPAYOUT;

                    if (choice == (int)Bets.Horizontals)
                    {
                        Console.WriteLine($"You have won on the horizontal bet!");
                    }

                    if (choice == (int)Bets.Verticals)
                    {
                        Console.WriteLine("You have won the vertical bet!");
                    }

                    if (choice == (int)Bets.Diagonals)
                    {
                        Console.WriteLine("You have won the diagonal bet!");
                    }

                    if (choice == (int)Bets.FirstHorizontal)
                    {
                        Console.WriteLine("You have won on the first Horizontal!");
                    }

                    if (choice == (int)Bets.SecondHorizontal)
                    {
                        Console.WriteLine("You have won on the second Horizontal!");
                    }

                    if (choice == (int)Bets.ThirdHorizontal)
                    {
                        Console.WriteLine("You have won on the third horizontal!");
                    }

                    if (choice == (int)Bets.FirstVertical)
                    {
                        Console.WriteLine("You have won on the first vertical!");
                    }

                    if (choice == (int)Bets.SecondVertical)
                    {
                        Console.WriteLine("You have won on the second vertical!");
                    }

                    if (choice == (int)Bets.ThirdVertical)
                    {
                        Console.WriteLine("You have won on the first vertical!");
                    }

                    if (choice == (int)Bets.TopToBottomDiagonal)
                    {
                        Console.WriteLine("You have won on the Top To Bottom Diagonal!");
                    }

                    if (choice == (int)Bets.BottomToTopDiagonal)
                    {
                        Console.WriteLine("YOu have won the bottom to top diagonal");
                    }

                    roundPayOut = amountOfWonLines * WINPAYOUT;
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