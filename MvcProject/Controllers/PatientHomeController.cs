using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class PatientHomeController : Controller
    {
        // GET: PatientHome
        DBModels db = new DBModels();
        public ActionResult Index(String p,String p2,String p3)
        {
            var degerler = from d in db.APPOINTMENTs select d;

            if (!string.IsNullOrEmpty(p) ||  !string.IsNullOrEmpty(p2) || !string.IsNullOrEmpty(p3))
            {
                degerler = degerler.Where(m => m.doctorName.Equals(p) || m.department.Equals(p2) ||m.appointmentDate.ToString().Equals(p3));
                
            }
            return View(degerler.ToList());
        }

        public ActionResult List()
        {
            var degerler = from d in db.DOCTORs select d;
            return View(degerler.ToList());
        }



        [HttpGet]
        public ActionResult AddAppointments()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAppointments(APPOINTMENT d1)
        {
            db.APPOINTMENTs.Add(d1);
            db.SaveChanges();
            return View();
        }
    }
}