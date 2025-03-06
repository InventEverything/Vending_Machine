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
        private List<Product> _Product;

        public VendOptions(string inventory)
        {
            _Product = JsonConvert.DeserializeObject<List<Product>>(inventory);
        }
        public string Json()
        {
            return JsonConvert.SerializeObject(_Product, Newtonsoft.Json.Formatting.Indented);
        }
        //returns choice associated with the input value
        public string Option(int choice)
        {
            return _Product.ToArray()[choice].Name;
        }
        //returns the number of choices
        public int Count()
        {
            return _Product.Count;
        }
        public int Remaining(int choice)
        {
            return  _Product[choice].Count;
        }
        public int VendItem(int choice)
        {
            if (_Product[choice].Count >= 1)
                _Product[choice].Count--;
            return Remaining(choice);
        }
        public void Restock()
        {
            for(int i =0;  i < _Product.Count; i++)
            {
                _Product[i].Count++;
            }
        }
    }
}
