using Cookbook.App.Abstract;
using Cookbook.App.Concrete;
using Cookbook.App.Managers;
using Cookbook.Domain.Entity;
using System;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Cookbook
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            RecipeManager itemManager = new RecipeManager(actionService);


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome in my cookBook. What do you want to do?: ");

                var mainMenu = actionService.GetMenuActionsByMenuName("Main");

                foreach (var item in mainMenu)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }


                var operation = Console.ReadKey();
                Console.WriteLine();
                switch (operation.KeyChar)
                {
                    case '1':
                        var newId = itemManager.AddNewItem();
                        break;

                    case '2':
                        itemManager.ShowItem();
                        break;

                    case '3':
                        var removeId = itemManager.RemoveItem();
                        break;

                    case '4':
                        itemManager.randomRecipe();
                        break;

                    case '5':
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Something went wrong... This action doesn't exists.");
                        break;
                }

            }
        }


    }
}
