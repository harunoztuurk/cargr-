using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class AdminHomePatientController : Controller
    {
        // GET: AdminHomePatient
        DBModels db = new DBModels();
        public ActionResult Index(String p)
        {
            var degerler = from d in db.PATIENTs select d;

            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.patientName.Contains(p));

            }
            return View(degerler.ToList());
        }
        public ActionResult DeletePatient(int id)
        {
            var ptn = db.PATIENTs.Find(id);
            db.PATIENTs.Remove(ptn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}