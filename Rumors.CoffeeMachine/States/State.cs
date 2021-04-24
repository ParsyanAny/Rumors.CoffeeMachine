namespace Rumors.CoffeeMachine.States
{ 
    abstract class State
    {
        protected CoffeeMachine _context;
        protected static int _balance;
        protected static int _id;

        public void SetContext(CoffeeMachine context) => _context = context;
        public abstract void MakeCoffee();
    }
}
