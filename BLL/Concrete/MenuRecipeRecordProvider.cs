using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;

namespace BLL.Concrete
{
    public class MenuRecipeRecordProvider: IMenuRecipeRecordProvider
    {
        IMenuRecipeRecordRepository _menuRecipeRecordRepository;

        public MenuRecipeRecordProvider(IMenuRecipeRecordRepository menuRecipeRecordRepository)
        {
            _menuRecipeRecordRepository = menuRecipeRecordRepository;
        }

        public IEnumerable<RecipeMenuRecordsViewModel> GetRecipeMenuRecords()
        {
            var model = _menuRecipeRecordRepository.MenuRecipeRecords()
                 .Select(c => new RecipeMenuRecordsViewModel
                 {
                     Id = c.Id,
                     MenuId = c.MenuId,
                     RecipeId = c.RecipeId,
                 });

            return model.AsEnumerable();
        }
    }
}
