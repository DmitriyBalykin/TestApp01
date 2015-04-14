using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp01.Model;

namespace TestApp01.Global.Auth
{
    interface IUserProvider
    {
        User User { get; set; }
    }
}
