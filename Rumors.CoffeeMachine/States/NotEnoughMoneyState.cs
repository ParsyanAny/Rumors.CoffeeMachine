using System;
using System.Collections.Generic;

namespace Rumors.CoffeeMachine.States
{
    class NotEnoughMoneyState : State
    {
        public override void MakeCoffee()
        {
            Console.WriteLine($"Please insert money. We enter 50, 100, 200, 500. Enter -1 for finish");
            string entercoin = null;
            while (entercoin != "-1")
            {   
                Console.WriteLine($"Your balance = {_balance}");
                entercoin = Console.ReadLine();
                _balance += InsertCoin(_balance, entercoin);
            }
            _context.TransitionTo(new NotSelectedState());
        }
        private int InsertCoin(int currentBalance, string entercoin)
        {
            List<int> coins = new List<int>() { 50, 100, 200, 500 };
            int coin = 0;

            if (entercoin == "-1") return 0;
            else if (int.TryParse(entercoin, out coin) && coins.Contains(coin))
                return coin = int.Parse(entercoin);
            Console.WriteLine("Please enter valid coins or select -1 for select coffee");
            return 0;
        }
    }
}
