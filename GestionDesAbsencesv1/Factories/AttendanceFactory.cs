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
            
            foreach(Seance seance in Db.Bdd.Seances.ToArray())
            { 
                List<User> Formateurs = Db.Bdd.Users.Where(c => c.Role.Label == "formateur").ToList();
                int nbrFormateur = Formateurs.Count();
                Random rand = new(); 
                User Formateur = Formateurs[rand.Next(nbrFormateur)];
                Actions.ViewModel.Attencdance.Store(
                    seance.SeanceId,
                    Formateur.UserId );

                List<User> Eleves = Db.Bdd.Users.Where(c => c.Role.Label == "étudiant").ToList();

                for (int x = 0; x < 4; x++)
                {        
                    int nbrEleve = Eleves.Count;
                    User Eleve = (User)Eleves[rand.Next(nbrEleve)];
                    List<double> absence = new() { 0.5, 1 };

                    Eleves.Remove(Eleve);

                    Actions.ViewModel.Attencdance.Store(
                        seance.SeanceId,
                        Eleve.UserId,
                        Faker.Boolean.Random(),
                        absence[rand.Next(0,1)]);
                }
              
                Array AttendanceStudent = Db.Bdd.Attendances.Where(c => c.SeanceId == seance.SeanceId).Where(d => d.User.Role.Label == "étudiant").ToArray();
                Attendance attendance =(Attendance) AttendanceStudent.GetValue(rand.Next(1, AttendanceStudent.Length));
                Actions.ViewModel.Attencdance.Proof(attendance, seance.SeanceId);
            }
            
        }
    }
}
