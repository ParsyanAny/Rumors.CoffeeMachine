using System;
using System.Linq;

namespace Rumors.CoffeeMachine.States
{
    class NotSelectedState : State
    {
        public override void MakeCoffee()
        {
            Console.WriteLine("Please select a coffee");
            _context.PrintCoffees();
            _id = -1;
            string coffeeId = Console.ReadLine();
            while (_id == -1)
            {
                if (int.TryParse(coffeeId, out _id))
                {
                    if (_id > 0 && _id < 11)
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
                    Console.WriteLine("Please select valid number");
            }
        }
    }
}
