using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IMenuRecipeRecordRepository
    {
        MenuRecipeRecord Add(MenuRecipeRecord menuRecipeRecord);
        IQueryable<MenuRecipeRecord> MenuRecipeRecords();

        void SaveChanges();
        void Remove(int id);
        MenuRecipeRecord MenuRecipeRecordById(int id);
    }
}
