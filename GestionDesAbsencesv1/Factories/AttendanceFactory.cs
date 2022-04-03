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
    class AttendanceFactory
    {
        public AttendanceFactory()
        {
            Random rand = new();
            List<Attendance> listAttendances = Db.Bdd.Attendances.Where(c => c.User.Role.Label == "étudiant").ToList();
            double[] missing = new double[4] { 0, 0.5, 1.0, 1 }; 

            foreach(Attendance attends in listAttendances)
            {
                attends.MissingType = missing[rand.Next(0, 3)];
                attends.Late = Faker.Boolean.Random();
                Actions.ViewModel.Attencdance.Update();
            }
            
        }
    }
}
