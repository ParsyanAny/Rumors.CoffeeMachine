using System;
using System.Linq;

namespace Rumors.CoffeeMachine.States
{
    class NotInStockState : State
    {
        public override void MakeCoffee()
        {
            Coffee c = _context.Coffees.First(p => p.Id == _id);
            if (!InStock(c))
            {
                _context.TransitionTo(new NotSelectedState());
                Console.WriteLine("Sorry, we don't have this one, but you can select other coffee \nEnter 0 for get back money");
            }
            else
            {
                _balance -= c.Price;
                _context.Storage.Coffee -= c.CoffeePortion;
                _context.Storage.Sugar -= c.SugarPortion;
                _context.Storage.Water -= c.WaterPortion;
                _context.TransitionTo(new SuccessState());
            }
        }
        private bool InStock(Coffee c)
        {
            if (c.SugarPortion <= _context.Storage.Sugar 
                && c.WaterPortion <= _context.Storage.Water 
                && c.CoffeePortion <= _context.Storage.Coffee)
            {
                return true;
            }
            return false;
        }
    }
}
