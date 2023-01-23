namespace Slot_Machine_RM
{
    public class Program
    {
        static void Main()
        {
            
            int round = 0;

            int[,] slotArray = new int[3, 3];

            int cash = Data.ATMREFILL;

            UI.WelcomeAndCashPrint(cash);

            do
            {
                
                int choiceInt = UI.InputVerification();
                Bets choice = (Bets)choiceInt;

                cash -= GameLogic.ReturnCostOfBet(choice);

                GameLogic.FillSlotArray(slotArray);

                UI.PrintSlotArray(slotArray);

                int amountOfWonLines = GameLogic.CalculateWinningLines(slotArray, choice);
                var PayOut = GameLogic.PayOut(amountOfWonLines);
                cash += PayOut;
                UI.PrintWonLines(amountOfWonLines, choice,PayOut);

                round++;

                UI.CurrentCashAndRound(cash, round);
            }
            while (cash > Data.BROKE);

            UI.GameLost();
        }

    }
}

