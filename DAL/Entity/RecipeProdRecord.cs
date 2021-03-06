﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class RecipeProdRecord
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RecipeId { get; set; }

        [Display(Name = "Вес, г")]
        public float Weight { get; set; }

        //public RecipeProdRecord()
        //{
        //    Recipes = new List<Recipe>();
        //    Products = new List<Product>();
        //}

        public virtual Recipe Recipe { get; set; }

        public virtual Product Product { get; set; }
    }
}
