using System;

namespace Rumors.CoffeeMachine.States
{ 
    abstract class State
    {
        protected CoffeeMachine _context;
        protected static int _balance;
        protected static int _id;

        public void SetContext(CoffeeMachine context) => _context = context;
        public abstract void MakeCoffee();

        protected void ClearHistory()
        {
            Console.Read();
            Console.Clear();
            _id = 0;
            _balance = 0;
            _context.TransitionTo(new NotEnoughMoneyState());
        }
        protected void PrintCoffeeList()
        {
            foreach (var item in _context.Coffees)
            {
                Console.WriteLine($"{item.Id}) {item.Name} {item.Price}$ " +
                    $"Sugar/Water/Coffee {item.SugarPortion}:{item.WaterPortion}:{item.CoffeePortion}");
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
