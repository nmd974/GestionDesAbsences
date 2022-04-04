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
    class PromotionViewModel
    {
        readonly DbSet<Promotion> DBPROMOTION = Db.Bdd.Promotions;
        ObservableCollection<Promotion> _listPromotion = new();
        string _idPromotion;
        public string PromotionId
        {
            set
            {
                _idPromotion = value;
            }
        }
        public PromotionViewModel()
        {
            Index();
        }

        public ObservableCollection<Promotion> ListPromotion
        {
            get
            {
                return _listPromotion;
            }
            set
            {
                _listPromotion = value;
            }
        }

        void Index()
        {
            foreach (Promotion promotion in DBPROMOTION)
            {
                _listPromotion.Add(promotion);
            }
        }

        public void Store(string label)
        {
            Promotion NewPromotion = new() { Label = label };

            DBPROMOTION.Add(NewPromotion);
            Db.Bdd.SaveChanges();
        }

        public void Update()
        {
            Db.Bdd.SaveChanges();
        }

        public void Delete(Promotion promotion)
        {
            DBPROMOTION.Remove(promotion);
            Db.Bdd.SaveChanges();
        }

        /// <summary>
        ///  Retourne la liste des étudiants dans la promotion selectionnée
        ///  /// <param name="_idPromotion"></param>
        /// </summary>
        public List<User> getPromotionsStudents()
        {
            var result = Db.Bdd.Appartenirs
           .Where(a => a.PromotionId == Int32.Parse(_idPromotion))
           .Select(s => new User
           {
               FirstName = s.User.FirstName,
               LastName = s.User.LastName,
           })
           .ToList();
            return result;
        }

    }
}
