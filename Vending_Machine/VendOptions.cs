using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    internal class VendOptions
    {
        private string[] Options = { "Cancel", "Beverage", "Snack", "Meal" };
        public VendOptions()
        {

        }
        public string Number(int choice)
        {
            return choice.ToString();
        }
        public string Option(int choice)
        {
            return Options[choice];
        }
    }
}
