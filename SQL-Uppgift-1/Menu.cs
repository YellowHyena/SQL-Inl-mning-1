using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Uppgift_1
{
    public static class Menu
    {
        public static void MainMenuText()
        {
           Box.Simple(new string[] 
           {"What do you want to do, ?",
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
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    View.UniqueUserAndPassword();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    View.Vikings();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    View.MostCommonCountry();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    View.Top10L();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    View.StartingLetter();
                    break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
    }
}
