﻿namespace Slot_Machine_RM
{
    public static class GameLoop
    {
        public static void Game()
        {
            UI.WelcomeAndCashPrint(Data.cash);
            Data.cash = Data.ATMREFILL;
            do
            {

                Data.choiceInt = GameCalculations.InputVerification();
                Data.Bets choice = (Data.Bets)Data.choiceInt;

                Data.cash -= GameCalculations.ReturnCostOfBet(choice);

                UI.PrintSlotArray(Data.slotArray);

                int amountOfWonLines = GameCalculations.CalculateWinningLines(Data.slotArray, choice);

                UI.PrintWonLines(amountOfWonLines, choice);

                Data.cash += GameCalculations.PayOut(amountOfWonLines);

                Data.round++;

                UI.CurrentCashAndRound(Data.cash, Data.round);
            }
            while (Data.cash > Data.BROKE);

            Console.WriteLine("you ran out of money!");

            Console.WriteLine("Game over!");
        }
    }
}
