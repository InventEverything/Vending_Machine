using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Vending_Machine
{
    public class VendOptions
    {
        private string[] _Options = { "Cancel", "Beverage", "Snack", "Meal", "Medicine", "Supply", "Resource", "Dog Toy"};
        private IEnumerable<string> _InventoryByLine;
        private string[] _Inventory;
        private int[] _InventoryCount;
        int i = 0;
        private Product[] _Product;
        public VendOptions(string inventory)
        {
            _InventoryByLine = File.ReadAllLines(inventory);
            _Inventory = new string[_Options.Length];
            _InventoryCount = new int[_Options.Length];
            foreach (var item in _InventoryByLine)
            {
                _Inventory[i] = _Options[i] + ":" + item.Split(":")[0];
                _InventoryCount[i] = int.Parse(item.Split(":")[0]);
                i++;
            }
            _Product = new Product[_Options.Length];
            for (int i = 0; i < _Options.Length; i++)
            {
                _Product[i] = new Product
                {
                    Name = _Options[i],
                    Count = _InventoryCount[i]
                };
            }
            Json(_Product);
        }
        public void Json(Product[] product)
        {
            string json = JsonConvert.SerializeObject(product, Newtonsoft.Json.Formatting.Indented);
            //Console.WriteLine(json);
        }
        //returns the input value as a string
        public string Number(int choice)
        {
            return choice.ToString();
        }
        //returns choice associated with the input value
        public string Option(int choice)
        {
            return _Options[choice];
        }
        //returns the number of choices
        public int Count()
        {
            return _Options.Length;
        }
        public int Remaining(int choice)
        {
            return _InventoryCount[choice];
        }
        public int VendItem(int choice)
        {
            if(_InventoryCount[choice]>=1)
            _InventoryCount[choice]--;
            return Remaining(choice);
        }
        public void Restock()
        {
            for(int i =0;  i < _InventoryCount.Length; i++)
            {
                _InventoryCount[i]++;
            }
        }
    }
}
