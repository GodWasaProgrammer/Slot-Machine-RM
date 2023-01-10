

namespace Slot_Machine_RM
{
    internal class Program
    {
        const int MAXVALUE = 4;
        const int MINVALUE = 1;
        const int MAXBET = 3;
        const int BROKE = 0;
        const int WINPAYOUT = 2;
        const int DIAGONALBET = 2;
        const int SINGLEBET = 1;


        enum Bets
        {
            Horizontals = 1,
            Verticals = 2,
            Diagonals = 3,
            FirstHorizontal = 4,
            SecondHorizontal = 5,
            ThirdHorizontal = 6,
            FirstVertical = 7,
            SecondVertical = 8,
            ThirdVertical = 9,
            TopToBottomDiagonal = 10,
            BottomToTopDiagonal = 11,
        };

        static void Main()
        {
            Console.WriteLine("Welcome to our slot machine");


            int cash = 100;
            Console.WriteLine($"you have {cash} to play with");

            int round = 0;

            do
            {
                int i = 1;
                foreach (var Choice in Enum.GetNames(typeof(Bets)))
                {
                    Console.WriteLine($"{i} {Choice},");
                    i++;
                }

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
                bool betIsWon = false;
                int amountOfWonLines = 0;
                int iterationCounter = 0;
                for (int row = 0; row < slotArray.GetLength(0); row++)
                {
                    for (int col = 0; col < slotArray.GetLength(1); col++)
                    {
                        Random slotArrayRandom = new();
                        slotArray[row, col] = slotArrayRandom.Next(MINVALUE, MAXVALUE);
                        Console.Write($" {slotArray[row, col]}");
                        iterationCounter++;

                        if (slotArray[row, 0] == slotArray[row, 1] && slotArray[row, 1] == slotArray[row, 2])
                        {
                            if (choice == (int)Bets.Horizontals)
                            {
                                betIsWon = true;
                                amountOfWonLines++;
                            }
                            
                            if (choice == (int)Bets.FirstHorizontal)
                            {
                                if (row == 0)
                                {
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }

                            }

                            if (choice == (int)Bets.SecondHorizontal)
                            {
                                if (row == 1)
                                {
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }

                            }

                            if (choice == (int)Bets.ThirdHorizontal)
                            {
                                if (row == 2)
                                {
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }

                            }

                        }

                        if (slotArray[0, col] == slotArray[1, col] && slotArray[1, col] == slotArray[2, col])
                        {
                            if (choice == (int)Bets.Verticals)
                            {
                                betIsWon = true;
                                amountOfWonLines++;
                            }
                            
                            if (choice == (int)Bets.FirstVertical)
                            {
                                if (col == 0)
                                {
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }

                            }

                            if (choice == (int)Bets.SecondVertical)
                            {
                                if (col == 1)
                                {
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }

                            }

                            if (choice == (int)Bets.ThirdVertical)
                            {
                                if (col == 2)
                                {
                                    betIsWon = true;
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
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }

                                if (choice == (int)Bets.Diagonals)
                                {
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }
                            }

                            if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
                            {

                                if (choice == (int)Bets.BottomToTopDiagonal)
                                {
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }

                                if (choice == (int)Bets.Diagonals)
                                {
                                    betIsWon = true;
                                    amountOfWonLines++;
                                }

                            }

                        }

                    }

                    Console.WriteLine();
                }

                Console.WriteLine("-------");

                if (betIsWon)
                {
                    int roundPayOut = 0;
                    if (choice == (int)Bets.Horizontals)
                    {
                        Console.WriteLine("You have won on the horizontal bet!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.Verticals)
                    {
                        Console.WriteLine("You have won the vertical bet!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.Diagonals)
                    {
                        Console.WriteLine("You have won the diagonal bet!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.FirstHorizontal)
                    {
                        Console.WriteLine("You have won on the first Horizontal!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.SecondHorizontal)
                    {
                        Console.WriteLine("You have won on the second Horizontal!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.ThirdHorizontal)
                    {
                        Console.WriteLine("You have won on the third horizontal!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.FirstVertical)
                    {
                        Console.WriteLine("You have won on the first vertical!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.SecondVertical)
                    {
                        Console.WriteLine("You have won on the second vertical!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.ThirdVertical)
                    {
                        Console.WriteLine("You have won on the first vertical!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.TopToBottomDiagonal)
                    {
                        Console.WriteLine("You have won on the Top To Bottom Diagonal!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (choice == (int)Bets.BottomToTopDiagonal)
                    {
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

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