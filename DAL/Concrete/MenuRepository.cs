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
        public Menu Add(Menu menu)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Menu> Menus()
        {
            throw new NotImplementedException();
        }
    }
}
