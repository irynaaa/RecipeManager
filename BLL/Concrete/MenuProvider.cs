using BLL.Abstract;
using BLL.ViewModels;
using DAL.Abstract;
using DAL.Entity;
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

        public int AddMenu(AddMenuViewModel addMenu)
        {
            Menu menu = new Menu
            {
                MenuName = addMenu.MenuName,
                
            };
            _menuRepository.Add(menu);
            _menuRepository.SaveChanges();

            return menu.Id;
        }

        public int EditMenu(EditMenuViewModel editMenu)
        {
            try
            {
                var Menu =
                    _menuRepository.GetMenuById(editMenu.Id);
                if (Menu != null)
                {
                    Menu.MenuName = editMenu.MenuName;
                    _menuRepository.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
            return editMenu.Id;
        }

        public EditMenuViewModel EditMenu(int id)
        {
            EditMenuViewModel model = null;

            var Menu = _menuRepository.GetMenuById(id);

            if (Menu != null)
            {
                model = new EditMenuViewModel
                {
                    Id = Menu.Id,
                    MenuName = Menu.MenuName,
                };
            }
            return model;
        }

        public MenusViewModel GetMenuDetales(int id)
        {
            MenusViewModel model = null;
            var Menu = _menuRepository.GetMenuById(id);
            if (Menu != null)
            {
                model = new MenusViewModel
                {
                    Id = Menu.Id,
                    MenuName = Menu.MenuName,
                };
            }
            return model;
        }

        public IEnumerable<MenusViewModel> GetMenus()
        {
            var model = _menuRepository.Menus()
                .Select(c => new MenusViewModel
                {
                    Id = c.Id,
                    MenuName = c.MenuName,
                });
            return model.AsEnumerable();
        }

        public void RemoveMenu(int id)
        {
            _menuRepository.Remove(id);
        }
    }
}
