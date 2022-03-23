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
    class AppartenirFactory
    {
        public AppartenirFactory()
        {
            foreach(User user in Db.Bdd.Users.Where(c => c.Role.Label == "étudiant").ToArray())
            {
                int promotion = Faker.RandomNumber.Next(1,10);
                Actions.ViewModel.Appartenir.Store(user.UserId, promotion);
            }
        }
    }
}
