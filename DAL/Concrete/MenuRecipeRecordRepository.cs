using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Concrete
{
    public class MenuRecipeRecordRepository : IMenuRecipeRecordRepository
    {
        private readonly IEFContext _context;
        public MenuRecipeRecordRepository(IEFContext context)
        {
            _context = context;
        }

        public MenuRecipeRecord Add(MenuRecipeRecord menuRecipeRecord)
        {
            _context.Set<MenuRecipeRecord>().Add(menuRecipeRecord);
            return menuRecipeRecord;
        }

        public IQueryable<MenuRecipeRecord> MenuRecipeRecords()
        {
            return this._context.Set<MenuRecipeRecord>();
        }

        public MenuRecipeRecord MenuRecipeRecordById(int id)
        {
            return this.MenuRecipeRecords()
                .SingleOrDefault(c => c.Id == id);
        }


        public void Remove(int id)
        {
            var mrr = this.MenuRecipeRecordById(id);
            if (mrr != null)
            {
                _context.Set<MenuRecipeRecord>().Remove(mrr);
            }
        }


        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
