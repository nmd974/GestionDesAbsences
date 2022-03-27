using GestionDesAbsencesv1.Models.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class ButtonsViewModel
    {
        static public List<Boutton> ListButtonsHomeStudent = new()
        {
            new Boutton()
            {
                Content = "FICHE",
                Kind = "FileAccount"
            }
        };
    }
}
