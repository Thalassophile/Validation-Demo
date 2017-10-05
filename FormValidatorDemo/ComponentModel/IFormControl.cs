using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormValidatorDemo.ComponentModel
{
    internal interface IFormControl
    {
        bool IsError { get; set; }

        bool IsMandatory { get; set; }

        string HeaderName { get; set; }

        void ValidateData();
    }
}
