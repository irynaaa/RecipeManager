using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class RecipeCategoryProvider: IRecipeCategoryProvider
    {
        IRecipeCategoryProvider _recipeCategoryProvider;

        public RecipeCategoryProvider(IRecipeCategoryProvider recipeCategoryProvider)
        {
            _recipeCategoryProvider = recipeCategoryProvider;
        }
    }
}
