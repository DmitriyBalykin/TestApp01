using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp01.Global.Auth;
using TestApp01.Model;

namespace TestApp01.Controllers
{
    public abstract class BaseController : Controller
    {
        //
        // GET: /Base/
        [Inject]
        public IRepository Repository { get; set; }
        [Inject]
        public IMapper ModelMapper { get; set; }
        [Inject]
        public IAuthentication Auth { get; set; }
        public User CurrentUser
        {
            get
            {
                return ((UserIdentity)Auth.CurrentUser.Identity).User;
            }
        }
    }
}
