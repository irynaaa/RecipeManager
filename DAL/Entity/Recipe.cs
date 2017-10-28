using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Recipe
    {
        public Recipe()
        {
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название рецепта")]
        [Required, StringLength(maximumLength: 255)]
        public string RecipeName { get; set; }

        [Display(Name = "Фото")]
        [StringLength(maximumLength: 255)]
        public string RecipeImage { get; set; }
    }
}
