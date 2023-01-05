namespace Slot_Machine_RM
{
    internal class Program
    {
        const int MAXVALUE = 4;
        const int MINVALUE = 1;

        static void Main()
        {
            Console.WriteLine("Welcome to our slot machine");

            Random slotArrayRandom = new();
            int[,] slotArray = new int[3, 3] { { 0, 0, 0, }, { 0, 0, 0, }, { 0, 0, 0, } };
            int round = 0;
            int cash = 100;

            do
            {
                for (int i = 0; i < slotArray.GetLength(0); i++)
                {
                    slotArray[i, 0] = slotArrayRandom.Next(MINVALUE,MAXVALUE);
                    slotArray[i, 1] = slotArrayRandom.Next(MINVALUE,MAXVALUE);
                    slotArray[i, 2] = slotArrayRandom.Next(MINVALUE,MAXVALUE);
                }

                bool topH = false;
                bool midH = false;
                bool btmH = false;
                bool firstV = false;
                bool secondV = false;
                bool thirdV = false;
                bool allBets = false;
                bool diagonalTop = false;
                bool diagonalBtm = false;
                int cashUpOrDown = cash;

                Console.WriteLine("Which lines would you like to bet on?");

                if (cash > 6)
                {
                    Console.WriteLine("Do you wanna bet all lines? (8 dollars) type y");

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
                        cash -= 8;
                    }

                }

                if (allBets == false)
                {
                    if (cash > 0)
                    {
                        Console.WriteLine("do you wanna bet on top horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            topH = true;
                            cash--;
                        }

                    }

                    if (cash > 0)
                    {
                        Console.WriteLine("do you wanna bet mid horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            midH = true;
                            cash--;
                        }

                    }

                    if (cash > 0)
                    {
                        Console.WriteLine("do you wanna bet bottom horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            btmH = true;
                            cash--;
                        }

                    }

                    if (cash > 0)
                    {
                        Console.WriteLine("do you wanna bet first vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            firstV = true;
                            cash--;
                        }

                    }

                    if (cash > 0)
                    {
                        Console.WriteLine("do you wanna bet second vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            secondV = true;
                            cash--;
                        }

                    }

                    if (cash > 0)
                    {
                        Console.WriteLine("do you wanna bet third vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            thirdV = true;
                            cash--;
                        }

                    }

                    if (cash > 0)
                    {
                        Console.WriteLine("do you wanna bet on the top diagonal?");

                        if (Console.ReadLine() == "y")
                        {
                            diagonalTop = true;
                            cash--;
                        }
                    }

                    if (cash > 0)
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

                for (int i = 0; i < slotArray.GetLength(0); i++)
                {
                    Console.Write($" {slotArray[i, 0]}");

                    Console.Write($" {slotArray[i, 1]}");

                    Console.WriteLine($" {slotArray[i, 2]}");
                }

                Console.WriteLine("-------");

                if (slotArray[0, 0] == slotArray[0, 1] && slotArray[0, 1] == slotArray[0, 2])
                {
                    if (topH)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("you have won on the top horizontal line!");
                        cash += 2;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                else if (topH)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lost your bet on the top horizontal line");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (slotArray[1, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[1, 2])
                {
                    if (midH)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have won on the mid horizontal line!");
                        cash += 2;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                else if (midH)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lost your bet on the mid horizontal line");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (slotArray[2, 0] == slotArray[2, 1] && slotArray[2, 1] == slotArray[2, 2])
                {
                    if (btmH)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have won on the bottom horizontal line!");
                        cash += 2;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                else if (btmH)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lost your bet on bottom horizontal line");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (slotArray[0, 0] == slotArray[1, 0] && slotArray[1, 0] == slotArray[2, 0])
                {
                    if (firstV)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have won on the first vertical line!");
                        cash += 2;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                else if (firstV)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lost your bet on first vertical line");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (slotArray[0, 1] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 1])
                {
                    if (secondV)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have won on the second vertical line!");
                        cash += 2;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                else if (secondV)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lost your bet on second vertical line");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (slotArray[0, 2] == slotArray[1, 2] && slotArray[1, 2] == slotArray[2, 2])
                {
                    if (thirdV)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have won on the third vertical line!");
                        cash += 2;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                else if (thirdV)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lost your bet on the third vertical line");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (slotArray[0, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 2])
                {
                    if (diagonalTop)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have won on the top diagonal line!");
                        cash += 2;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                else if (diagonalTop)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lost your bet on the top diagonal line");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (slotArray[2, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[0, 2])
                {
                    if (diagonalBtm)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have won on the the bottom diagonal line!");
                        cash += 2;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                else if (diagonalBtm)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you lost your bet on the bottom diagonal line");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                if (cash > cashUpOrDown)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your cash after round {round} is : {cash}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Your cash after round {round} is : {cash}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            while (cash > 0);

            Console.WriteLine("you ran out of money!");
            Console.WriteLine("Game over!");
        }
    }
}