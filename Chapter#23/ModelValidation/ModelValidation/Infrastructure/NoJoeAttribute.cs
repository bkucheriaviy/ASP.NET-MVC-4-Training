using System.ComponentModel.DataAnnotations;
using ModelValidation.Models;

namespace ModelValidation.Infrastructure
{
    public class NoJoeAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var appointment = value as Appointment;
            if (appointment != null)
                return appointment.ClientName.Trim().ToLower() != "joe";

            return true;
        }
    }
}
