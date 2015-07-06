using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly Person[] _personData =
        {
            new Person {PersonId= 1,FirstName = "Greg", LastName = "Heig",BirthDate = DateTime.Now, Role = Role.Admin},
            new Person {PersonId= 2,FirstName = "Goil", LastName = "Hogwarts",BirthDate = DateTime.Now, Role = Role.Admin},
            new Person {PersonId= 3,FirstName = "Ron", LastName = "Weasley",BirthDate = DateTime.Now, Role = Role.User},
            new Person {PersonId= 4,FirstName = "Hermione", LastName = "Granger",BirthDate = DateTime.Now, Role = Role.User},
            new Person {PersonId= 5,FirstName = "Harry", LastName = "Potter",BirthDate = DateTime.Now, Role = Role.Guest}
        };

        public ActionResult Index(int? id = 1)
        {
            return View(_personData.First(p => p.PersonId == id));
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("Index", person);
        }

        public ActionResult DisplaySummary([Bind(Prefix = "Address",Exclude="Country")]AddressSummary addressSummary)
        {
            return View(addressSummary);
        }

        public ActionResult Names(IList<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }
        public ActionResult Addresses(IList<AddressSummary> addresses)
        {
            addresses = addresses ?? new List<AddressSummary>();
            return View(addresses);
        }
        public ActionResult ManualAddressesBind()
        {
            var addresses = new List<AddressSummary>();
            UpdateModel(addresses, new FormValueProvider(ControllerContext));
            return View("Addresses", addresses);
        }

        public ActionResult SecondManualAddressesBind(FormCollection formData)
        {
            var addresses = new List<AddressSummary>();
            UpdateModel(addresses, formData);
            return View("Addresses", addresses);
        }
    }
}
