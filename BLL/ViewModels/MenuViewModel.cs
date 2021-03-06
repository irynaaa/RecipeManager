﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class MenusViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Тип меню")]
        [Required, StringLength(maximumLength: 255)]
        public string MenuName { get; set; }

        [Display(Name = "Опубликовано?")]
        public bool IsPublished { get; set; }
    }

    public class AddMenuViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Тип меню")]
        [Required, StringLength(maximumLength: 255)]
        public string MenuName { get; set; }

        [Display(Name = "Опубликовано?")]
        public bool IsPublished { get; set; }
    }

    public class EditMenuViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Тип меню")]
        [Required, StringLength(maximumLength: 255)]
        public string MenuName { get; set; }

        [Display(Name = "Опубликовано?")]
        public bool IsPublished { get; set; }
    }
}
