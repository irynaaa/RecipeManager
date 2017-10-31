using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
        public class AddProductViewModel
        {
            public int Id { get; set; }

            [Display(Name = "Название")]
            public string ProductName { get; set; }

            [Display(Name = "Белки")]
            public float Proteins { get; set; }

            [Display(Name = "Жиры")]
            public float Fat { get; set; }

            [Display(Name = "Углеводы")]
            public float Carbohydrates { get; set; }

            [Display(Name = "Калории")]
            public float CaloricValue { get; set; }

        }

        public class ProductsViewModel
        {
            public int Id { get; set; }

            [Display(Name = "Название")]
            public string ProductName { get; set; }

            [Display(Name = "Белки")]
            public float Proteins { get; set; }

            [Display(Name = "Жиры")]
            public float Fat { get; set; }

            [Display(Name = "Углеводы")]
            public float Carbohydrates { get; set; }

            [Display(Name = "Калории")]
            public float CaloricValue { get; set; }

        }

        public class EditProductViewModel
        {
            public int Id { get; set; }

            [Display(Name = "Название")]
            public string ProductName { get; set; }

            [Display(Name = "Белки")]
            public float Proteins { get; set; }

            [Display(Name = "Жиры")]
            public float Fat { get; set; }

            [Display(Name = "Углеводы")]
            public float Carbohydrates { get; set; }

            [Display(Name = "Калории")]
            public float CaloricValue { get; set; }
        }
    }
