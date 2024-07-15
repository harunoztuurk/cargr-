using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class PatientHomeFeedbackController : Controller
    {
        // GET: PatientHomeFeedback
        DBModels db = new DBModels();
        public ActionResult Index()
        {
            var degerler = from d in db.FEEDBACKs select d;
            return View(degerler.ToList());
        }


        public ActionResult List()
        {
            var degerler = from d in db.DOCTORs select d;
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult AddFeedbacks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeedbacks(FEEDBACK f1)
        {
            db.FEEDBACKs.Add(f1);
            db.SaveChanges();
            return View();
        }
    }
}