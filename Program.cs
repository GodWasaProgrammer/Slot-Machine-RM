namespace Slot_Machine_RM
{
    internal class Program
    {
        const int MAXVALUE = 9;

        static void Main()
        {
            Random slotArrayRandom = new();
            Console.WriteLine("Welcome to our slot machine");
            int[,] slotArray = new int[3, 3] { { 0, 0, 0, }, { 0, 0, 0, }, { 0, 0, 0, } };
            int round = 0;
            do
            {
                for (int i = 0; i < slotArray.GetLength(0); i++)
                {
                    slotArray[i, 0] = slotArrayRandom.Next(MAXVALUE);
                    slotArray[i, 1] = slotArrayRandom.Next(MAXVALUE);
                    slotArray[i, 2] = slotArrayRandom.Next(MAXVALUE);
                }



                round++;
                Console.WriteLine($"Current round:{round}");
                Console.WriteLine("-------");

                for (int i = 0; i < slotArray.GetLength(0); i++)


                {

                    Console.Write($" {slotArray[i, 0]}");

                    Console.Write($" {slotArray[i, 1]}");

                    Console.WriteLine($" {slotArray[i, 2]}");
                }

                Console.WriteLine("-------");

                if (slotArray[1, 0] == slotArray[1, 1] && slotArray[1, 1] == slotArray[1, 2])
                {
                    Console.WriteLine("You have won on the mid horizontal line!!");
                }

                if (slotArray[0, 0] == slotArray[0, 1] && slotArray[0, 1] == slotArray[0, 2])
                {
                    Console.WriteLine("You have won on the top horizontal line!");
                }

                if (slotArray[2, 0] == slotArray[2, 1] && slotArray[2, 1] == slotArray[2, 2])
                {
                    Console.WriteLine("You have won on the bottom horizontal line!");
                }

                if (slotArray[0, 0] == slotArray[1, 0] && slotArray[1, 0] == slotArray[2, 0])
                {
                    Console.WriteLine("You have won on the first vertical line");
                }

                if (slotArray[0, 1] == slotArray[1, 1] && slotArray[1, 1] == slotArray[2, 1])
                {
                    Console.WriteLine("You have won on the second vertical line");
                }

                if (slotArray[0, 2] == slotArray[1, 2] && slotArray[1, 2] == slotArray[2, 2])
                {
                    Console.WriteLine("You have won on the the third vertical line");
                }

                Console.WriteLine("press any key to roll again");
                Console.ReadKey();
            }
            while (true);

        }
    }
}