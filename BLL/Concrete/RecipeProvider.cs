using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
   public class RecipeProvider: IRecipeProvider
    {
        IRecipeProvider _recipeProvider;

        public RecipeProvider(IRecipeProvider recipeProvider)
        {
            _recipeProvider = recipeProvider;
        }
    }
}
