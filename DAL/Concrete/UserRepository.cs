using DAL.Abstract;
using DAL.Entities.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    //public class UserRepository : IUserRepository
    //{
    //    private readonly IEFContext _context;
    //    public UserRepository(IEFContext context)
    //    {
    //        _context = context;
    //    }
    //    public IUser Add(AppUser user)
    //    {
    //        _context.Set<AppUser>().Add(user);
    //        return user;
    //    }

    //    public void Dispose()
    //    {
    //        if (this._context != null)
    //            this._context.Dispose();
    //    }

    //    public IQueryable<IUser> GetAllUsers()
    //    {
    //        return this._context.Set<AppUser>()/*.Include(c => c.Roles)*/;
    //    }

    //    public AppUser GetUserById(string id)
    //    {
    //        return this.GetAllUsers()
    //           /* .SingleOrDefault(c => c.Id == id)*/;
    //    }

    //    public AppUser GetUserByEmail(string email)
    //    {
    //        return this.GetAllUsers()
    //            /*.SingleOrDefault(c => c.Email == email)*/;
    //    }

    //    public IQueryable<IRole> GetRoles()
    //    {
    //        return this._context.Set<IRole>();
    //    }

    //    public IQueryable<UserRoles> GetUserRoles()
    //    {
    //        return this._context.Set<UserRoles>();
    //    }

    //    public void SaveChange()
    //    {
    //        this._context.SaveChanges();
    //    }
    //}
}
