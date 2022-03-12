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
    class ClassroomViewModel
    {
        readonly DbSet<Classroom> DBCLASSROOM = Db.Bdd.Classrooms;
        ObservableCollection<Classroom> _listClassroom = new();

        public ClassroomViewModel()
        {
            Index();
        }

        public ObservableCollection<Classroom> ListClassroom
        {
            get
            {
                return _listClassroom;
            }
            set
            {
                _listClassroom = value;
            }
        }

        void Index()
        {
            foreach (Classroom Class in DBCLASSROOM)
            {
                _listClassroom.Add(Class);
            }
        }

        public void Store(string label)
        {
            Classroom NewClass = new() { Label = label };

            DBCLASSROOM.Add(NewClass);
            Db.Bdd.SaveChanges();
        }

        public void Update()
        {
            _ = Db.Bdd.SaveChanges();
        }

        public void Delete(Classroom Class)
        {
            DBCLASSROOM.Remove(Class);
            _ = Db.Bdd.SaveChanges();
        }

    }
}
