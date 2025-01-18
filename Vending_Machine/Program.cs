namespace Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey UserInput = ConsoleKey.None;
            do
            {
                Console.WriteLine("Please press a number to make a selection: \n" +
                    "(1) Beverage \n" +
                    "(2) Snack \n" +
                    "(3) Meal \n" +
                    "(4) Refund \n");
                UserInput = Console.ReadKey().Key;
                Console.Clear();
            } while (true);
        }
    }
}
