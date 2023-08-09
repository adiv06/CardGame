using System;

namespace CardGame
{
    public static class HoldembettingSystem
    {
        private static int playerBalance = 10000, computerBalance = 10000, potBalance, currentBet, currentPlayerBet, currentComputerBet;
        private static bool allIn;

        public static void moneyToWinner(int moneyAllocation)
        {
            switch (moneyAllocation)
            {
                case 0:
                    playerBalance += potBalance / 2;
                    computerBalance += potBalance / 2;
                    potBalance = 0;
                    break;
                case 1:
                    playerBalance += potBalance;
                    potBalance = 0;
                    break;
                case 2:
                    computerBalance += potBalance;
                    potBalance = 0;
                    break;
            }
            potBalance = 0;
        }

        public static void playerBet()
        {
            if (playerBalance - currentPlayerBet >= 0)
            {
                playerBalance -= currentBet;
                potBalance += currentBet;
                currentPlayerBet += currentBet;
            }
            resetBet();
        }

        public static void computerBet()
        {
            if (computerBalance - currentComputerBet >= 0)
            {
                computerBalance -= currentBet;
                potBalance += currentBet;
                currentComputerBet += currentBet;
            }
            resetBet();
        }

        public static void betAdd(int x)
        {
            currentBet += x;
        }
        public static void resetBet()
        {
            currentBet = 0;
        }
        public static void matchBet(bool pTurn)
        {
            if (currentComputerBet != 0 && pTurn)
            {
                if (currentBet + Math.Abs(currentComputerBet - currentPlayerBet) != currentComputerBet)
                {
                    currentBet += Math.Abs(currentComputerBet - currentPlayerBet);
                }

            }
            else if (currentPlayerBet != 0 && !pTurn)
            {
                currentBet += Math.Abs(currentPlayerBet - currentComputerBet) / 2;
            }
        }

        public static void resetFromFold()
        {
            resetFromNewCard();
            resetBet();
            potBalance = 0;
        }
        public static bool whenToDeal()
        {
            if (currentComputerBet == currentPlayerBet)
            {
                return true;
            }
            else return false;
        }
        public static void resetFromNewCard()
        {
            currentPlayerBet = 0;
            currentComputerBet = 0;
        }
        public static int getPotBalance()
        {
            return potBalance;
        }
        public static int getCurrentPlayerBet()
        {
            return currentPlayerBet;
        }
        public static int getCurrentComputerBet()
        {
            return currentComputerBet;
        }
        public static int getComputerBalance()
        {
            return computerBalance;
        }
        public static int getPlayerBalance()
        {
            return playerBalance;
        }

        public static int getCurrentBet()
        {
            return currentBet;
        }



    }
}
