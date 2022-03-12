using GestionDesAbsencesv1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class DataContextViewModel
    {
        public DataContextViewModel()
        {
            Db.Bdd.Database.EnsureCreated();
        }

        RoleViewModel _roles = new();


        public RoleViewModel Roles
        {
            get
            {
                return _roles;
            }
        }
    }
}
