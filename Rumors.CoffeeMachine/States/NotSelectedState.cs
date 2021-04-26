﻿using System;
using System.Linq;

namespace Rumors.CoffeeMachine.States
{
    class NotSelectedState : State
    {
        public override void MakeCoffee()
        {
            Console.WriteLine("\n\nPlease select a coffee or enter 0 for get back money");
            PrintCoffeeList();
            _id = -1;
            string coffeeId = Console.ReadLine();
            while (_id == -1)
            {
                if (int.TryParse(coffeeId, out _id))
                {
                    if (_id == 0) 
                    {
                        Console.WriteLine($"Here is your money! {_balance}$");
                        ClearHistory();
                    }
                    else if (_id > 0 && _id < 11)
                    {
                        Coffee c = _context.Coffees.First(p=>p.Id == _id);
                        if(c.Price<= _balance)
                        {
                        _context.TransitionTo(new NotInStockState());
                        }
                        else
                        _context.TransitionTo(new NotEnoughMoneyState());
                    }
                    break;
                }
                else
                    Console.WriteLine("Please enter valid number");
            }
        }
    }
}
