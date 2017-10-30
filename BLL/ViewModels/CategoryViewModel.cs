using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
   public class CategoryItemViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Категории")]
        [Required, StringLength(maximumLength: 255)]
        public string NameRecipeCategory { get; set; }

        [Display(Name = "Опубликовано?")]
        public bool IsPublished { get; set; }

        public CategoryItemViewModel()
        {

        }

        public CategoryItemViewModel(RecipeCategory category)
        {
            Id = category.Id;
            NameRecipeCategory = category.NameRecipeCategory;
            IsPublished = category.IsPublished;
        }
    }

    public class AddCategoryViewModel
    {
        [Display(Name = "Категории")]
        [Required, StringLength(maximumLength: 255)]
        public string NameRecipeCategory { get; set; }

        [Display(Name = "Опубликовано?")]
        public bool IsPublished { get; set; }

        public AddCategoryViewModel()
        {

        }
    }
}
