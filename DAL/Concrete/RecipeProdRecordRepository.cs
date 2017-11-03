using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class RecipeProdRecordRepository : IRecipeProdRecordRepository
    {
        private readonly IEFContext _context;
        public RecipeProdRecordRepository(IEFContext context)
        {
            _context = context;
        }

        public RecipeProdRecord Add(RecipeProdRecord recipeProdRecord)
        {
            _context.Set<RecipeProdRecord>().Add(recipeProdRecord);
            return recipeProdRecord;
        }



        public IQueryable<RecipeProdRecord> RecipeProdRecords()
        {
            return this._context.Set<RecipeProdRecord>()/*.Include(p=>p.ProductId)*/;
        }
    }
}
