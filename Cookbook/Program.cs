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
            actionService = Initialize(actionService);

            RecipeService recipeService = new RecipeService();

            while (true)
            {
                Console.Clear();
            Console.WriteLine("Welcome in my cookBook. What do you want to do?: ");
            var mainMenu = actionService.GetMenuByMenuName("Main");

            foreach (var item in mainMenu)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }

            var operation = Console.ReadKey();
                Console.WriteLine();
            switch (operation.KeyChar)
            {
                case '1':
                    var keyInfo = recipeService.AddNewItemView(actionService);
                    var id = recipeService.AddNewItem(keyInfo.KeyChar);
                    break;
                case '2':
                    var showRecipeId = recipeService.showRecipeView();
                    recipeService.showRecipe(showRecipeId);
                    break;
                case '3':
                    var removeId = recipeService.removeItemView();
                    recipeService.removeItem(removeId);
                    break;
                case '4':
                    var randomId = recipeService.randomRecipeView(actionService);
                    recipeService.randomRecipe(randomId);
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

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add new recipe", "Main");
            actionService.AddNewAction(2, "Show me recipe", "Main");
            actionService.AddNewAction(3, "Remove recipe", "Main");
            actionService.AddNewAction(4, "Random recipe", "Main");
            actionService.AddNewAction(5, "Exit and click enter", "Main");

            actionService.AddNewAction(1, "Breakfest", "AddNewItemMenu");
            actionService.AddNewAction(2, "Dinner", "AddNewItemMenu");
            actionService.AddNewAction(3, "Supper", "AddNewItemMenu");
            return actionService;
        }
    }
}
