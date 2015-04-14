using TestApp01.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp01.Model
{
    public partial class SQLRepository : IRepository
    {
        [Inject]
        public TestAppDbDataContext Db { get; set; }
    }
}