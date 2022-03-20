using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestionDesAbsencesv1.Service
{
    class DateRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (!IsValid(charString))
                return new ValidationResult(false, $"La valeur {charString} n'est pas un nombre entier");

            return new ValidationResult(true, null);
        }

        static bool IsValid(string date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
