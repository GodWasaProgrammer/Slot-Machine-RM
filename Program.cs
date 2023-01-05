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

                Console.WriteLine("Do you wanna bet all lines? (6 dollars) type y");

                if (Console.ReadLine() == "y")
                {
                    topH = true;
                    midH = true;
                    btmH = true;
                    firstV = true;
                    secondV = true;
                    thirdV = true;
                    cash = cash - 6;
                }

                else
                {
                    Console.WriteLine("do you wanna bet on top horizontal? type y");

                    if (Console.ReadLine() == "y")
                    {
                        topH = true;
                        cash = cash - 1;
                    }

                    Console.WriteLine("do you wanna bet mid horizontal? type y");

                    if (Console.ReadLine() == "y")
                    {
                        midH = true;
                        cash = cash - 1;
                    }

                    Console.WriteLine("do you wanna bet bottom horizontal? type y");

                    if (Console.ReadLine() == "y")
                    {
                        btmH = true;
                        cash = cash - 1;
                    }

                    Console.WriteLine("do you wanna bet first vertical? type y");

                    if (Console.ReadLine() == "y")
                    {
                        firstV = true;
                        cash = cash - 1;
                    }

                    Console.WriteLine("do you wanna bet second vertical? type y");

                    if (Console.ReadLine() == "y")
                    {
                        secondV = true;
                        cash = cash - 1;
                    }

                    Console.WriteLine("do you wanna bet third vertical? type y");

                    if (Console.ReadLine() == "y")
                    {
                        thirdV = true;
                        cash = cash - 1;
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
                    Console.WriteLine("the top horizontal line was a winner!");

                    if (topH)
                    {
                        Console.WriteLine("You have won your bet!");
                        cash++;
                        topH = false;
                    }

                }

                else if (topH)
                {
                    Console.WriteLine("you lost your bet on the top horizontal line");
                    topH = false;
                }

                if (slotArray[1, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[1, 2])
                {
                    Console.WriteLine("You have won on the mid horizontal line!!");

                    if (midH)
                    {
                        Console.WriteLine("You have won your bet!");
                        cash++;
                        midH = false;
                    }

                }

                else if (midH)
                {
                    Console.WriteLine("you lost your bet on the mid horizontal line");
                    midH = false;
                }

                if (slotArray[2, 0] == slotArray[2, 1] && slotArray[2, 1] == slotArray[2, 2])
                {
                    Console.WriteLine("You have won on the bottom horizontal line!");

                    if (btmH)
                    {
                        Console.WriteLine("You have won your bet!");
                        cash++;
                        btmH = false;
                    }
                }

                else if (btmH)
                {
                    Console.WriteLine("you lost your bet on bottom horizontal line");
                    btmH = false;
                }

                if (slotArray[0, 0] == slotArray[1, 0] && slotArray[1, 0] == slotArray[2, 0])
                {
                    Console.WriteLine("You have won on the first vertical line");

                    if (firstV)
                    {
                        Console.WriteLine("You have won your bet!");
                        cash++;
                        firstV = false;
                    }

                }

                else if (firstV)
                {
                    Console.WriteLine("you lost your bet on first vertical line");
                    firstV = false;
                }

                if (slotArray[0, 1] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 1])
                {
                    Console.WriteLine("You have won on the second vertical line");

                    if (secondV)
                    {
                        Console.WriteLine("You have won your bet!");
                        cash++;
                        secondV = false;
                    }

                }

                else if (secondV)
                {
                    Console.WriteLine("you lost your bet on second vertical line");
                    secondV = false;
                }

                if (slotArray[0, 2] == slotArray[1, 2] && slotArray[1, 2] == slotArray[2, 2])
                {
                    Console.WriteLine("You have won on the the third vertical line");

                    if (thirdV)
                    {
                        Console.WriteLine("You have won your bet!");
                        cash++;
                        thirdV = false;
                    }

                }

                else if (thirdV)
                {
                    Console.WriteLine("you lost your bet on the third vertical line");
                    thirdV = false;
                }

            }
            while (cash > 0);

            Console.WriteLine("you ran out of money!");
            Console.WriteLine("Game over!");

        }
    }
}