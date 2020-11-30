using MVC_Globalization.Models;
using RourcesProvider;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Globalization.Controllers
{
    public class StudentController : Controller
    {
        /// <summary>
        /// This method will check the Session object
        /// in current request
        /// </summary>
        /// <param name="requestContext"></param>
		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
            // if the request sends the new culture in Request
            // using Session object
            if (Session["Culture"] != null)
            {
                Thread.CurrentThread.CurrentCulture
                    = new CultureInfo(Session["Culture"].ToString());
                Thread.CurrentThread.CurrentUICulture
                    = new CultureInfo(Session["Culture"].ToString());
            }
		}
        /// <summary>
        /// The Post method that will accept POST request to the 
        /// to select new culture
        /// </summary>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetNewCulture(string  cultureName)
        {
            // apply the new Culture
            Thread.CurrentThread.CurrentCulture
                   = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture
                = new CultureInfo(cultureName);
            // set this new culture to the session object
            Session["Culture"] = cultureName;

            // pass the list of available cultures to UI
            // so that end-user can select the culture
            ViewBag.Cultures = new[] {
                new {cultureName="en-US", cultureText = "English" },
                new {cultureName="fr-FR", cultureText = "French" },
            };
            return View("Create");
        }


		// GET: Student
		public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var student = new Student();
            // pass the list of available cultures to UI
            // so that end-user can select the culture
            ViewBag.Cultures = new[] {
                new {cultureName="en-US", cultureText = "English" },
                new {cultureName="fr-FR", cultureText = "French" },
            };
            return View(student);
        }

        [HttpPost]
        public ActionResult Create(Student st)
        {
            // pass the list of available cultures to UI
            // so that end-user can select the culture
            ViewBag.Cultures = new[] {
                new {cultureName="en-US", cultureText = "English" },
                new {cultureName="fr-FR", cultureText = "French" },
            };
            if (ModelState.IsValid)
            {
                // do some operations
                // logic to write the data in database
                // redirect to Index Page
                var student = new Student();
                return View(student);
            }
            return View(st);
           
        }
    }
}