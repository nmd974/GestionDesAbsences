using GestionDesAbsencesv1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.Factories
{
    class RoleFactory
    {
        public List<string> TabRole = new() { "étudiant", "admin", "formateur", "secrétaire"};

        public RoleFactory()
        {
            foreach(string role in TabRole)
            {
                Actions.ViewModel.Roles.Store(role);
            }
        }
    }
}
