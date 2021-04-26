using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Rumors.CoffeeMachine
{
    public class JsonManager
    {
        private static readonly string _coffeePath = @"D:\coffeesJson";
        private static readonly string _storagePath = @"D:\storageJson";

        #region Coffee part
        private static List<Coffee> CoffeeListMaker()
        {
            List<Coffee> coffeeList = new List<Coffee>();
            for (int i = 1; i <= 10; i++)
            {
                coffeeList.Add(new Coffee()
                {
                    Id = i,
                    Name = $"Coffee{i}",
                    Price = i * 10,
                    CoffeePortion = (double)i / 10,
                    WaterPortion = (double)i / 10,
                    SugarPortion = (double)i / 10
                });
            }
            return coffeeList;
        }
        public static void JsonCoffeeListMaker()
            => File.WriteAllText(_coffeePath, JsonConvert.SerializeObject(CoffeeListMaker(), Formatting.Indented));
        public static List<Coffee> DeserializeCoffeeList()
            =>JsonConvert.DeserializeObject<List<Coffee>>(File.ReadAllText(_coffeePath)); 
        #endregion
        #region Storage part
        public static void JsonStorageMaker(Storage storage) 
            => File.WriteAllText(_storagePath, JsonConvert.
                SerializeObject(storage, Formatting.Indented));
        public static Storage DeserializeStorage()
        => JsonConvert.DeserializeObject<Storage>(File.ReadAllText(_storagePath));
        #endregion
    }
}
