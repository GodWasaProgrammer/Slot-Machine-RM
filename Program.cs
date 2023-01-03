namespace Slot_Machine_RM
{
    internal class Program
    {
        const int MAXVALUE = 9;
        const int MINVALUE = 0;
        static void Main()
        {
            Console.WriteLine("Welcome to our slot machine");
            int[,] slotArray = new int[3, 3] { { 0, 0, 0, }, { 0, 0, 0, }, { 0, 0, 0, } };

            Random slotArrayRandom = new Random();
            foreach (int i in slotArray)
            {

                slotArray[i, i] = slotArrayRandom.Next(MAXVALUE);
            }

            foreach (int i in slotArray)
            {
                Console.Write(i);
            }
        }
    }
}