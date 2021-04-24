using Newtonsoft.Json;
using Rumors.CoffeeMachine.States;
using System;
using System.Collections.Generic;
using System.IO;

namespace Rumors.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Coffees Json File
            JsonManager.JsonCoffeeListMaker();
            // Deserialize Json Coffees File 
            var cofees = JsonManager.DeserializeCoffeeList(); 

            // Create Storage Json File
            JsonManager.JsonStorageMaker(new Storage() {Water = 10, Sugar = 5, Coffee = 1 }); 
            // Deserialize Json Storage File 
            var storage = JsonManager.DeserializeStorage();  


            var coffeeMachine = new CoffeeMachine(new NotEnoughMoneyState(), cofees, storage);
            while (true)
            {
                coffeeMachine.MakeCoffee();
            }
        }
    }
}
