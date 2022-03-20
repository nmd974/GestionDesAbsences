using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestionDesAbsencesv1.Service
{
    class EmailRules : ValidationRule
    {
        public override ValidationResult Validate(object value,CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, $"Merci de saisir un mail");
                string charString = value as string;

                if (charString.Length < 4)
                    return new ValidationResult(false, $"Merci de saisir min 4 characters.");
                if (!IsValid(charString))
                    return new ValidationResult(false, $"Merci de saisir une adresse mail valide");

            return ValidationResult.ValidResult;
        }
        static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new (emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
