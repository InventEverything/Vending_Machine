namespace Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey UserInput = ConsoleKey.None;
            VendOptions Vend = new VendOptions();
            string FilePath = GenerateFilePath("VendingReport.txt");
            string Inventory = GenerateFilePath("Inventory.txt");
            int SoldCount = 0;

            WriteHeadOfReport(FilePath);

            do
            {
                Console.WriteLine("Please press a number to make a selection: \n");

                for (int i = 1; i < (Vend.Count()); i++)
                {
                    Console.WriteLine("(" + Vend.Number(i) + ") " + Vend.Option(i));
                }

                Console.WriteLine("(" + Vend.Number(0) + ") " + Vend.Option(0));

                UserInput = Console.ReadKey(true).Key;
                //valid response
                if (CheckValidInput(UserInput, Vend))
                {
                    Console.Clear();
                    if (UserInput == ConsoleKey.D0)
                    {
                        WriteEndOfReport(FilePath, SoldCount);
                        Console.WriteLine("Please come again!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to display the vending report");
                        Console.ReadKey();
                        DisplayVendingReport(FilePath);
                        Environment.Exit(0);
                    }
                    else
                    {
                        string ItemSold = Vend.Option(int.Parse(((char)UserInput).ToString()));
                        SoldCount++;
                        WriteBodyOfReport(FilePath, ItemSold);
                        Console.WriteLine("Here is your " + ItemSold + "\n");
                    }
                }
                //invalid response
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input\n");
                }
            } while (true);
        }
        //validates that a input is within the range of options
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

        static string GenerateFilePath(string FileName) 
        {
            string DocPath = Environment.CurrentDirectory;
            string FilePath = Path.Combine(DocPath, FileName);
            return FilePath;
        }

        static void WriteHeadOfReport(string FilePath) 
        {
            DateTime Date = DateTime.Now;

            using (StreamWriter SW = new StreamWriter(FilePath, true)) 
            {
                SW.WriteLine();
                SW.Write("Date: " + Date.ToString("D"));
                SW.WriteLine("     Time: " + Date.ToString("t"));
                SW.WriteLine();
            }
        }

        static void WriteEndOfReport(string FilePath, int SoldCount) 
        {
            using (StreamWriter SW = new StreamWriter(FilePath, true)) 
            {
                SW.WriteLine();
                SW.WriteLine("Items Sold: " + SoldCount);
                SW.WriteLine("_______________");
            }
        }

        static void WriteBodyOfReport(string FilePath, string Item) 
        {
            DateTime Time = DateTime.Now;

            using (StreamWriter SW = new StreamWriter(FilePath, true)) 
            {
                SW.WriteLine(Item + " " + Time.ToString("T"));
            }
        }

        static string GetReport(string FilePath) 
        {
            string Report = string.Empty;

            using (StreamReader SR = new StreamReader(FilePath)) 
            {
                Report = SR.ReadToEnd();
            }

            return Report;
        }

        static void DisplayVendingReport(string FilePath) 
        {
            string VendingReport = string.Empty;

            VendingReport = GetReport(FilePath);
            Console.Clear();
            Console.WriteLine("****************** Vending Report ******************");
            Console.WriteLine(VendingReport);
        }
    }
}
