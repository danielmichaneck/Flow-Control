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
                "Vänligen skriv in en siffra för att välja och testa en funktion.\n" +
                "0) Avsluta programmet.\n" +
                "1) Räkna ut pris för en biobesökare.\n" +
                "2) Räkna ut pris för en grupp biobesökare.\n" +
                "3) Upprepa en inmatning 10 gånger.\n");
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

        private static int PriceByAge()
        {
            bool loop = true;
            int price = 0;
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
                            price = 80;
                        }
                        else if (age > 64)
                        {
                            Console.WriteLine("Pensionärspris: 90kr.");
                            price = 90;
                        }
                        else
                        {
                            Console.WriteLine("Standardpris: 120kr.");
                            price = 120;
                        }
                    }
                    Console.WriteLine();    
                }
                else PrintFaultyInput();
            } while (loop);
            return price;
        }

        private static void PriceForGroup()
        {
            int groupSize = 0;
            Console.WriteLine("Vänligen skriv in antal biobesökare.\n");
            bool loop = true;
            do
            {
                if (int.TryParse(Console.ReadLine(), out int size))
                {
                    if (size < 0)
                        Console.WriteLine("Antalet kan inte vara mindre än noll.");
                    else
                    {
                        loop = false;
                        groupSize = size;
                    }
                    Console.WriteLine();
                }
                else PrintFaultyInput();
            } while (loop);
            int totalPrice = 0;
            for (int i = 0; i < groupSize; i++)
            {
                totalPrice += PriceByAge();
            }
            Console.WriteLine($"Den totala kostnaden för de {groupSize} biobesökarna är {totalPrice}kr.\n");
        }

        private static void RepeatInput()
        {
            string input = "";
            input = Console.ReadLine()!;
            Console.WriteLine();
            bool loop = true;
            do
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintFaultyInput();
                }
                else
                {

                }
                    
            } while (loop);
        }
    }
}
