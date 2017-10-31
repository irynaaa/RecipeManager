using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IEFContext _context;
        public ProductRepository(IEFContext context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Set<Product>().Add(product);
            return product;
        }

        public IQueryable<Product> Products()
        {
            return this._context.Set<Product>();
        }

        public Product GetProductById(int id)
        {
            return this.Products()
                .SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            var product = this.GetProductById(id);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                this.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
