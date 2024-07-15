using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorise(ADMIN admin)
        {
            using (DBModels db = new DBModels())
            {
                var adminDetail = db.ADMINs.Where(x => x.adminName == admin.adminName && x.adminPassword == admin.adminPassword).FirstOrDefault();
                if(adminDetail == null)
                {
                 
                    return View("Index", admin);
                }
                else
                {
                   
                    return RedirectToAction("Index", "AdminHome");
                }
            }
        }
        [HttpPost]
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}