using TestApp01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp01.Model
{
    public partial class SQLRepository
    {
        
        public IQueryable<User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.Id == 0)
            {
                instance.AddedDate = DateTime.Now;
                instance.ActivatedLink = User.GetActivateUrl();
                Db.Users.InsertOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUser(User instance)
        {
            User cache = Db.Users.Where(p => p.Id == instance.Id).FirstOrDefault();
            if (cache != null)
            {
                cache.Birthdate = instance.Birthdate;
                cache.AvatarPath = instance.AvatarPath;
                cache.Email = instance.Email;
                cache.ActivatedDate = instance.ActivatedDate;
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveUser(int idUser)
        {
            User instance = Db.Users.Where(p => p.Id == idUser).FirstOrDefault();
            if (instance != null)
            {
                Db.Users.DeleteOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }
        public User Login(string email, string password)
        {
            return Db.Users.FirstOrDefault(u => string.Compare(u.Email, email, true) == 0 && u.Password == password);
        }
        public User GetUser(string email)
        {
            return Db.Users.FirstOrDefault(u => string.Compare(u.Email, email, true) == 0);
        }
    }
}