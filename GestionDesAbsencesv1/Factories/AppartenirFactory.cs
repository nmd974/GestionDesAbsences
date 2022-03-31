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
            Random rand = new();
            foreach (User user in Db.Bdd.Users.Where(c => c.Role.Label == "étudiant").ToArray())
            {
                List<Promotion> listPromo = Db.Bdd.Promotions.ToList();
                Promotion LastPromo = listPromo.OrderBy(c => c.PromotionId).Last();
                int RandomPromoId = rand.Next(1, LastPromo.PromotionId);
                
                Actions.ViewModel.Appartenir.Store(user.UserId, RandomPromoId);
            }
        }
    }
}
