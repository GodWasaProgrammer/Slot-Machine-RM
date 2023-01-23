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
                Console.Write($" {slotArray[row, col]}");
            }

            Console.WriteLine();
        }

        Console.WriteLine("-------");
    }

    public static int InputVerification()
    {
        var names = Enum.GetNames(typeof(Bets)); 

        for (int i = 1; i < names.Length; i++)
        {
            Console.WriteLine($"{i} {names[i]},");
        }

        Console.WriteLine("Insert the number of the line you would like to play.");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input) == false)
            {
                Console.WriteLine("Nein Nein Nein! Das ist not a numbah!");
            }

            if (input < 1 || input > 11)
            {
                Console.WriteLine("between 1 and 11");
                continue;
            }

            return input;
        }

    }

    public static void PrintWonLines(int WonLines, Bets choice, int PayOut)
    {
        if (WonLines > 0)
        {
            Console.WriteLine($"You have won on the {choice} bet!");

            Console.WriteLine($"Payout for {WonLines} Lines won is : {PayOut}");
        }
        else
        {
            Console.WriteLine("Sorry my man, you lost your bet!");
        }

    }

    public static void CurrentCashAndRound(int cash, int round)
    {
        Console.WriteLine($"Current cash is:{cash}");

        Console.WriteLine($"Current round:{round}");
    }

    public static void GameLost()
    {
        Console.WriteLine("you ran out of money!");

        Console.WriteLine("Game over!");
    }

}

