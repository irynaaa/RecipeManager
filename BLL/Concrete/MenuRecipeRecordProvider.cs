using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class MenuRecipeRecordProvider: IMenuRecipeRecordProvider
    {
        IMenuRecipeRecordProvider _menuRecipeRecordProvider;

        public MenuRecipeRecordProvider(IMenuRecipeRecordProvider menuRecipeRecordProvider)
        {
            _menuRecipeRecordProvider = menuRecipeRecordProvider;
        }
    }
}
