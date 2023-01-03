namespace Slot_Machine_RM
{
    internal class Program
    {
        const int MAXVALUE = 9;
        const int MINVALUE = 0;
        static void Main()
        {
            Random slotArrayRandom = new Random();
            Console.WriteLine("Welcome to our slot machine");
            int[,] slotArray = new int[3, 3] { { 0, 0, 0, }, { 0, 0, 0, }, { 0, 0, 0, } };

            for (int i = 0; i < slotArray.GetLength(0); i++)
            {
                slotArray[i, 0] = slotArrayRandom.Next(MAXVALUE);
                slotArray[i, 1] = slotArrayRandom.Next(MAXVALUE);
                slotArray[i, 2] = slotArrayRandom.Next(MAXVALUE);
            }

            for (int i = 0; i < slotArray.GetLength(0); i++)
            {
                Console.Write($"{slotArray[i, 0]}");

                Console.Write($"{slotArray[i, 1]}");

                Console.WriteLine($"{slotArray[i, 2]}");
            }


        }
    }
}