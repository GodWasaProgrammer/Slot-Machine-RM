using System.Collections.Generic;

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


        enum Bets
        {
            Horizontal = 1,
            Vertical = 2,
            Diagonals = 3,
        };

        static void Main()
        {
            Console.WriteLine("Welcome to our slot machine");

            int round = 0;
            int cash = 100;

            do
            {
                Console.WriteLine("Which lines would you like to bet on?");

                int i = 1;
                foreach (var Choice in Enum.GetNames(typeof(Bets)))
                {
                    Console.WriteLine($"{i} {Choice},");
                    i++;
                }

                Console.WriteLine("Insert the number of the line you would like to play.");

                Int32.TryParse(Console.ReadLine(), out i);

                round++;
                Console.WriteLine($"Current round:{round}");

                Console.WriteLine($"current cash {cash}");

                Console.WriteLine("-------");
                int[,] slotArray = new int[3, 3];
                int first = 0;
                int second = 0;
                int third = 0;
                for (int row = 0; row < slotArray.GetLength(0); row++)
                {
                    int counter = 0;
                    int rowCounter;
                    int columCounter;
                    List<int> list = new List<int>();

                    for (int col = 0; col < slotArray.GetLength(1); col++)
                    {
                        Random slotArrayRandom = new();
                        slotArray[row, col] = slotArrayRandom.Next(MINVALUE, MAXVALUE);
                        Console.Write($" {slotArray[row, col]}");

                        list.Add(round);
                        list.Add(counter);
                        rowCounter = slotArray.GetLength(0);
                        list.Add(rowCounter);
                        columCounter = slotArray.GetLength(1);
                        list.Add(columCounter);

                        if (counter == 0)
                        {
                            first = slotArray[row, col];
                        }

                        if (counter == 1)
                        {
                            second = slotArray[row, col];
                        }

                        if (counter == 2)
                        {
                            third = slotArray[row, col];
                        }
                        counter++;
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("-------");

                if (first == second && second == third)
                {
                    Console.WriteLine("we have a winner");
                }
                //if (i == (int)Bets.Horizontal)
                //{
                //    cash -= MAXBET;
                //    int payoutcounter = 0;
                //    if (slotArray[0, 0] == slotArray[0, 1] && slotArray[0, 1] == slotArray[0, 2])
                //    {
                //        Console.WriteLine("You have won on the top horizontal line!");
                //        payoutcounter++;
                //    }

                //    else
                //    {
                //        Console.WriteLine("You have Lost on the top horizontal line!");
                //    }

                //    if (slotArray[1, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[1, 2])
                //    {
                //        Console.WriteLine("You have won on the Middle horizontal Line!");
                //        payoutcounter++;
                //    }

                //    else
                //    {
                //        Console.WriteLine("You have lost on the Middle Horizontal Line!");
                //    }

                //    if (slotArray[2, 0] == slotArray[2, 1] && slotArray[2, 1] == slotArray[2, 2])
                //    {
                //        Console.WriteLine("You have won on the bottom horizontal line!");
                //        payoutcounter++;
                //    }

                //    else
                //    {
                //        Console.WriteLine("You have lost on the bottom horizontal line!");
                //    }

                //    cash += payoutcounter * WINPAYOUT;
                //}

                //if (i == (int)Bets.Vertical)
                //{
                //    cash -= MAXBET;
                //    int payoutcounter = 0;

                //    if (slotArray[0, 0] == slotArray[1, 0] && slotArray[1, 0] == slotArray[2, 0])
                //    {
                //        Console.WriteLine("You have won on the first vertical line!");
                //        payoutcounter++;
                //    }

                //    else
                //    {
                //        Console.WriteLine("You lost on the first vertical line!");
                //    }

                //    if (slotArray[0, 1] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 1])
                //    {
                //        Console.WriteLine("You have won on the second vertical line!");
                //        payoutcounter++;
                //    }

                //    else
                //    {
                //        Console.WriteLine("You lost on the second vertical line!");
                //    }

                //    if (slotArray[0, 2] == slotArray[1, 2] && slotArray[1, 2] == slotArray[2, 2])
                //    {
                //        Console.WriteLine("You have won on the third vertical line!");
                //        payoutcounter++;
                //    }

                //    else
                //    {
                //        Console.WriteLine("You lost on the third vertical line!");
                //    }

                //    cash += payoutcounter * WINPAYOUT;
                //}

                //if (i == (int)Bets.Diagonals)
                //{
                //    cash -= DIAGONALBET;
                //    int payOutCounter = 0;

                //    if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
                //    {
                //        Console.WriteLine("You have won on the Top Diagonal Line!");
                //        payOutCounter++;
                //    }

                //    else
                //    {
                //        Console.WriteLine("You have lost on the top diagonal Line!");
                //    }

                //    if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
                //    {
                //        Console.WriteLine("You have won on the Bottom Diagonal Line!");
                //        payOutCounter++;
                //    }

                //    else
                //    {
                //        Console.WriteLine("You have Lost on the bottom Diagonal line!");
                //    }

                //    cash += payOutCounter * WINPAYOUT;
                //}

                Console.WriteLine($"Current cash is:{cash}");
                Console.WriteLine("press any key to go again");
                Console.ReadKey();
            }
            while (cash > BROKE);

            Console.WriteLine("you ran out of money!");
            Console.WriteLine("Game over!");
        }
    }
}