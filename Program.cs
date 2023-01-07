namespace Slot_Machine_RM
{
    internal class Program
    {
        const int MAXVALUE = 4;
        const int MINVALUE = 1;
        const int MAXBET = 8;
        const int BROKE = 0;
        const int WINPAYOUT = 2;

        static void Main()
        {
            Console.WriteLine("Welcome to our slot machine");

            int round = 0;
            int cash = 100;

            do
            {
                bool topH = false;
                bool midH = false;
                bool btmH = false;
                bool firstV = false;
                bool secondV = false;
                bool thirdV = false;
                bool allBets = false;
                bool diagonalTop = false;
                bool diagonalBtm = false;

                Console.WriteLine("Which lines would you like to bet on?");

                if (cash > MAXBET)
                {
                    Console.WriteLine($"Do you wanna bet all lines? ({MAXBET} dollars) type y");

                    if (Console.ReadLine() == "y")
                    {
                        topH = true;
                        midH = true;
                        btmH = true;
                        firstV = true;
                        secondV = true;
                        thirdV = true;
                        allBets = true;
                        diagonalTop = true;
                        diagonalBtm = true;
                        cash -= MAXBET;

                    }

                }

                if (allBets == false)
                {
                    if (cash > BROKE)
                    {
                        Console.WriteLine("do you wanna bet on top horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            topH = true;
                            cash--;
                        }

                    }

                    if (cash > BROKE)
                    {
                        Console.WriteLine("do you wanna bet mid horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            midH = true;
                            cash--;
                        }

                    }

                    if (cash > BROKE)
                    {
                        Console.WriteLine("do you wanna bet bottom horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            btmH = true;
                            cash--;
                        }

                    }

                    if (cash > BROKE)
                    {
                        Console.WriteLine("do you wanna bet first vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            firstV = true;
                            cash--;
                        }

                    }

                    if (cash > BROKE)
                    {
                        Console.WriteLine("do you wanna bet second vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            secondV = true;
                            cash--;
                        }

                    }

                    if (cash > BROKE)
                    {
                        Console.WriteLine("do you wanna bet third vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            thirdV = true;
                            cash--;
                        }

                    }

                    if (cash > BROKE)
                    {
                        Console.WriteLine("do you wanna bet on the top diagonal?");

                        if (Console.ReadLine() == "y")
                        {
                            diagonalTop = true;
                            cash--;
                        }
                    }

                    if (cash > BROKE)
                    {
                        Console.WriteLine("do you wanna bet on the bottom diagonal?");

                        if (Console.ReadLine() == "y")
                        {
                            diagonalBtm = true;
                            cash--;
                        }
                    }

                }

                round++;
                Console.WriteLine($"Current round:{round}");

                Console.WriteLine($"current cash {cash}");

                Console.WriteLine("-------");

                Random slotArrayRandom = new();
                int[,] slotArray = new int[3, 3];

                for (int row = 0; row < slotArray.GetLength(0); row++)
                {
                    for (int col = 0; col < slotArray.GetLength(1); col++)
                    {
                        slotArray[row, col] = slotArrayRandom.Next(MINVALUE, MAXVALUE);
                        Console.Write($" {slotArray[row, col]}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("-------");

                if (slotArray[0, 0] == slotArray[0, 1] && slotArray[0, 1] == slotArray[0, 2])
                {
                    if (topH)
                    {
                        Console.WriteLine("you have won on the top horizontal line!");
                        cash += WINPAYOUT;
                    }

                }

                else if (topH)
                {
                    Console.WriteLine("you lost your bet on the top horizontal line");
                }

                if (slotArray[1, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[1, 2])
                {
                    if (midH)
                    {
                        Console.WriteLine("You have won on the mid horizontal line!");
                        cash += WINPAYOUT;
                    }

                }

                else if (midH)
                {
                    Console.WriteLine("you lost your bet on the mid horizontal line");
                }

                if (slotArray[2, 0] == slotArray[2, 1] && slotArray[2, 1] == slotArray[2, 2])
                {
                    if (btmH)
                    {
                        Console.WriteLine("You have won on the bottom horizontal line!");
                        cash += WINPAYOUT;
                    }

                }

                else if (btmH)
                {
                    Console.WriteLine("you lost your bet on bottom horizontal line");
                }

                if (slotArray[0, 0] == slotArray[1, 0] && slotArray[1, 0] == slotArray[2, 0])
                {
                    if (firstV)
                    {
                        Console.WriteLine("You have won on the first vertical line!");
                        cash += WINPAYOUT;
                    }

                }

                else if (firstV)
                {
                    Console.WriteLine("you lost your bet on first vertical line");
                }

                if (slotArray[0, 1] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 1])
                {
                    if (secondV)
                    {
                        Console.WriteLine("You have won on the second vertical line!");
                        cash += WINPAYOUT;
                    }

                }

                else if (secondV)
                {
                    Console.WriteLine("you lost your bet on second vertical line");
                }

                if (slotArray[0, 2] == slotArray[1, 2] && slotArray[1, 2] == slotArray[2, 2])
                {
                    if (thirdV)
                    {
                        Console.WriteLine("You have won on the third vertical line!");
                        cash += WINPAYOUT;
                    }

                }

                else if (thirdV)
                {
                    Console.WriteLine("you lost your bet on the third vertical line");
                }

                if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
                {
                    if (diagonalTop)
                    {
                        Console.WriteLine("You have won on the top diagonal line!");
                        cash += WINPAYOUT;
                    }

                }

                else if (diagonalTop)
                {
                    Console.WriteLine("you lost your bet on the top diagonal line");
                }

                if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
                {
                    if (diagonalBtm)
                    {
                        Console.WriteLine("You have won on the the bottom diagonal line!");
                        cash += WINPAYOUT;
                    }

                }

                else if (diagonalBtm)
                {
                    Console.WriteLine("you lost your bet on the bottom diagonal line");
                }

                Console.WriteLine($"Your cash after round {round} is : {cash}");

            }
            while (cash > 0);

            Console.WriteLine("you ran out of money!");
            Console.WriteLine("Game over!");
        }
    }
}