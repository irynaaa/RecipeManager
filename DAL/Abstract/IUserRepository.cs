using DAL.Entities.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IUserRepository : IDisposable
    {
        AppUser Add(AppUser user);
        IQueryable<AppUser> GetAllUsers();
        IQueryable<AppRole> GetRoles();
        AppUser GetUserByEmail(string email);
        AppUser GetUserById(string id);
        void SaveChange();
    }
}
