using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class SelectItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectRoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectProdWeightViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
    }

    //public class ProdWeightViewModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public float Weight { get; set; }
    //}
}
