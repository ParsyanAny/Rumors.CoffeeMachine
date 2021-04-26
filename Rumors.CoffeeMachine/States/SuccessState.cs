using System;

namespace Rumors.CoffeeMachine.States
{
    class SuccessState : State
    {
        public override void MakeCoffee()
        {
            if (_balance != 0)
            {
                Console.WriteLine($"Your coffee is ready! You have {_balance}$ in your balance! " +
                    $"\n Enter 0 for take change or 1 for new coffee");
                string select = Console.ReadLine();

                if (select == "0")
                {
                    Console.WriteLine($"Here is your change! {_balance}$!");
                    ClearHistory();
                }
                else if (select == "1")
                    _context.TransitionTo(new NotSelectedState());
                else
                    Console.WriteLine("Please enter valid number");
            }
            else
            {
                Console.WriteLine("Your coffee is ready!");
                ClearHistory();
            }
        }
    }
}
