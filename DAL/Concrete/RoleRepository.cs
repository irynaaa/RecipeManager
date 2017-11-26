using DAL.Abstract;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {

        private readonly IEFContext _context;
        public RoleRepository(IEFContext context)
        {
            _context = context;
        }
        public IRole Add(IRole role)
        {
            _context.Set<IRole>().Add(role);
            return role;
        }

        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
        }

        public IQueryable<IRole> GetAllRoles()
        {
            return this._context.Set<IRole>()/*.Include(c => c.Roles)*/;
        }

        public IRole GetRoleById(string id)
        {
            return this.GetAllRoles().SingleOrDefault(r => r.Id == id);
        }

        //public Role GetUserById(int id)
        //{
        //    return this.GetAllRoles()
        //        .SingleOrDefault(c => c.Id == id);
        //}

        //public User GetUserByEmail(string email)
        //{
        //    return this.GetAllRoles()
        //        .SingleOrDefault(c => c.Email == email);
        //}

        public IQueryable<IRole> GetRoles()
        {
            return this._context.Set<IRole>();
        }

        //public IQueryable<UserRoles> GetUserRoles()
        //{
        //    return this._context.Set<UserRoles>();
        //}

        public void SaveChange()
        {
            this._context.SaveChanges();
        }

    }
}
