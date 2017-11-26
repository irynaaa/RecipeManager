using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
   public class RecipeMenuRecordsViewModel
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public int RecipeId { get; set; }
    }
}
