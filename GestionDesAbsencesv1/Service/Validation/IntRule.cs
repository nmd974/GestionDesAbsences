using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestionDesAbsencesv1.Service
{
    class IntRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (!IsValid(charString))
                return new ValidationResult(false, $"La valeur {charString} n'est pas un nombre entier");

            return new ValidationResult(true, null);
        }

        static bool IsValid(string number)
        {
            try
            {
                int nb = Int32.Parse(number);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
