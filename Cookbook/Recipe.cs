using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook
{
    class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Actions { get; set; }
        public int TypeId { get; set; }
    }
}
