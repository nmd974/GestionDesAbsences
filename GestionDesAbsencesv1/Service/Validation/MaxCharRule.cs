using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestionDesAbsencesv1.Service
{
    class MaxCharRule : ValidationRule
    {
        public int MaxCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (charString.Length > MaxCharacters)
                return new ValidationResult(false, $"Merci de ne pas saisir plus de {MaxCharacters} characters.");

            return new ValidationResult(true, null);
        }
    }
}
