using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class AdminHomeAppointmentController : Controller
    {
        // GET: AdminHomeAppointment
        DBModels db = new DBModels();
        public ActionResult Index()
        {
            var degerler = db.APPOINTMENTs.ToList();
            return View(degerler);
        }
    }
}