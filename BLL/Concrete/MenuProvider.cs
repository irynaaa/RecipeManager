using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class MenuProvider: IMenuProvider
    {
        IMenuRepository _menuRepository;

        public MenuProvider(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
    }
}
