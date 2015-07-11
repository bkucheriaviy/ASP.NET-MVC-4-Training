using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    [NoJoe(ErrorMessage="Remember! No JOE.")]
    public class Appointment: IAppointment
    {
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage="Error")]
        [Remote("CheckName", "Home")]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Please enter a date in future")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}
