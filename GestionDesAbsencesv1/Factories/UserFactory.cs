using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using GestionDesAbsencesv1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.Factories
{
    class UserFactory
    {
        public UserFactory(int number, string rol)
        {
            for (int x = 0; x <= number; x++)
            {
                Role role = Db.Bdd.Roles.Where(c=> c.Label == rol).First();
                Actions.ViewModel.User.Store(
                    Faker.Name.First(), 
                    Faker.Name.Last(), 
                    Faker.Internet.Email(), 
                    role );
            }
        }
    }
}
