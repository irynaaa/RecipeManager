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
        public MenuRecipeRecord Add(MenuRecipeRecord menuRecipeRecord)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MenuRecipeRecord> MenuRecipeRecords()
        {
            throw new NotImplementedException();
        }
    }
}
