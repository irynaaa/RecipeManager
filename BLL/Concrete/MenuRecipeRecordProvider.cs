using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class MenuRecipeRecordProvider: IMenuRecipeRecordProvider
    {
        IMenuRecipeRecordRepository _menuRecipeRecordRepository;

        public MenuRecipeRecordProvider(IMenuRecipeRecordRepository menuRecipeRecordRepository)
        {
            _menuRecipeRecordRepository = menuRecipeRecordRepository;
        }
    }
}
