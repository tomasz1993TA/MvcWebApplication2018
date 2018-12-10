using MvcWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApplication.Controllers
{
    public class UsersController : Controller
    {
        Entities db = new Entities();
        // GET: UsersDB
        public ActionResult Users()
        {
            return View(db.AspNetUsers.ToList());
        }
    }
}