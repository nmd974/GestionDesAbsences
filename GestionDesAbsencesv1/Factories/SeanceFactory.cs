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
        List<Promotion> _promotions = Db.Bdd.Promotions.ToList();
        Random _rand = new Random();
        public SeanceFactory(int number)
        {
            Random rand = new();
            List<Classroom> listClassroom = Db.Bdd.Classrooms.ToList();
            Classroom lastClassroom = listClassroom.OrderBy(c => c.ClassroomId).Last(); 
            List<Promotion> listPromo = Db.Bdd.Promotions.ToList();
            Promotion lastPromo = listPromo.OrderBy(c => c.PromotionId).Last();
            List<User> FormateurList = Db.Bdd.Users.Where(c => c.Role.Label == "formateur").ToList();
            int nbrFormateur = FormateurList.Count();
            nbrFormateur -= 1;

            for (int x = 0; x <= number; x++)
            {
                int randomClassroomId = rand.Next(1, lastClassroom.ClassroomId);
                DateTime dateTime = new(2022, _rand.Next(1, 12), _rand.Next(1, 28));
                Actions.ViewModel.Seance.Store(randomClassroomId, $"seance {x}", dateTime.ToString());
            }

            List<Seance> ListSeances = Db.Bdd.Seances.ToList();

            foreach (Seance seance in ListSeances)
            {
                int randomPromoId = rand.Next(1, lastPromo.PromotionId);
                List<Appartenir> Listapps = Db.Bdd.Appartenirs.Where(c => c.PromotionId == randomPromoId).ToList();
                User Formateur = FormateurList[rand.Next(0, nbrFormateur)];

                Actions.ViewModel.Attencdance.Store(seance.SeanceId, Formateur.UserId);

                foreach(Appartenir apps in Listapps)
                {
                    Actions.ViewModel.Attencdance.Store(seance.SeanceId, apps.UserId);
                }
            }
        }
    }
}
