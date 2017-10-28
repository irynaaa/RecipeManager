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
        public Product Add(Product product)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Products()
        {
            throw new NotImplementedException();
        }
    }
}
