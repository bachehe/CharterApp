﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CharterApp.Lamps
{
    public class LampValidate : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            return value == null
                ? new ValidationResult(false, "Please select one")
                : new ValidationResult(true, null);
        }
    }
}
