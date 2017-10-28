using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Abstract;

namespace BLL.Concrete
{
    public class ProductProvider : IProductProvider
    {
        IProductRepository _productRepository;

        public ProductProvider(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(ProductViewModel.AddProductViewModel addProduct)
        {
            throw new NotImplementedException();
        }

        public int EditProduct(ProductViewModel.EditProductViewModel editProduct)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel.EditProductViewModel EditProduct(int id)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel.ProductsViewModel GetProductDetales(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductViewModel.ProductsViewModel> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
