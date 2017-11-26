using BLL.Abstract;
using BLL.ViewModels;
using BLL.ViewModels.Identity;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    //public class UserProvider : IUserProvider
    //{
    //    IUserRepository _userRepository;
    //    IRoleRepository _roleRepository;

    //    public UserProvider(IUserRepository userRepository, IRoleRepository roleRepository)
    //    {

    //        _userRepository = userRepository;
    //        _roleRepository = roleRepository;
    //    }



    //    //public int DeleteUserRole(int userId, int roleId)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}


    //    IEnumerable<SelectRoleViewModel> IUserProvider.GetSelectRoles()
    //    {
    //        return _userRepository.GetAllUsers()
    //            .Select(c => new SelectRoleViewModel
    //            {
    //                Id = c.Id,
    //                // Name = c.Email,
    //            });
    //    }


    //    IEnumerable<UserViewModel> IUserProvider.GetUsers()
    //    {
    //        //var model = _userRepository.GetAllUsers()
    //        //    .Select(c => new UserViewModel
    //        //    {
    //        //        Id = c.Id,
    //        //        Email = c.Email,
    //        //        Role = c.Roles.FirstOrDefault(u => u.Id == c.Id)


    //        //    });

    //        var model = _userRepository.GetAllUsers()
    //            .Select(u => new UserViewModel
    //            {
    //                Id = u.Id,
    //                //Email = u.Email,
    //                //Roles = u.Roles.Select(r => new SelectRoleViewModel
    //                //{
    //                //    Id = r.Id,
    //                //    Name = r.Name
    //                //})
    //            });
    //        return model.AsEnumerable();
    //    }



    //    public int DeleteUserRole(int userId, int roleId)
    //    {
    //        //var role = _roleRepository.GetRoleById(roleId);
    //        //if (role != null)
    //        //{
    //        //    var user = _userRepository.GetUserById(userId);
    //        //    if (user != null)
    //        //    {
    //        //        user.Roles.Remove(role);
    //        //        _userRepository.SaveChange();
    //        //        return 1;
    //        //    }
    //        //}
    //        return 0;
    //    }
    //}
}
