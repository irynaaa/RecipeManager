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

        public IQueryable<RecipeProdRecord> RecipeProdRecordByRecipeId(int id)
        {
            return this.RecipeProdRecords().Where(i => i.RecipeId==id);
                
        }

        public RecipeProdRecord RecipeProdRecordById(int id)
        {
            return this.RecipeProdRecords()
                .SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            var rpr = this.RecipeProdRecordById(id);
            if (rpr != null)
            {
                _context.Set<RecipeProdRecord>().Remove(rpr);
            }
        }


        public void RemoveRecipe(int RecipeId)
        {
            var rpr = this.RecipeProdRecords().Where(r=>r.RecipeId == RecipeId);
            if (rpr != null)
            {
                foreach(var recipe in rpr)
                _context.Set<RecipeProdRecord>().Remove(recipe);
            }
            this._context.SaveChanges();
        }


        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
