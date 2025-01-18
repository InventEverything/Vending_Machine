using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    internal class VendOptions
    {
        private string[] _Options = { "Cancel", "Beverage", "Snack", "Meal" };
        public VendOptions()
        {

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
    }
}
