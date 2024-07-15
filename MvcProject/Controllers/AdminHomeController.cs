using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class AdminHomeController : Controller
    {

        // GET: AdminHome
        DBModels db = new DBModels();
        public ActionResult Index(String p, String p2)
        {
            var degerler = from d in db.DOCTORs select d;
            
            if (!string.IsNullOrEmpty(p))
            {
                 degerler = degerler.Where(m => m.department.Contains(p) && m.doctorName.Contains(p2));
                
            }
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDoctor(DOCTOR d1)
        {
            db.DOCTORs.Add(d1);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteDoctor(int id)
        {
            var doctor = db.DOCTORs.Find(id);
            db.DOCTORs.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDoctor(int id)
        {
            var getdoctor = db.DOCTORs.Find(id);
            return View("GetDoctor", getdoctor);
        }
        public ActionResult UpdateDoctor(DOCTOR d1)
        {
            var doctor = db.DOCTORs.Find(d1.doctorID);
            doctor.doctorName = d1.doctorName;
            doctor.doctorSurname = d1.doctorSurname;
            doctor.department = d1.department;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}