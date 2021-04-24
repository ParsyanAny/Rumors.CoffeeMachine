using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Rumors.CoffeeMachine
{
    public class JsonManager
    {
        private static readonly string _cofeePath = @"D:\coffeesJson";
        private static readonly string _storagePath = @"D:\storageJson";

        #region Coffees
        private static List<Coffee> CoffeeListMaker()
        {
            List<Coffee> coffees = new List<Coffee>();
            for (int i = 1; i <= 10; i++)
            {
                coffees.Add(new Coffee()
                {
                    Id = i,
                    Name = $"Coffee{i}",
                    Price = i * 10,
                    CoffeePortion = (double)i / 10,
                    WaterPortion = (double)i / 10,
                    SugarPortion = (double)i / 10
                });
            }
            return coffees;
        }
        public static void JsonCoffeeListMaker()
            => File.WriteAllText(_cofeePath, JsonConvert.SerializeObject(CoffeeListMaker(), Formatting.Indented));
        public static List<Coffee> DeserializeCoffeeList()
            =>JsonConvert.DeserializeObject<List<Coffee>>(File.ReadAllText(_cofeePath)); 
        #endregion
        #region Storage 
        public static void JsonStorageMaker(Storage storage) 
            => File.WriteAllText(_storagePath, JsonConvert.
                SerializeObject(storage, Formatting.Indented));
        public static Storage DeserializeStorage()
        {
            string jsonStorage = File.ReadAllText(_storagePath);
            return JsonConvert.DeserializeObject<Storage>(jsonStorage);
        }
        #endregion
    }
}
