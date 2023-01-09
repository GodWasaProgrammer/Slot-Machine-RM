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
            Horizontals = 1,
            Verticals = 2,
            Diagonals = 3,
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

                Int32.TryParse(Console.ReadLine(), out i);

                if (i == (int)Bets.Horizontals)
                {
                    cash = cash - MAXBET;
                }

                if (i == (int)Bets.Verticals)
                {
                    cash = cash - MAXBET;
                }

                if (i == (int)Bets.Diagonals)
                {
                    cash = cash - DIAGONALBET;
                }

                round++;
                Console.WriteLine($"Current round:{round}");

                Console.WriteLine("-------");
                int[,] slotArray = new int[3, 3];
                bool betIsWon = false;
                int amountOfWonLines = 0;

                for (int row = 0; row < slotArray.GetLength(0); row++)
                {

                    for (int col = 0; col < slotArray.GetLength(1); col++)
                    {
                        Random slotArrayRandom = new();
                        slotArray[row, col] = slotArrayRandom.Next(MINVALUE, MAXVALUE);
                        Console.Write($" {slotArray[row, col]}");


                        if (i == (int)Bets.Horizontals)
                        {
                            if (slotArray[row, 0] == slotArray[row, 1] && slotArray[row, 1] == slotArray[row, 2])
                            {
                                betIsWon = true;
                                amountOfWonLines++;
                            }

                        }
                        if (i == (int)Bets.Verticals)
                        {
                            if (slotArray[0, col] == slotArray[1, col] && slotArray[1, col] == slotArray[2, col])
                            {
                                betIsWon = true;
                                amountOfWonLines++;
                            }

                        }

                    }

                    Console.WriteLine();

                    if (i == (int)Bets.Diagonals)
                    {
                        if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
                        {
                            betIsWon = true;
                            amountOfWonLines++;
                        }

                        if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
                        {
                            betIsWon = true;
                            amountOfWonLines++;
                        }

                    }

                }

                Console.WriteLine("-------");

                if (betIsWon)
                {
                    int roundPayOut = 0;
                    if (i == (int)Bets.Horizontals)
                    {
                        Console.WriteLine("You have won on the horizontal bet!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (i == (int)Bets.Verticals)
                    {
                        Console.WriteLine("You have won the vertical bet!");
                        roundPayOut = amountOfWonLines * WINPAYOUT;
                    }

                    if (i == (int)Bets.Diagonals)
                    {
                        Console.WriteLine("You have won the diagonal bet!");
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