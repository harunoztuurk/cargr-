using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class DoctorLoginController : Controller
    {
        // GET: DoctorLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorise(DOCTOR doctor)
        {
            using (DBModels db = new DBModels())
            {
                var doctorDetail = db.DOCTORs.Where(x => x.doctorName == doctor.doctorName && x.doctorPassword == doctor.doctorPassword).FirstOrDefault();
                if (doctorDetail == null)
                {
                   
                    return View("Index", doctor);
                }
                else
                {

                   
                    return RedirectToAction("Index", "DoctorAppointments");
                }
            }
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "DoctorLogin");
        }
    }
}