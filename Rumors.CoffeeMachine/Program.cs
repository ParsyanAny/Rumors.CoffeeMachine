using Rumors.CoffeeMachine.States;

namespace Rumors.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create CoffeeList Json File
            JsonManager.JsonCoffeeListMaker();
            // Deserialize Json CoffeeList File 
            var coffee = JsonManager.DeserializeCoffeeList(); 

            // Create Storage Json File
            JsonManager.JsonStorageMaker(new Storage() {Water = 10, Sugar = 5, Coffee = 1 }); 
            // Deserialize Json Storage File 
            var storage = JsonManager.DeserializeStorage();  


            var coffeeMachine = new CoffeeMachine(new NotEnoughMoneyState(), coffee, storage);
            while (true)
            {
                coffeeMachine.MakeCoffee();
            }
        }
    }
}
