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
    class AttencdanceViewModel
    {
        readonly DbSet<Attendance> DBATTEN = Db.Bdd.Attendances;
        ObservableCollection<Attendance> _listAtten = new();

        public AttencdanceViewModel()
        {
            Index();
        }

        public ObservableCollection<Attendance> ListAttendance
        {
            get
            {
                return _listAtten;
            }
            set
            {
                _listAtten = value;
            }
        }

        void Index()
        {
            foreach (Attendance atten in DBATTEN)
            {
                _listAtten.Add(atten);
            }
        }
        public void Store(int seanceId, int userId, bool late = false, double missingType = 0.0)
        {
            Attendance NewAtten = new() 
            {
                Late = late,
                MissingType = missingType,
                SeanceId = seanceId,
                UserId = userId
            };

            DBATTEN.Add(NewAtten);
            Db.Bdd.SaveChanges();
        }

        public void Proof(Attendance attendance, int proofId)
        {
            attendance.ProofId = proofId;
            Update();
        }

        public void Update()
        {
            Db.Bdd.SaveChanges();
        }

        public void Delete(Attendance atten)
        {
            DBATTEN.Remove(atten);
            Db.Bdd.SaveChanges();
        }
    }
}
