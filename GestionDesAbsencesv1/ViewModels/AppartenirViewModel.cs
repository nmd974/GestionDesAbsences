using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class AppartenirViewModel
    {
        readonly DbSet<Appartenir> DBAPPARTENIR = Db.Bdd.Appartenirs;
        ObservableCollection<Appartenir> _listAppartenir = new();

        public AppartenirViewModel()
        {
            Index();
        }

        void Index()
        {
            foreach (Appartenir app in DBAPPARTENIR)
            {
                _listAppartenir.Add(app);
            }
        }

        public void Store(int userId, int promotionId)
        {
            Appartenir NewAppartenir = new() 
            {
                UserId = userId,
                PromotionId = promotionId
            };

            DBAPPARTENIR.Add(NewAppartenir);
            Db.Bdd.SaveChanges();
        }

        public void Update()
        {
            Db.Bdd.SaveChanges();
        }

        public void Delete(Appartenir app)
        {
            DBAPPARTENIR.Remove(app);
            Db.Bdd.SaveChanges();
        }

    }
}
