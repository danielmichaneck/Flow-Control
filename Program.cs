
//c# övning - flöde via loopar och strängmanipulation
//obs - resultatet av övningen skall visas för lärare och godkännas innan den kan anses vara genomförd.
//övningen kan skrivas helt i programklassen med menyn i main-metoden.
//huvudmeny
//skapa en huvudmeny för programmet som håller det vid liv och informerar
//användaren.
//för att skapa programmets huvudmeny ska ni göra följande:
//1.berätta för användaren att de har kommit till huvudmenyn och de kommer navigera
//genom att skriva in siffror för att testa olika funktioner.
//2. skapa skalet till en switch-sats som till en början har två cases. ett för ”0” som
//stänger ner programmet och ett default som berättar att det är felaktig input.
//3. skapa en oändlig iteration, alltså något som inte tar slut innan vi säger till att den
//ska ta slut. detta löser ni med att skapa en egen bool med tillhörande while-loop.
//4. bygg ut menyn med val att exekvera de övriga övningarna.





namespace Flow_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                PrintMenu();
            } while(true);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Welcome to the main menu.\n" +
                "To select an option and test a function please type in a number.\n");
            string input = "";
            input = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                PrintFaultyInput();
                return;
            }
            else
            {
                switch (input)
                {

                }
            }
        }

        private static void PrintFaultyInput()
        {
            Console.WriteLine("Input not recognized, please try again.\n");
        }
    }
}
