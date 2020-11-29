using Cookbook.App.Concrete;
using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.App.Managers
{
    public class RecipeManager
    {
        private readonly MenuActionService _actionService;
        private RecipeService _recipeService;

        public RecipeManager(MenuActionService actionService)
        {
            _actionService = actionService;
            _recipeService = new RecipeService();
        }

        public int AddNewItem()
        {
            int userDecision = 1;

            var addNewItemMenu = _actionService.GetMenuActionsByMenuName("AddNewItemMenu");

            Console.WriteLine("Please select recipe type: ");
            foreach (var item in addNewItemMenu)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            var operation = Console.ReadKey();
            int typeOfMeal;
            Int32.TryParse(operation.KeyChar.ToString(), out typeOfMeal);

            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter ingredients for new recipe: ");
            List<string> recipeIngrediens = new List<string>();
            recipeIngrediens.Add(Console.ReadLine());
            while (userDecision != 0)
            {
                Console.Write("Do you want add more ingredients? Type 1(yes) or 0(no): ");
                var decision = Console.ReadLine();
                Int32.TryParse(decision, out userDecision);
                if (userDecision == 1)
                {
                    recipeIngrediens.Add(Console.ReadLine());
                }
                else if (userDecision == 0) break;
                else Console.WriteLine("This action doesn't exists");
            }

            Console.WriteLine("Please enter actions (what must be done in the recipe): ");
            var actionsRecipe = Console.ReadLine();

            var lastId = _recipeService.GetLastId();
            Recipe newRecipe = new Recipe(lastId + 1, name, recipeIngrediens, actionsRecipe, typeOfMeal);
            _recipeService.AddItem(newRecipe);
            return newRecipe.Id;
        }

        public void ShowItem()
        {
            if (_recipeService.Items.Count > 0)
            {
                Console.WriteLine("Which meal do you want to show:");
                int id = 1;
                foreach (var item in _recipeService.Items)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }
                while (!(int.TryParse(Console.ReadLine(), out id)) || id > _recipeService.Items.Count)
                {
                    Console.WriteLine("This must be a number!");
                }

                Console.Clear();
                int i = 1;
                foreach (var item in _recipeService.Items)
                {
                    if (item.Id == id)
                    {
                        Console.WriteLine(item.Id + ". "+ item.Name);
                        Console.WriteLine("Ingredients: ");
                        foreach (var ingredient in item.Ingredients)
                        {
                            Console.WriteLine($"{i}. {ingredient}");
                            i++;
                        }
                        Console.WriteLine("Actions: ");
                        Console.WriteLine(item.Actions);
                        Console.ReadLine();
                    }
                }

                
            }
            else
            {
                Console.WriteLine("We don't have any recipes... You must add one");
                Console.ReadLine();
            }

        }

        public int RemoveItem()
        {
            Console.Clear();
            foreach (var recipe in _recipeService.Items)
            {
                Console.WriteLine($"{recipe.Id}. {recipe.Name}");
            }
            Console.WriteLine("Please enter id for recipe you want to remove: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            _recipeService.Items.RemoveAt(id-1);
            return id;
        }

        public void randomRecipe()
        {
            Console.WriteLine("What type of meal do you need?");

            var addNewItemMenu = _actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            foreach (var item in addNewItemMenu)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            int randomId = int.Parse(Console.ReadLine());

            var random = new Random();
            List<Recipe> recipeOfList = new List<Recipe>();
            Recipe randomRecipe = new Recipe();

            if (_recipeService.Items.Count > 0)
            {
                foreach (var item in _recipeService.Items)
                {
                    if (randomId == item.TypeId)
                    {
                        recipeOfList.Add(item);
                    }
                }

                if (recipeOfList.Count > 0)
                {
                    int index = random.Next(recipeOfList.Count);
                    randomRecipe = recipeOfList[index];
                    Console.WriteLine($"{randomRecipe.Id}. {randomRecipe.Name}\n Ingredients:");
                    int i = 1;
                    foreach (var item in randomRecipe.Ingredients)
                    {
                        Console.WriteLine($"{i}. {item}");
                        i++;
                    }
                    Console.WriteLine($"Actions: \n{randomRecipe.Actions}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Nothing to show here... Yo must add one recipe");
                    Console.ReadLine();
                }

            }

            else
            {
                Console.WriteLine("We don't have any recipes... You must add one");
                Console.ReadLine();
            }



        }

    }
}
