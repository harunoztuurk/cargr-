using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class AdminHomeFeedbackController : Controller
    {
        // GET: AdminHomeFeedback
        DBModels db = new DBModels();
        public ActionResult Index()
        {
            var degerler = db.FEEDBACKs.ToList();
            return View(degerler);
        }
    }
}