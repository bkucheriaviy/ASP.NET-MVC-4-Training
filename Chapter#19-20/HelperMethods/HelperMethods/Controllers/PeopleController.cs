using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private readonly Person[] _personData =
        {
            new Person {FirstName = "Greg", LastName = "Heig", Role = Role.Admin},
            new Person {FirstName = "Goil", LastName = "Hogwarts", Role = Role.Admin},
            new Person {FirstName = "Ron", LastName = "Weasley", Role = Role.User},
            new Person {FirstName = "Hermione", LastName = "Granger", Role = Role.User},
            new Person {FirstName = "Harry", LastName = "Potter", Role = Role.Guest}
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxFormExample(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }

      
        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            var data = GetData(selectedRole);
            return PartialView(data.ToArray());
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            var data = GetData(selectedRole).Select(i => new
            {
                i.FirstName,
                i.LastName,
                Role = Enum.GetName(typeof (Role), i.Role)
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Person> GetData(string selectedRole)
        {
            if (selectedRole == "All")
                return _personData.ToList();
            var selected = (Role)Enum.Parse(typeof(Role), selectedRole);
            return _personData.Where(p => p.Role == selected).ToList();
        }
    }
}
