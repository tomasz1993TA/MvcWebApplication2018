using MvcWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApplication.Controllers
{
    public class UsersDBController : Controller
    {
        Entities db = new Entities();
        // GET: UsersDB
        public ActionResult Index()
        {
            return View(db.AspNetUsers.ToList());
        }
    }
}