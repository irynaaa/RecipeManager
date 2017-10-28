using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IMenuRepository
    {
        Menu Add(Menu menu);
        IQueryable<Menu> Menus();
    }
}
