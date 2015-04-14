using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TestApp01.Model
{
    public partial class User
    {
        public string ConfirmPassword { get; set; }
        public string Captcha { get; set; }
        public string ActivateAction
        {
            get
            {
                return ActivatedDate == null ? "Activate" : "Deactivate";
            }
        }
        public static string GetActivateUrl()
        {
            return Guid.NewGuid().ToString("N");
        }
        public bool InRoles(string roles)
        {
            if (string.IsNullOrEmpty(roles))
            {
                return false;
            }
            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = UserRoles.Any(ur => string.Compare(ur.Role.Code, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }
    }
}