using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cookbook
{
    class RecipeService
    {
        public List<Recipe> Recipes { get; set; }

        public RecipeService()
        {
            Recipes = new List<Recipe>();
        }

        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {
            ConsoleKeyInfo operation;
            var addNewItemMenu = actionService.GetMenuByMenuName("AddNewItemMenu");
            Console.WriteLine("Choose the type of meal: ");
            foreach (var item in addNewItemMenu)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            operation = Console.ReadKey();

            while (!(operation.Key == ConsoleKey.D1 || operation.Key == ConsoleKey.D2 || operation.Key == ConsoleKey.D3))
            {
                Console.WriteLine("Choose the type of meal: ");
                foreach (var item in addNewItemMenu)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }
                operation = Console.ReadKey();
            } 
            
            Console.Clear();
            return operation;
        }

        public int AddNewItem(char recipeType)
        {
            int recipeTypeId, userDecision = 1;

            
            Int32.TryParse(recipeType.ToString(), out recipeTypeId);
            Recipe recipe = new Recipe();
            recipe.TypeId = recipeTypeId;

            var id = Recipes.Count + 1;

            Console.Write("Please enter name for new recipe: ");
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

            recipe.Id = id;
            recipe.Name = name;
            recipe.Ingredients = recipeIngrediens;
            recipe.Actions = actionsRecipe;

            Recipes.Add(recipe);
            Console.Clear();
            return id;
        }

        public void randomRecipe(int randomId)
        {
            var random = new Random();
            Recipe randomRecipe = new Recipe();
            List<Recipe> recipes = new List<Recipe>();

            if (Recipes.Count > 0)
            {
                foreach (var item in Recipes)
                {
                    if (randomId == item.TypeId)
                    {
                        recipes.Add(item);
                    }
                }
                if (recipes.Count > 0)
                {
                    int index = random.Next(recipes.Count);
                    randomRecipe = recipes[index];
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

        public int randomRecipeView(MenuActionService actionService)
        {
            Console.WriteLine("What type of meal do you need?");
            var addNewItemMenu = actionService.GetMenuByMenuName("AddNewItemMenu");
            foreach (var item in addNewItemMenu)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            var operation = Console.ReadLine();
            return int.Parse(operation);

        }

        public void showRecipe(int recipeId)
        {
            if (recipeId != -1)
            {
                Recipe recipeToShow = new Recipe();
                foreach (var item in Recipes)
                {
                    if (item.Id == recipeId)
                    {
                        recipeToShow = item;
                    }
                }
                Console.WriteLine($"{recipeToShow.Id}. {recipeToShow.Name}\n Ingredients:");
                int i = 1;
                foreach (var item in recipeToShow.Ingredients)
                {
                    Console.WriteLine($"{i}. {item}");
                    i++;
                }
                Console.WriteLine($"Actions: \n{recipeToShow.Actions}");
                Console.WriteLine("Click for back to main menu.");
                Console.ReadLine();
                Console.Clear();
            }
            
        }

        public int showRecipeView()
        {
            if (Recipes.Count > 0)
            {
                int id = -1;
                Console.WriteLine("Which meal do you want to show:");
                foreach (var item in Recipes)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }
                while ( !(int.TryParse(Console.ReadLine(), out id)) ||  id > Recipes.Count)
                {
                    Console.WriteLine("This must be a number!");
                }
                Console.Clear();
                return id;
            }
            else
            {
                Console.WriteLine("We don't have any recipes... You must add one");
                Console.ReadLine();
                return -1;
            }
            
        }

        public void removeItem(int removeId)
        {
            Recipe recipeToRemove = new Recipe();
            foreach (var item in Recipes)
            {
                if (item.Id == removeId)
                {
                    recipeToRemove = item;
                    break;
                }
            }
            Recipes.Remove(recipeToRemove);
        }

        public int removeItemView()
        {
            foreach (var recipe in Recipes)
            {
                Console.WriteLine($"{recipe.Id}. {recipe.Name}");
            }
            Console.WriteLine("Please enter id for recipe you want to remove: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            return id;
        }

    }
}
