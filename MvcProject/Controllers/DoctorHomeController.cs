using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class DoctorHomeController : Controller
    {
        // GET: DoctorHome

        DBModels db = new DBModels();
        public ActionResult Index()
        {
            string x = Session["SessionAdi"].ToString();
            var degerler = from d in db.DOCTORs select d;
            
            if (degerler != null)
            {
                degerler = degerler.Where(m => m.doctorID.ToString().Contains("1"));
            }
               
            return View(degerler.ToList());
        }
       
            

           
       

    }
}