using Cookbook.App.Common;
using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
        private void Initialize()
        {
            AddItem( new MenuAction (1, "Add new recipe", "Main") );
            AddItem( new MenuAction (2, "Show me recipe", "Main") );
            AddItem( new MenuAction (3, "Remove recipe", "Main") );
            AddItem( new MenuAction (4, "Random recipe", "Main") );
            AddItem( new MenuAction (5, "Exit and click enter", "Main") );

            AddItem( new MenuAction (1, "Breakfest", "AddNewItemMenu") );
            AddItem( new MenuAction (2, "Dinner", "AddNewItemMenu") );
            AddItem( new MenuAction (3, "Supper", "AddNewItemMenu") );
        }
    }
}
