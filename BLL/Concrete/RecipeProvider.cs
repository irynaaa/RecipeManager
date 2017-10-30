using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
   public class RecipeProvider: IRecipeProvider
    {
        IRecipeRepository _recipeRepository;

        public RecipeProvider(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
    }
}
