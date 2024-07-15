using System.Linq;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class PatientLoginController : Controller
    {
        private readonly DBModels db = new DBModels();

        // GET: PatientLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(PATIENT patient)
        {
            if (ModelState.IsValid)
            {
                var patientDetail = db.PATIENTs.FirstOrDefault(x => x.patientName == patient.patientName && x.patientPassword == patient.patientPassword);
                if (patientDetail == null)
                {
                    ViewBag.ErrorMessage = "Invalid username or password";
                    return View("Index", patient);
                }
                else
                {
                    // Assuming you have a session management or authentication mechanism
                    Session["PatientID"] = patientDetail.PatientID;
                    return RedirectToAction("Index", "PatientHome");
                }
            }
            return View("Index", patient);
        }

        [HttpGet]
        public ActionResult RegisterPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterPatient(PATIENT patient)
        {
            if (ModelState.IsValid)
            {
                db.PATIENTs.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
