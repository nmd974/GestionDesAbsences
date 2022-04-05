using GestionDesAbsencesv1.Models.Form;
using GestionDesAbsencesv1.Views;
using GestionDesAbsencesv1.Views.component;
using GestionDesAbsencesv1.Views.component.Roles;
using GestionDesAbsencesv1.Views.component.Salles;
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
                Kind = "FileAccount",
                Page = new HomeFrameStudent()
            },
        };

        static public List<Boutton> ListButtonAdmin = new List<Boutton>()
        {
            new Boutton()
            {
                Content = "Rôles",
                Kind = "AccountKey",
                Page = new ListRoleView()

            },
            new Boutton()
            {
                Content = "Etudiants",
                Kind = "AccountMultiple"
            },
            new Boutton()
            {
                Content = "Formateurs",
                Kind = "AccountMultiple"
            },
            new Boutton()
            {
                Content = "Salles",
                Kind = "AccountMultiple",
                Page = new ListClassRoomView()
            },
            new Boutton()
            {
                Content = "Formations",
                Kind = "AccountMultiple"
            }
        };
    }
}
