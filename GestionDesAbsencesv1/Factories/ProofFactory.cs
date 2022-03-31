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
    class ProofFactory
    {
        public ProofFactory(int number)
        {
            Random rand = new();

            List<Attendance> ListAttends = Db.Bdd.Attendances.Where(c => c.MissingType > 0).ToList();
            int ListCount = ListAttends.Count();
            ListCount -= 1;
            Proof NewProof;

            for(int x = 0; x <= number; x++)
            {
                Actions.ViewModel.Proof.Store(Faker.Lorem.Sentence(3), null, Faker.Boolean.Random());
                NewProof = Db.Bdd.Proofs.OrderBy(c => c.ProofId).Last();

                Attendance RandomAttend = ListAttends[rand.Next(0, ListCount)];
                RandomAttend.ProofId = NewProof.ProofId;
                Actions.ViewModel.Proof.Update();
                ListAttends.Remove(RandomAttend);
                ListCount = ListAttends.Count();
                ListCount -= 1;
            }
        }
    }
}
