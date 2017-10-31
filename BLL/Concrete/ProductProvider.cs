using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Abstract;
using DAL.Entity;

namespace BLL.Concrete
{
    public class ProductProvider : IProductProvider
    {
        IProductRepository _productRepository;

        public ProductProvider(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(AddProductViewModel addProduct)
        {
            Product product = new Product
            {
                ProductName = addProduct.ProductName,
                CaloricValue = addProduct.CaloricValue,
                Fat = addProduct.Fat,
                Proteins = addProduct.Proteins,
                Carbohydrates = addProduct.Carbohydrates
            };
            _productRepository.Add(product);
            _productRepository.SaveChanges();

            return product.Id;
        }

        public int EditProduct(EditProductViewModel editProduct)
        {
            try
            {
                var product =
                    _productRepository.GetProductById(editProduct.Id);
                if (product != null)
                {
                    product.ProductName = editProduct.ProductName;
                    product.CaloricValue = editProduct.CaloricValue;
                    product.Fat = editProduct.Fat;
                    product.Proteins = editProduct.Proteins;
                    product.Carbohydrates = editProduct.Carbohydrates;
                    _productRepository.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
            return editProduct.Id;
        }

        public EditProductViewModel EditProduct(int id)
        {
            EditProductViewModel model = null;

            var product = _productRepository.GetProductById(id);

            if (product != null)
            {
                model = new EditProductViewModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    CaloricValue = product.CaloricValue,
                    Fat = product.Fat,
                    Proteins = product.Proteins,
                    Carbohydrates = product.Carbohydrates
                };
            }
            return model;
        }

        public ProductsViewModel GetProductDetales(int id)
        {
            ProductsViewModel model = null;
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                model = new ProductsViewModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    CaloricValue = product.CaloricValue,
                    Fat = product.Fat,
                    Proteins = product.Proteins,
                    Carbohydrates = product.Carbohydrates
                };
            }
            return model;
        }

        public IEnumerable<ProductsViewModel> GetProducts()
        {
            var model = _productRepository.Products()
                .Select(c => new ProductsViewModel
                {
                    Id = c.Id,
                    ProductName = c.ProductName,
                    CaloricValue=c.CaloricValue,
                    Fat=c.Fat,
                    Proteins=c.Proteins,
                    Carbohydrates=c.Carbohydrates
                });
            return model.AsEnumerable();
        }

        public void RemoveProduct(int id)
        {
            _productRepository.Remove(id);
        }
    }
}
