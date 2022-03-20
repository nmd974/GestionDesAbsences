using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class UserViewModel 
    {
        readonly DbSet<User> DBUSER = Db.Bdd.Users;
        ObservableCollection<User> _listUsers = new();

        public UserViewModel()
        {
            Index();
        }

        public ObservableCollection<User> ListUsers
        {
            get
            {
                return _listUsers;
            }
            set
            {
                _listUsers = value;
            }
        }

        void Index()
        {
            foreach (User User in DBUSER)
            {
                _listUsers.Add(User);
            }
        }

        public void Store(string firstname, string lastname, string mail, Role role)
        {
            User NewUser = new()
            {
                FirstName = firstname,
                LastName = lastname,
                Mail = mail,
                RoleId = role.RoleId,
            };

            DBUSER.Add(NewUser);
            Db.Bdd.SaveChanges();
        }

        public void Update()
        {
            Db.Bdd.SaveChanges();
        }

        public void Delete(User User)
        {
            DBUSER.Remove(User);
            Db.Bdd.SaveChanges();
        }
    }
}
