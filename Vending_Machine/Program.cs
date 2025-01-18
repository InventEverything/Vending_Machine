namespace Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey UserInput = ConsoleKey.None;
            VendOptions Vend = new VendOptions();
            do
            {
                Console.WriteLine("Please press a number to make a selection: \n" +
                    "(" + Vend.Number(1) + ") " + Vend.Option(1) + " \n" +
                    "(" + Vend.Number(2) + ") " + Vend.Option(2) + " \n" +
                    "(" + Vend.Number(3) + ") " + Vend.Option(3) + " \n" +
                    "(" + Vend.Number(0) + ") " + Vend.Option(0) + " \n");
                UserInput = Console.ReadKey().Key;
                Console.Clear();
            } while (true);
        }
    }
}
