﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebApplication.Generators;

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

        public ActionResult Edit(string Id)
        {
            return View(db.AspNetUsers.Where(u => u.Id == Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(AspNetUser user)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            // var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            // var manager = new UserManager<ApplicationUser>(store);

            var currentUser = userManager.FindById(user.Id);

            currentUser.UserName = user.UserName;
            currentUser.Email = user.Email;
            currentUser.CityName = user.CityName;
            currentUser.PhoneNumber = user.PhoneNumber;

            userManager.Update(currentUser);

            return RedirectToAction("Users");
        }

        public ActionResult Details(string Id)
        {
            return View(db.AspNetUsers.Find(Id));
        }

        public ActionResult Delete(string Id)
        {
            return View(db.AspNetUsers.Find(Id));
        }

        [HttpPost]
        public ActionResult Delete(string Id, AspNetUser user)
        {
            var currentUser = db.AspNetUsers.Where(u => u.Id == Id).FirstOrDefault();

            db.AspNetUsers.Remove(currentUser);

            db.SaveChanges();

            return RedirectToAction("Users");
        }

        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Create(AspNetUser user, IdGenerator id)
        {
            user.Id = id.GetId();            

            db.AspNetUsers.Add(user);

            db.SaveChanges();

            return RedirectToAction("Users");
        }
    }
}