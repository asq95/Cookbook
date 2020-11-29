using Cookbook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Domain.Entity
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Actions { get; set; }
        public int TypeId { get; set; }

        public Recipe()
        {

        }
        public Recipe(int id, string name, List<string> ingredients, string actions, int typeId)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
            Actions = actions;
            TypeId = typeId;
        }
    }
}
