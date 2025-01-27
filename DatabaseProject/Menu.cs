using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class Menu
    {
        public void ShowMainMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("1. View customers");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Search for customer");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again");
                        break;
                }
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to go back to main menu");
                Console.ReadKey();
            }
        }

    }
}
