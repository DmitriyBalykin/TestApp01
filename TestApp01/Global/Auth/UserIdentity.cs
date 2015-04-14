using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TestApp01.Model;

namespace TestApp01.Global.Auth
{
    public class UserIdentity : IIdentity, IUserProvider
    {
        public User User { get; set; }
        [Inject]
        public IAuthentication Auth { get; set; }
        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }
        public bool IsAuthenticated
        {
            get { return User != null; }
        }
        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                else
                {
                    return "anonymous";
                }
            }
        }
        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }
    }
}