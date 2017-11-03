using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IProductRepository
    {
        Product Add(Product product);
        IQueryable<Product> Products();
        Product GetProductById(int id);
        void Remove(int id);
        void SaveChanges();

        IQueryable<RecipeProdRecord> RecipeProdRecords();
    }
}
