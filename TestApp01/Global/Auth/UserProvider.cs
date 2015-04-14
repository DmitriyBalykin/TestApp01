using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TestApp01.Model;

namespace TestApp01.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        public UserIdentity userIdentity { get; set; }
        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }
        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            return userIdentity.User.InRoles(role);
        }
        public UserProvider(string name, IRepository repository)
        {
            userIdentity = new UserIdentity();
            userIdentity.Init(name, repository);
        }
        public override string ToString()
        {
            return Identity.Name.ToString();
        }
    }
}