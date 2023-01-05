namespace Slot_Machine_RM
{
    internal class Program
    {
        const int MAXVALUE = 10;

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
                    slotArray[i, 0] = slotArrayRandom.Next(MAXVALUE);
                    slotArray[i, 1] = slotArrayRandom.Next(MAXVALUE);
                    slotArray[i, 2] = slotArrayRandom.Next(MAXVALUE);
                }

                bool topH = false;
                bool midH = false;
                bool btmH = false;
                bool firstV = false;
                bool secondV = false;
                bool thirdV = false;

                Console.WriteLine("Which lines would you like to bet on?");

                bool allBets = false;
                if (cash > 6)
                {
                    Console.WriteLine("Do you wanna bet all lines? (6 dollars) type y");

                    if (Console.ReadLine() == "y")
                    {
                        topH = true;
                        midH = true;
                        btmH = true;
                        firstV = true;
                        secondV = true;
                        thirdV = true;
                        cash -= 6;
                        allBets = true;
                    }

                }

                if (allBets == false)
                {
                    if (cash > 1)
                    {
                        Console.WriteLine("do you wanna bet on top horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            topH = true;
                            cash--;
                        }

                    }

                    if (cash > 1)
                    {
                        Console.WriteLine("do you wanna bet mid horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            midH = true;
                            cash--;
                        }

                    }

                    if (cash > 1)
                    {
                        Console.WriteLine("do you wanna bet bottom horizontal? type y");

                        if (Console.ReadLine() == "y")
                        {
                            btmH = true;
                            cash--;
                        }

                    }

                    if (cash > 1)
                    {
                        Console.WriteLine("do you wanna bet first vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            firstV = true;
                            cash--;
                        }

                    }

                    if (cash > 1)
                    {
                        Console.WriteLine("do you wanna bet second vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            secondV = true;
                            cash--;
                        }

                    }

                    if (cash > 1)
                    {
                        Console.WriteLine("do you wanna bet third vertical? type y");

                        if (Console.ReadLine() == "y")
                        {
                            thirdV = true;
                            cash--;
                        }

                    }

                }

                round++;
                Console.WriteLine($"Current round:{round}");

                Console.WriteLine($"current cash{cash}");

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
                        Console.WriteLine("you have won on the top horizontal line!");
                        cash++;
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
                        cash++;
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
                        cash++;
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
                        cash++;
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
                        cash++;
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
                        Console.WriteLine("You have won on the the third vertical line!");
                        cash++;
                    }

                }

                else if (thirdV)
                {
                    Console.WriteLine("you lost your bet on the third vertical line");
                }

            }
            while (cash > 0);

            Console.WriteLine("you ran out of money!");
            Console.WriteLine("Game over!");

        }
    }
}