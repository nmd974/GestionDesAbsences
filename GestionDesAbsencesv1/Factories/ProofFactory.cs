using GestionDesAbsencesv1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.Factories
{
    class ProofFactory
    {
        public ProofFactory(int number)
        {
            for (int x = 0; x <= number; x++)
            {
                Actions.ViewModel.Proof.Store(Faker.Lorem.Sentence(3));
            } 
        }
    }
}
