using System;
using System.Web.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MakeBooking()
        {
            return View(new Appointment
            {
                Date = DateTime.Now
            });
        }

        [HttpPost]
        public ActionResult MakeBooking(Appointment app)
        {
            if (string.IsNullOrEmpty(app.ClientName))
                ModelState.AddModelError("ClientName", "Please enter your name");
            if (app.Date.Date <= DateTime.Now.Date)
                ModelState.AddModelError("Date", "Please enter a date in the future");
            if (!app.TermsAccepted)
                ModelState.AddModelError("TermsAccepted", "You must accept the terms");
            if (!ModelState.IsValid)
                return View();
            return View("Completed", app);
        }

        public ActionResult MakeBookingWithModelBinderValidation()
        {
            return View("MakeBooking", new Appointment
            {
                Date = DateTime.Now
            });
        }

        [HttpPost]
        public ActionResult MakeBookingWithModelBinderValidation(Appointment app)
        {
            if (!ModelState.IsValid)
                return View("MakeBooking");
            return View("Completed", app);
        }
        public ActionResult MakeBookingWithValidateableModel()
        {
            return View("MakeBooking", new AppointmentWithValidation
            {
                Date = DateTime.Now
            });
        }

        [HttpPost]
        public ActionResult MakeBookingWithValidateableModel(AppointmentWithValidation app)
        {
            if (!ModelState.IsValid)
                return View("MakeBooking");
            return View("Completed", app);
        }

        public JsonResult CheckName(string clientName)
        {
            if (clientName.Trim().ToLower() == "joe")
                return Json("This name is already using.", JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
