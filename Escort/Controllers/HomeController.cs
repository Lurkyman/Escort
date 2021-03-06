﻿using Escort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Escort.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Angels()
        {
            return View();
        }
        public ActionResult AngelInfor()
        {
            return View();
        }


        // Admin login from here

        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminManage(string q , int p=1)
        {
            ViewBag.Error = TempData.ContainsKey("Error")? TempData["Error"]: "" ;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (!String.IsNullOrEmpty(q))
                {
                    List<AccountList> AccountList = db.Users.Where(t => !MyHelper.adminEmail.Contains(t.Email) &&
                       (t.Email.Contains(q) || (t.FirstName.Contains(q) || (t.LastName.Contains(q)) || (t.Contact.Contains(q))))
                       ).OrderByDescending(t => t.LastLogin).Skip(0).Take(15).Select(t => new AccountList
                       {
                           Id = t.Id,
                           UserName = t.UserName,
                           LastLogin = t.LastLogin,
                           Email = t.Email,
                           FirstName = t.FirstName,
                           LastName = t.LastName,
                           Contact = t.Contact,
                           IsDisabled = t.IsDisabled,
                           IsLocked = t.IsLocked
                       }).ToList();
                            return View(AccountList);
                }else
                {
                    List<AccountList> AccountList = db.Users.Where(t => !MyHelper.adminEmail.Contains(t.Email)).OrderByDescending(t => t.LastLogin).Skip(0).Take(15).Select(t => new AccountList
                       {
                           Id = t.Id,
                           UserName = t.UserName,
                           LastLogin = t.LastLogin,
                           Email = t.Email,
                           FirstName = t.FirstName,
                           LastName = t.LastName,
                           Contact = t.Contact,
                           IsDisabled = t.IsDisabled,
                           IsLocked = t.IsLocked
                       }).ToList();
                    return View(AccountList);
                }


               
            }
           
        }

      


    }
}