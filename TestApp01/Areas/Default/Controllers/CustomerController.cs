using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp01.Controllers;
using TestApp01.Models.Info;

namespace TestApp01.Areas.Default.Controllers
{
    public class CustomerController : BaseController
    {
        //
        // GET: /Default/Customer/
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(
                new Customer()
                {
                    Ownerships = new Dictionary<string, Ownership>()
                }
                );
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if(ModelState.IsValid)
            {

            }
            return View(customer);
        }

    }
}
