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
    class SeanceViewModel
    {
        readonly DbSet<Seance> DBSEANCE = Db.Bdd.Seances;
        ObservableCollection<Seance> _listSeance = new();

        public SeanceViewModel()
        {
            Index();
        }

        public ObservableCollection<Seance> ListSeance
        {
            get
            {
                return _listSeance;
            }
            set
            {
               _listSeance = value;
            }
        }

        void Index()
        {
            foreach (Seance seance in DBSEANCE)
            {
                _listSeance.Add(seance);
            }
        }

        public void Store(int classroomId, int seanceId, string label, string dateTime)
        {
            Seance NewSeance = new() 
            {
                ClassroomId = classroomId,
                SeanceId = seanceId,
                Label = label,
                Datetime = dateTime
            };

            DBSEANCE.Add(NewSeance);
            Db.Bdd.SaveChanges();
        }

        public void Update()
        {
            Db.Bdd.SaveChanges();
        }

        public void Delete(Seance seance)
        {
            DBSEANCE.Remove(seance);
            Db.Bdd.SaveChanges();
        }
    }
}
