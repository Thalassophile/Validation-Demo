using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormValidatorDemo.Model
{
    internal class ValidationError
    {
        public ValidationErrors ErrorType { get; set; }

        public string ErrorMessage { get; set; }
    }

    internal enum ValidationErrors
    {
        ID,
        Description,
        LocationLost,
        PersonName,
        ContactNo,
        AdminNo,
        DateLost
    }
}
