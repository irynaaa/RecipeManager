using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRoleRepository : IDisposable
    {
        IRole Add(IRole user);
        IQueryable<IRole> GetAllRoles();
        IQueryable<IRole> GetRoles();
        IRole GetRoleById(string id);

        void SaveChange();
    }
}
