using System.Data;

namespace Slot_Machine_RM
{
    public class Program
    {
        static void Main()
        {
            int cash;
            int round = 0;

            int[,] slotArray = new int[3, 3];

            cash = Data.ATMREFILL;

            UI.WelcomeAndCashPrint(cash);

            do
            {
                int choiceInt;
                choiceInt = UI.InputVerification();
                Enums.Bets choice = (Enums.Bets)choiceInt;

                cash -= GameLogic.ReturnCostOfBet(choice);

                UI.FillSlotArray(slotArray);

                UI.PrintSlotArray(slotArray);

                int amountOfWonLines = GameLogic.CalculateWinningLines(slotArray, choice);

                UI.PrintWonLines(amountOfWonLines, choice);

                cash += GameLogic.PayOut(amountOfWonLines);

                round++;

                UI.CurrentCashAndRound(cash, round);
            }
            while (cash > Data.BROKE);

            UI.GameLost();
        }

    }
}

