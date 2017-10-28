using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class MenuProvider: IMenuProvider
    {
        IMenuProvider _menuProvider;

        public MenuProvider(IMenuProvider menuProvider)
        {
            _menuProvider = menuProvider;
        }
    }
}
