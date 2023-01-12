

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

                switch (choice)
                {
                    case 0:
                    case 1:
                        cash -= MAXBET;
                        break;
                    case 2:
                        cash -= DIAGONALBET;
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        cash -= SINGLEBET;
                        break;
                }
                //if (choice == (int)Bets.Horizontals)
                //{
                //    cash -= MAXBET;
                //}

                //if (choice == (int)Bets.Verticals)
                //{
                //    cash -= MAXBET;
                //}

                //if (choice == (int)Bets.Diagonals)
                //{
                //    cash -= DIAGONALBET;
                //}

                //if (choice == (int)Bets.FirstHorizontal)
                //{
                //    cash -= SINGLEBET;
                //}

                //if (choice == (int)Bets.SecondHorizontal)
                //{
                //    cash -= SINGLEBET;
                //}

                //if (choice == (int)Bets.ThirdHorizontal)
                //{
                //    cash -= SINGLEBET;
                //}

                //if (choice == (int)Bets.FirstVertical)
                //{
                //    cash -= SINGLEBET;
                //}

                //if (choice == (int)Bets.SecondVertical)
                //{
                //    cash -= SINGLEBET;
                //}

                //if (choice == (int)Bets.ThirdVertical)
                //{
                //    cash -= SINGLEBET;
                //}

                //if (choice == (int)Bets.TopToBottomDiagonal)
                //{
                //    cash -= SINGLEBET;
                //}

                //if (choice == (int)Bets.BottomToTopDiagonal)
                //{
                //    cash -= SINGLEBET;
                //}

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

                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine($"You have won on the horizontal bet!");
                            break;
                        case 1:
                            Console.WriteLine("You have won the vertical bet!");
                            break;
                        case 2:
                            Console.WriteLine("You have won the diagonal bet!");
                            break;
                        case 3:
                            Console.WriteLine("You have won on the first Horizontal!");
                            break;
                        case 4:
                            Console.WriteLine("You have won on the second Horizontal!");
                            break;
                        case 5:
                            Console.WriteLine("You have won on the third horizontal!");
                            break;
                        case 6:
                            Console.WriteLine("You have won on the first vertical!");
                            break;
                        case 7:
                            Console.WriteLine("You have won on the second vertical!");
                            break;
                        case 8:
                            Console.WriteLine("You have won on the third vertical!");
                            break;
                        case 9:
                            Console.WriteLine("You have won on the Top To Bottom Diagonal!");
                            break;
                        case 10:
                            Console.WriteLine("You have won the bottom to top diagonal");
                            break;
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