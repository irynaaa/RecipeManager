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

        [Display(Name = "Категория")]
        [Required, StringLength(maximumLength: 255)]
        public string NameRecipeCategory { get; set; }

        [Display(Name = "Опубликовано?")]
        public bool IsPublished { get; set; }
    }

    public class AddCategoryViewModel
    {
        [Display(Name = "Категория")]
        [Required, StringLength(maximumLength: 255)]
        public string NameRecipeCategory { get; set; }

        [Display(Name = "Опубликовано?")]
        public bool IsPublished { get; set; }
    }

    public class EditRecipeCategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Категории")]
        [Required, StringLength(maximumLength: 255)]
        public string NameRecipeCategory { get; set; }

        [Display(Name = "Опубликовано?")]
        public bool IsPublished { get; set; }
    }
}
