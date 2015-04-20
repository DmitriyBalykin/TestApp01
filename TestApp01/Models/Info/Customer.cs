using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp01.Models.Info
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IDictionary<string, Ownership> Ownerships { get; set; }
    }
}