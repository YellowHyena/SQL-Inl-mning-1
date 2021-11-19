using System;

namespace SQL_Uppgift_1
{
    public static class Menu
    {
        public static void MainMenuText()
        {
            Console.Clear();
            Box.Simple(new string[] 
           {"Choose an option",
            "[1]  View unique countries",
            "[2]  Check if all usernames and passwords are unique",
            "[3]  How many vikings?",
            "[4]  View the most common country",
            "[5]  View the first 10 users that has a last name that starts with L",
            "[6]  View all users whos name and last name share the same starting letter"});
        }

        public static void MainMenu()
        {
            MainMenuText();

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    View.UniqueCountries();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    View.UniqueUserAndPassword();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    View.Vikings();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    View.MostCommonCountry();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    View.Top10L();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    View.StartingLetter();
                    Console.ReadKey();
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
    }
}
