using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class StartPageDoctorListController : Controller
    {
        DBModels db = new DBModels();
        
        // GET: StartPageDoctorList
        public ActionResult Index(String p)
        {
            var degerler = from d in db.DOCTORs select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.department.Contains(p));
            }
            return View(degerler.ToList());
        }
    }
}