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
    class SeanceFactory
    {
        public SeanceFactory(int number)
        {
            for (int x = 0; x <= number; x++)
            {
                int ClassroomId = Faker.RandomNumber.Next(1,10);
                Actions.ViewModel.Seance.Store(
                ClassroomId,
                Faker.Company.Name(),
                Faker.Identification.DateOfBirth().ToString());
            }
        }
    }
}
