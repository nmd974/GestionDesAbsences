using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class ClassroomViewModel : INotifyPropertyChanged
    {
        readonly DbSet<Classroom> DBCLASSROOM = Db.Bdd.Classrooms;
        List<Classroom> _listClassroom = new();
        public int IdConcerned = 0;
        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ClassroomViewModel()
        {
            Index();
        }

        public List<Classroom> ListClassroom
        {
            get
            {
                return _listClassroom;
            }
            set
            {
                _listClassroom = value;
                OnPropertyChanged(nameof(ListClassroom));
            }
        }

        public void Index()
        {
            ListClassroom = Db.Bdd.Classrooms.ToList();
        }

        public void Store(string label)
        {
            Classroom NewClass = new() { Label = label };

            DBCLASSROOM.Add(NewClass);
            ListClassroom.Add(NewClass);
            Db.Bdd.SaveChanges();
        }

        public void Update()
        {
            Db.Bdd.SaveChanges();
        }

        public void Delete(Classroom Class)
        {
            var itemToRemove = ListClassroom.Single(r => r.ClassroomId == IdConcerned);
            ListClassroom.Remove(itemToRemove);
            DBCLASSROOM.Remove(Class);
            Db.Bdd.SaveChanges();
        }

    }
}
