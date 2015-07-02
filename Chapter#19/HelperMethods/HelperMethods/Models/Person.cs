using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelperMethods.Models
{
    public class Person
    {
        [HiddenInput(DisplayValue=false)]
        public int PersonId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        [DisplayName("Approved")]
        public bool IsApproved { get; set; }
      
        public Role Role { get; set; }
    }
}