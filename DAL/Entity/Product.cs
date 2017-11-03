using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Product
    {
        public Product()
        { }
        [Key]
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


        public virtual ICollection<RecipeProdRecord> RecipeProdRecords { get; set; }


        public override string ToString()
        {
            return ProductName;
        }
    }
}
