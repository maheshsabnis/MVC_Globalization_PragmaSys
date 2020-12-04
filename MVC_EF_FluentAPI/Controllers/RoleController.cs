using Microsoft.AspNet.Identity.EntityFramework;
using MVC_EF_FluentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF_FluentAPI.Controllers
{
    public class RoleController : Controller
    {
        // create an instance of ApplicationDbContext
        ApplicationDbContext context;

		public RoleController()
		{
            context = new ApplicationDbContext();
		}

        // GET: Role
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        public ActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            context.Roles.Add(role);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}