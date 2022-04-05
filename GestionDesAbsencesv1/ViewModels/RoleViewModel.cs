using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class RoleViewModel : INotifyPropertyChanged
    {
        readonly DbSet<Role> DBROLE = Db.Bdd.Roles;
        List<Role> _listRoles = new();
        public int IdConcerned = 0;

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public RoleViewModel()
        {
            Index();
        }

        public List<Role> ListRoles
        {
            get
            {
                return _listRoles;
            }
            set
            {
                _listRoles = value;
                OnPropertyChanged(nameof(ListRoles));
            }
        }

        public void Index()
        {
            ListRoles = Db.Bdd.Roles.ToList();
            System.Diagnostics.Debug.WriteLine(ListRoles);
        }

        public void Store(string label)
        {
            Role NewRole = new() { Label = label };

            DBROLE.Add(NewRole);
            ListRoles.Add(NewRole);
            Db.Bdd.SaveChanges();
        }

        public void Update()
        {
            Db.Bdd.SaveChanges();
        }

        public void Delete(Role role)
        {
            var itemToRemove = ListRoles.Single(r => r.RoleId == IdConcerned);
            ListRoles.Remove(itemToRemove);
            DBROLE.Remove(role);
            Db.Bdd.SaveChanges();
        }

    }
}
