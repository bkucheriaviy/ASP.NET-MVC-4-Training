using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Infrastructure
{
    public class FutureDate : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && ((DateTime) value).Date > DateTime.Now.Date;
        }
    }
}
