using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public interface IRecipeProdRecordRepository
    {
        RecipeProdRecord Add(RecipeProdRecord recipeProdRecord);
        IQueryable<RecipeProdRecord> RecipeProdRecords();
        void SaveChanges();
        void Remove(int id);
        RecipeProdRecord RecipeProdRecordById(int id);
    }
}
