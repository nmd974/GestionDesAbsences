using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestionDesAbsencesv1.Service
{
    class RequiredRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            charString.Trim();

            if (charString.Length == 0)
                return new ValidationResult(false, $"Ce champ est obligatoire");

            return new ValidationResult(true, null);
        }
    }
}
