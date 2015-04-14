using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp01.Model;

namespace TestAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataContext = new TestAppDbDataContext(ConfigurationManager.ConnectionStrings["WebTestDBConnectionString"].ConnectionString);

            IEnumerable<User> roles = dataContext.Roles.Where(role => role.Code.Equals("admin")).SelectMany(p => p.UserRoles).Select(p => p.User);

            foreach (var role in roles)
            {
                Console.WriteLine("{0} {1} {2}", role.Id, role.Name, role.LastVisitDate);
            }

            Console.ReadLine();
        }
    }

    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }
}
