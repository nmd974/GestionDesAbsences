using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class RoleViewModel
    {
        readonly DbSet<Role> DBROLE = Db.Bdd.Roles;
        ObservableCollection<Role> _listRoles = new();

        public RoleViewModel()
        {
            Index();
        }

        public ObservableCollection<Role> ListRoles
        {
            get
            {
                return _listRoles;
            }
            set
            {
                _listRoles = value;
            }
        }

        void Index()
        {
            foreach(Role role in DBROLE)
            {
                _listRoles.Add(role);
            }
        }

        public void Store(string label)
        {
            Role NewRole = new() { Label = label };

            DBROLE.Add(NewRole);
            Db.Bdd.SaveChanges();
        }

        public void Update(Role role)
        {
            Role UpdateRole = DBROLE.Find(role.RoleId);
            UpdateRole = role;
            Db.Bdd.SaveChanges();
        }

        public void Delete(Role role)
        {
            DBROLE.Remove(role);
            Db.Bdd.SaveChanges();
        }
    }
}
