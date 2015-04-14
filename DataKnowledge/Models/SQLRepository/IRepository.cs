using TestApp01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp01.Model
{
    public interface IRepository
    {

        #region Role

        IQueryable<Role> Roles { get; }

        bool CreateRole(Role instance);

        bool UpdateRole(Role instance);

        bool RemoveRole(int idRole);

        #endregion
        

        #region User

        IQueryable<User> Users { get; }

        bool CreateUser(User instance);

        bool UpdateUser(User instance);

        bool RemoveUser(int idUser);
        User Login(string email, string password);
        User GetUser(string email);

        #endregion
        
    }
}