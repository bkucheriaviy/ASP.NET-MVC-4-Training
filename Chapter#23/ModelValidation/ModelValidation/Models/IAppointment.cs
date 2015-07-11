using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    public interface IAppointment
    {
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Error")]
        [Remote("CheckName", "Home")]
        string ClientName { get; set; }

        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Please enter a date in future")]
        DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        bool TermsAccepted { get; set; }
    }
}