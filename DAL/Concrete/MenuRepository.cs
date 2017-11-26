using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Concrete
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IEFContext _context;
        public MenuRepository(IEFContext context)
        {
            _context = context;
        }

        public Menu Add(Menu menu)
        {
            _context.Set<Menu>().Add(menu);
            return menu;
        }

        public IQueryable<Menu> Menus()
        {
            return this._context.Set<Menu>();
        }

        public Menu GetMenuById(int id)
        {
            return this.Menus()
                .SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            var menu = this.GetMenuById(id);
            if (menu != null)
            {
                _context.Set<Menu>().Remove(menu);
                this.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        
    }
}
