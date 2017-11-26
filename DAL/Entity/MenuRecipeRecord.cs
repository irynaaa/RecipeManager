using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class MenuRecipeRecord
    {
        [Key]
        public int Id { get; set; }

        public int MenuId { get; set; }

        public int RecipeId { get; set; }

        //public MenuRecipeRecord()
        //{
        //    Recipes = new List<Recipe>();
        //    Menus = new List<Menu>();
        //}

        //public virtual ICollection<Recipe> Recipes { get; set; }

        //public virtual ICollection<Menu> Menus { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
