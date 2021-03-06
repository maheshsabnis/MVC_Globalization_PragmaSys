﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF_FluentAPI.Models;

namespace MVC_EF_FluentAPI.Controllers
{
    public class CustomerController : Controller
    {

        PragmaSysFluentDbContext ctx;
        public CustomerController()
        {
            ctx = new PragmaSysFluentDbContext();
        }

        // GET: Customer
       // [Authorize(Users ="mahesh@msit.com,tejas@msit.com,ajay@msit.com")]
       [Authorize(Roles ="Admin,Manager,Clerk")]
        public ActionResult Index()
        {
            var result = ctx.Customers.ToList();
            return View("Index",result);
        }

        public ActionResult IndexWithHelper()
        {
            var result = ctx.Customers.ToList();
            return View(result);
        }
        //[Authorize(Users = "mahesh@msit.com,tejas@msit.com")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            var cust = new Customer();
            return View(cust);
        }

        [HttpPost]
        public ActionResult Create(Customer cust)
        {
            ctx.Customers.Add(cust);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}