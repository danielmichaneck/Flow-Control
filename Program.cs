namespace Flow_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programRunning = true;
            do
            {
                programRunning = MainMenu();
            } while(programRunning);
        }

        private static bool MainMenu()
        {
            Console.WriteLine("Välkommen till huvudmenyn.\n" +
                "Vänligen skriv in en siffra för att välja och testa en funktion.\n");
            string input = "";
            input = Console.ReadLine()!;
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                PrintFaultyInput();
                return true;
            }
            else
            {
                switch (input)
                {
                    case Input.exit:
                        return false;

                    case Input.option1:
                        PriceByAge();
                        break;

                    case Input.option2:
                        PriceForGroup();
                        break;

                    default:
                        PrintFaultyInput();
                        return true;
                }
            }
            return true;
        }

        private static void PrintFaultyInput()
        {
            Console.WriteLine("Inmatningen kändes inte igen. Vänligen försök igen.\n");
        }

        private struct Input
        {
            public const string exit = "0";
            public const string option1 = "1";
            public const string option2 = "2";
            public const string option3 = "3";
        }

        private static void PriceByAge()
        {
            bool loop = true;
            Console.WriteLine("Vänligen skriv in biobesökarens ålder.\n");
            do
            {
                if (int.TryParse(Console.ReadLine(), out var age))
                {
                    if (age < 0)
                        Console.WriteLine("Ålder kan inte vara mindre än noll.");
                    else
                    {
                        loop = false;
                        if (age < 20)
                        {
                            Console.WriteLine("Ungdomspris: 80kr.");
                        }
                        else if (age > 64)
                        {
                            Console.WriteLine("Pensionärspris: 90kr.");
                        }
                        else
                        {
                            Console.WriteLine("Standardpris: 120kr.");
                        }
                    }
                    Console.WriteLine();    
                }
                else PrintFaultyInput();
            } while (loop);
        }

        private static void PriceForGroup()
        {
            Console.WriteLine("Vänligen skriv in antal biobesökare.\n");
            bool loop = true;
            do
            {
                if (int.TryParse(Console.ReadLine(), out var groupSize))
                {
                    if (groupSize < 0)
                        Console.WriteLine("Antalet kan inte vara mindre än noll.");
                    else loop = false;
                    Console.WriteLine();
                }
                else PrintFaultyInput();
            } while (loop);
        }
    }
}
