using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopingList
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Shopping list
   1.The program asks the user to provide a list of goods they would need to buy from a supermarket. User provides a list of goods separated by a comma and a space.
   2.After the user has provided their list, the program cleans the console, displays the provided list as, e.g.:
   item 1: milk
   item 2: bread
   item 3:...
   ….
   3.Program asks if the user would like to add or remove an item or quit the app.
   Depending on the user's choice, the program adds or removes the item (the user enters the item they want to add as a string) if the user has chosen to quit the app, the program wishes them to shop wisely.
   4.After the item has been added or removed, the program cleans the console and displays an updated list and asks if the user would like to add or remove another item or quit the app.*/


            string addedGoods;
            var shoppingList = GetList();
            bool checkingGoods = false;
            
            Console.WriteLine("\n");
            Asking();

            while(!checkingGoods)
            {
                addedGoods = Console.ReadLine();
                Console.WriteLine("\n");

                switch(addedGoods.ToUpper())
                {
                    case "Y":
                        Console.WriteLine("Insert item you like to add:");
                        addedGoods = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Here are you shopping list: ");
                        shoppingList.Add(addedGoods);
                        ShoppingListItems(shoppingList);
                        Console.WriteLine("\n");
                        Asking();
                        break;
                    case "N":
                        Console.Clear();
                        Console.WriteLine("You shopping list consist of:");
                        ShoppingListItems(shoppingList);
                        Console.WriteLine("\n");
                        Console.WriteLine("Shop wisely!");
                        checkingGoods = true;
                        break;
                    case "R":
                        Console.WriteLine("Insert item you like to remove:");
                        addedGoods = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Here are you shopping list: ");
                        shoppingList.Remove(addedGoods);
                        ShoppingListItems(shoppingList);
                        Console.WriteLine("\n");
                        Asking();
                        break;
                    default:
                        Console.WriteLine("Invalid entry!");
                        Asking();
                        break;
                }
            }
        }
        public static void ShoppingListItems(List<string> shoppingList)
        {
            for(int i = 0; i < shoppingList.Count; i++)
            {
                Console.WriteLine($"{i + 1} {shoppingList[i]}");
            }
            var now = DateTime.Now;
            Console.WriteLine($"Your shopping list is updated {now}.");
        }
        public static List<string> GetList()
        {
            string userGoods;
            Console.WriteLine("Hello, please insert grocery items what you would like to have from a supermarket (bread,milk,...): ");
            userGoods = Console.ReadLine();

            Console.Clear();

            string[] shoppingItems = userGoods.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> shoppingList = shoppingItems.ToList();
            for (int i = 0; i < shoppingItems.Length; i++)
            {
                Console.WriteLine($"{i + 1} {shoppingList[i]}");
            }
            var now = DateTime.Now;
            Console.WriteLine($"Your shopping list is updated {now}.");
            return shoppingList;

        }
        public static void Asking()
        {
            Console.WriteLine("Would you like to add or remove an item or quit the app?");
            Console.WriteLine("Add = 'Y' | Remove = 'R' | Quit = 'N'");
        }
    }
}

