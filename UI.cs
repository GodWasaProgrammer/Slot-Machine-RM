namespace Slot_Machine_RM;

public static class UI
{
    public static void WelcomeAndCashPrint(int cash)
    {
        Console.WriteLine("Welcome to our slot machine");
        Console.WriteLine($"you have {cash} to play with");
    }
    public static void PrintSlotArray(int[,] slotArray)
    {
        Console.WriteLine("-------");

        for (int row = 0; row < slotArray.GetLength(0); row++)
        {
            for (int col = 0; col < slotArray.GetLength(1); col++)
            {
                Random rng = new();
                slotArray[row, col] = rng.Next(Data.MINVALUE, Data.MAX_VALUE);
                Console.Write($" {slotArray[row, col]}");
            }

            Console.WriteLine();
        }

        Console.WriteLine("-------");
    }

    public static void PrintWonLines(int WonLines, Data.Bets choice)
    {
        if (WonLines > 0)
        {
            Console.WriteLine($"You have won on the {choice} bet!");

            int localPayout = GameCalculations.PayOut(WonLines);
            Console.WriteLine($"Payout for {WonLines} Lines won is : {localPayout}");
        }

    }

    public static void CurrentCashAndRound(int cash, int round)
    {
        Console.WriteLine($"Current cash is:{cash}");

        Console.WriteLine($"Current round:{round}");
    }
}

