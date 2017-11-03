using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class RecipeProdRecordsViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RecipeId { get; set; }

        [Display(Name = "Вес, г")]
        public float Weight { get; set; }
    }
}
