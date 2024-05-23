// This program tests a number of functions.
// Function 1: Print the price of a movie goer based on age.
// Function 2: Print the price of a whole group of movie goers based on age.
// Function 3: Print an input 10 times.
// Function 4: Prints the third word in a sentence.

namespace Flow_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Loops the main program
            bool programRunning = true;
            do
            {
                programRunning = MainMenu();
            } while(programRunning);
        }

        private static bool MainMenu()
        {
            // Prints the main menu and accepts an input allowing the user to select an option.
            Console.WriteLine("Välkommen till huvudmenyn.\n" +
                "Vänligen skriv in en siffra för att välja och testa en funktion.\n" +
                "0) Avsluta programmet.\n" +
                "1) Räkna ut pris för en biobesökare.\n" +
                "2) Räkna ut pris för en grupp biobesökare.\n" +
                "3) Upprepa en inmatning 10 gånger.\n" +
                "4) Skriver ut det tredje ordet i din inmatning.\n");
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

                    case Input.option3:
                        RepeatInput();
                        break;

                    case Input.option4:
                        ThirdWord();
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
            // Tells the user their input was faulty and to try again.
            Console.WriteLine("Inmatningen kändes inte igen. Vänligen försök igen.\n");
        }

        private struct Input
        {
            // A struct that holds the string values for different input options.
            public const string exit = "0";
            public const string option1 = "1";
            public const string option2 = "2";
            public const string option3 = "3";
            public const string option4 = "4";
        }

        private static int PriceByAge()
        {
            // Prints the price for a person depending on age
            // which is received as an input.
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
                        if (age < 5)
                        {
                            Console.WriteLine("Barn under 5 år gamla går in gratis.");
                            price = 0;
                        }
                        else if (age < 20)
                        {
                            Console.WriteLine("Ungdomspris: 80kr.");
                            price = 80;
                        }
                        else if (age > 100)
                        {
                            Console.WriteLine("Pensionärer över 100 år gamla går in gratis.");
                            price = 0;
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
            // Prints the total price and number of people
            // depending on user input.
            // Uses the PriceByAge() function.
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
            if (totalPrice > 0)
                Console.WriteLine($"\nDen totala kostnaden för de {groupSize} biobesökarna är {totalPrice}kr.\n");
            else Console.WriteLine("Alla besökarna går in gratis.\n");
        }

        private static void RepeatInput()
        {
            // Takes a user input and prints it 10 times.
            string input = "";
            bool loop = true;
            do
            {
                Console.WriteLine("Vänligen skriv in texten du vill ska upprepas.");
                input = Console.ReadLine()!;
                Console.WriteLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintFaultyInput();
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"{i + 1}. {input}, ");
                    }
                    loop = false;
                }
                    
            } while (loop);
            Console.WriteLine("\n");
        }

        private static void ThirdWord()
        {
            // Takes a user input as a sentence and prints
            // the third word in that sentence, skipping all spaces.
            string input = "";
            bool loop = true;
            do
            {
                Console.WriteLine("Vänligen ange en mening med minst tre ord.\n");
                input = Console.ReadLine();
                Console.WriteLine();
                // Splits user input.
                var words = input.Split(" ");
                // Checks if user input is long enough.
                if (words.Length < 3)
                {
                    Console.WriteLine("Meningen innehöll färre än tre ord. ");
                }
                else
                {
                    // Creates a new string array and copies
                    // over actual words.
                    string[] newWords = new string[words.Length];
                    int index = 0;
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Length > 0)
                        {
                            newWords[index++] = words[i];
                        }
                    }
                    // If 3 words or more have been successfully copied,
                    // prints the third word.
                    if (newWords[2] != null)
                    {
                        Console.WriteLine($"Det tredje ordet i meningen är: {newWords[2]}");
                        loop = false;
                    }
                    else Console.WriteLine("Meningen innehöll färre än tre ord. ");
                }
            } while (loop);
            Console.WriteLine();
        }
    }
}
