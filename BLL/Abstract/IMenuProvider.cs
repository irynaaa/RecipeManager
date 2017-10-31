using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface IMenuProvider
    {
        int AddMenu(AddMenuViewModel addMenu);
        IEnumerable<MenusViewModel> GetMenus();
        MenusViewModel GetMenuDetales(int id);
        EditMenuViewModel EditMenu(int id);
        int EditMenu(EditMenuViewModel editMenu);
        void RemoveMenu(int id);
    }
}
