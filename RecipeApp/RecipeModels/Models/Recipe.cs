using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeModels.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? RecipeType { get; set; }
        public string? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public double TimeToCook { get; set; }
        public bool IsActive { get; set; }
    }
}
