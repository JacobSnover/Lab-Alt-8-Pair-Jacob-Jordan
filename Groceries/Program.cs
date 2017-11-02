using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groceries
{
    class Program
    {
        public static ArrayList cartItems = new ArrayList();
        public static ArrayList cartPrices = new ArrayList();
        static void Main(string[] args)
        {
         
            while (true)
            {
                GroceryList();

                Console.Write("Enter the number of the item\nyou would like to select (1-8): ");

                string userInput = Console.ReadLine();
                int input = 0;
                if (!int.TryParse(userInput, out input) || input <= 0 || input > 8)
                {
                    Console.WriteLine("\nYou must enter a number from the list\n");
                    continue;
                }

                FoodPicker(input);

                Console.WriteLine(Continue());

            }
        }

        private static void GroceryList()
        {
            Console.WriteLine("   Items      Prices");
            Console.WriteLine("====================");
            Dictionary<string, double> groceries = new Dictionary<string, double>();
            groceries.Add("1. Peas", 1.99);
            groceries.Add("2. Corn", 0.59);
            groceries.Add("3. Bread", 2.99);
            groceries.Add("4. Candy", 0.99);
            groceries.Add("5. Beer", 9.99);
            groceries.Add("6. Spinach", 0.99);
            groceries.Add("7. Chicken", 5.99);
            groceries.Add("8. Milk", 2.49);
            
            foreach (KeyValuePair<string, double> pair in groceries)
            {
                Console.WriteLine($"{pair.Key,-15}{pair.Value,-15}");
            }

            Console.WriteLine("====================");
        }

        private static void FoodPicker(int input)
        {
            if (input == 1)
            {
                cartItems.Add("Peas");
                cartPrices.Add(1.99);
                Console.WriteLine("\nAdding Peas to cart at $1.99\n");

            }
            else if (input == 2)
            {
                cartItems.Add("Corn");
                cartPrices.Add(0.59);
                Console.WriteLine("\nAdding Corn to cart at $0.59\n");
            }
            else if (input == 3)
            {
                cartItems.Add("Bread");
                cartPrices.Add(2.99);
                Console.WriteLine("\nAdding Bread to cart at $2.99\n");
            }
            else if (input == 4)
            {
                cartItems.Add("Candy");
                cartPrices.Add(0.99);
                Console.WriteLine("\nAdding Candy to cart at $0.99\n");
            }
            else if (input == 5)
            {
                cartItems.Add("Beer");
                cartPrices.Add(9.99);
                Console.WriteLine("\nAdding Beer to cart at $9.99\n");
            }
            else if (input == 6)
            {
                cartItems.Add("Spinach");
                cartPrices.Add(0.99);
                Console.WriteLine("\nAdding Spinach to cart at $0.99\n");
            }
            else if (input == 7)
            {
                cartItems.Add("Chicken");
                cartPrices.Add(5.99);
                Console.WriteLine("\nAdding Chicken to cart at $5.99\n");
            }
            else if (input == 8)
            {
                cartItems.Add("Milk");
                cartPrices.Add(2.49);
                Console.WriteLine("\nAdding Milk to cart at $2.49\n");
            }
        }

        public static string Continue()
        {
            while (true)
            {
                Console.Write("\nDo you want to add another item? Yes or No: ");
                string test = Console.ReadLine().ToLower();

                if (test == "y" || test == "yes")
                {
                    return "ok";
                }
                else if (test == "n" || test == "no")
                {
                    Console.WriteLine("\n");
                   
                    Receipt();

                    double num = CartAverage();
                    Console.WriteLine(num.ToString("F"));

                    ItemValues();
                   
                    Console.WriteLine("Bye");
                    Console.ReadLine();
                    Environment.Exit(1);
                }
            }
        }

        private static void ItemValues()
        {
            double Max = double.MinValue;
            double Min = double.MaxValue;

            foreach (double x in cartPrices)
            {
                if (Max < x)
                {
                    Max = x;
                }
                if (Min > x)
                {
                    Min = x;
                }
            }
            Console.WriteLine("Least expensive item cost: " + Min);
            Console.WriteLine("Most expensive item cost: " + Max);
        }

        private static void Receipt()
        {
            Console.WriteLine("   Items      Prices");
            Console.WriteLine("====================");
            for (int i = 0; i < cartItems.Count; i++)
            {
                Console.WriteLine($"{cartItems[i],-15}{cartPrices[i],-15}");
            }
            Console.WriteLine("====================");
            Console.Write("Average price per item in order was: ");
        }

        private static double CartAverage()
        {
            double sum = 0.0;

            foreach (double i in cartPrices)
            {
                sum = sum + i;
            }

            double num = sum / cartPrices.Count;
            return num;
        }
    }
}
