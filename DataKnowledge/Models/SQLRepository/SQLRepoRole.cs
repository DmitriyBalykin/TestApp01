using TestApp01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp01.Model
{
    public partial class SQLRepository
    {
        public IQueryable<Role> Roles
        {
            get
            {
                return Db.Roles;
            }
        }
        public bool CreateRole(Role instance)
        {
            if(instance.Id == 0)
            {
                Db.Roles.InsertOnSubmit(instance);
                Db.Roles.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateRole(Role instance)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRole(int roleId)
        {
            Role instance = Db.Roles.FirstOrDefault(r => r.Id == roleId);
            if(instance != null)
            {
                Db.Roles.DeleteOnSubmit(instance);
                Db.Roles.Context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}