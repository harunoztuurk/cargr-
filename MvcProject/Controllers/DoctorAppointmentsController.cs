using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class DoctorAppointmentsController : Controller
    {
        // GET: DoctorAppointments
        DBModels db = new DBModels();
        public ActionResult Index(String p, String p2)
        {
            var degerler = from d in db.APPOINTMENTs select d;

            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.doctorName.Contains(p) && m.doctorSurname.Contains(p2));

            }
            return View(degerler.ToList());
        }
        public ActionResult DeleteAppointments(int id)
        {
            var appointments = db.APPOINTMENTs.Find(id);
            db.APPOINTMENTs.Remove(appointments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAppointments(int id)
        {
            var getdoctor = db.APPOINTMENTs.Find(id);
            return View("GetDoctor", getdoctor);
        }

        public ActionResult GetApp(int id)
        {
            var getdoctor = db.APPOINTMENTs.Find(id);
            return View("GetApp", getdoctor);
        }
        public ActionResult UpdateApp(APPOINTMENT d1)
        {
            var appn = db.APPOINTMENTs.Find(d1.appointmentID);
            appn.appointmentDate = d1.appointmentDate;
            appn.appointmentHour = d1.appointmentHour;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}