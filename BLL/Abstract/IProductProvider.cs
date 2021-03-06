﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;

namespace BLL.Abstract
{
    public interface IProductProvider
    {
        int AddProduct(AddProductViewModel addProduct);
        IEnumerable<ProductsViewModel> GetProducts();
        ProductsViewModel GetProductDetales(int id);
        EditProductViewModel EditProduct(int id);
        int EditProduct(EditProductViewModel editProduct);
        void RemoveProduct(int id);

        
    }
}
