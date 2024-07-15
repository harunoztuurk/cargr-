using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class PatientHomeContactController : Controller
    {
        // GET: PatientHomeContact
        DBModels db = new DBModels();
        public ActionResult Index(String p)
        {
            var degerler = from d in db.MESSAGEs select d;

            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.senderName.Contains(p));

            }
            return View(degerler.ToList());
        }
        public ActionResult DeleteMessage(int id)
        {
            var mesg = db.MESSAGEs.Find(id);
            db.MESSAGEs.Remove(mesg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(MESSAGE d1)
        {
            db.MESSAGEs.Add(d1);
            db.SaveChanges();
            return View();
        }

    }
}