using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Описание")]
        [StringLength(maximumLength: 3000)]
        public string RecipeDescription { get; set; }

        [Display(Name = "Создан")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Изменен")]
        public DateTime ModefiedAt { get; set; }

        [Display(Name = "Время приготовления")]
        public int CookingTime { get; set; }

        [ForeignKey("RecipeCategory")]
        public int RecipeCategoryId { get; set; }

        [Display(Name = "Категория")]
        public RecipeCategory RecipeCategory { get; set; }


        public virtual ICollection<RecipeProdRecord> RecipeProdRecords { get; set; }
    }
}
