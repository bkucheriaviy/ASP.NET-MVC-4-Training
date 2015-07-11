using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class AppointmentWithValidation: IValidatableObject, IAppointment
    {
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }

       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
       {
           var errors = new List<ValidationResult>();
           if (string.IsNullOrEmpty(ClientName))
               errors.Add(new ValidationResult("Please enter your name"));
           if (Date.Date <= DateTime.Now.Date)
               errors.Add(new ValidationResult("Please enter a date in the future"));
           if (!TermsAccepted)
               errors.Add(new ValidationResult("You must accept the terms"));
           if (errors.Count == 0 && ClientName.Trim().ToLower() == "joe")
               errors.Add(new ValidationResult("Again!!! NO, JOE!"));
           return errors;
       }
    }
}
