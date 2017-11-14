using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.ViewModels
{
    public class RecipesViewModel
    {
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

        public int RecipeCategoryId { get; set; }

        public RecipeCategory RecipeCategory { get; set; }

        [Display(Name = "Продукты")]
        public IEnumerable</*CheckBoxViewModel*/SelectItemViewModel> Products { get; set; }

       // public IEnumerable<ProdItemViewModel> Products { get; set; }
        
    }

    public class AddRecipeViewModel
    {
        [Key]
        public int Id { get; set; }

        public IEnumerable<SelectItemViewModel> Categories { get; set; }

        [Display(Name = "Название рецепта")]
        [Required, StringLength(maximumLength: 255)]
        public string RecipeName { get; set; }

        [Display(Name = "Фото")]
        [StringLength(maximumLength: 255)]
        public string RecipeImage { get; set; }

        public HttpPostedFileBase PhotoUpload { get; set; }

        [Display(Name = "Описание")]
        [StringLength(maximumLength: 3000)]
        public string RecipeDescription { get; set; }

        [Display(Name = "Создан")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Изменен")]
        public DateTime ModefiedAt { get; set; }

        [Display(Name = "Время приготовления")]
        public int CookingTime { get; set; }

        [Display(Name = "Категория")]
        public int RecipeCategoryId { get; set; }

        [Display(Name = "Категория")]
        public RecipeCategory RecipeCategory { get; set; }

        [Display(Name = "Продукты")]
        public IEnumerable<SelectItemViewModel> Products { get; set; }
    }

    public class ProdItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set;}
    }


    public class EditRecipeViewModel
    {
        [Key]
        public int Id { get; set; }

        public IEnumerable<SelectItemViewModel> Categories { get; set; }

        //public int[] Products { get; set; }

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

        [Display(Name = "Категория")]
        public int RecipeCategoryId { get; set; }

        [Display(Name = "Категория")]
        public RecipeCategory RecipeCategory { get; set; }

        [Display(Name = "Продукты")]
        public /*int[]*/List<int> Products { get; set; }
        // public List</*CheckBoxViewModel*/SelectItemViewModel> Products { get; set; }

    }

}
