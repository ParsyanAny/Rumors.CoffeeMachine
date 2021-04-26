using System;
using System.Collections.Generic;

namespace Rumors.CoffeeMachine.States
{
    class NotEnoughMoneyState : State
    {
        public override void MakeCoffee()
        {
            Console.WriteLine($"Please insert money (50$, 100$, 200$, 500$).\nEnter -1 for finish");
            string entercoin = null;
            while (entercoin != "-1")
            {   
                Console.WriteLine($"Your balance = {_balance}$");
                entercoin = Console.ReadLine();
                _balance += InsertCoin(_balance, entercoin);
            }
            _context.TransitionTo(new NotSelectedState());
        }
        private int InsertCoin(int currentBalance, string entercoin)
        {
            List<int> validCoins = new List<int>() { 50, 100, 200, 500 };
            int coin = 0;

            if (entercoin == "-1") return 0;
            else if (int.TryParse(entercoin, out coin) && validCoins.Contains(coin))
                return coin;
            else
            {
                Console.WriteLine("Please enter valid coin or select -1 for select coffee");
                return 0;
            }
        }
    }
}
