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
                if (CheckValidInput(UserInput, Vend))
                {
                    Console.Clear();
                    if (UserInput == ConsoleKey.D0)
                    {
                        Console.WriteLine("Please come again!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Here is your " + Vend.Option(int.Parse(((char)UserInput).ToString())) + "\n");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input\n");
                }
            } while (true);
            static bool CheckValidInput(ConsoleKey input, VendOptions quantity)
            {
                int number;
                if (int.TryParse(((char)input).ToString(), out number))
                {
                    if (number <= quantity.Count() - 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
