using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Concrete
{
    public class RecipeProdRecordRepository : IRecipeProdRecordRepository
    {
        public RecipeProdRecord Add(RecipeProdRecord recipeProdRecord)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RecipeProdRecord> RecipeProdRecords()
        {
            throw new NotImplementedException();
        }
    }
}
