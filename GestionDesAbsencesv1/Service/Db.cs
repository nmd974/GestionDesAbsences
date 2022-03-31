using GestionDesAbsencesv1.Factories;
using GestionDesAbsencesv1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.Service
{
    class Db
    {
        static public AbsenceBddContext Bdd = new();
        static public ConfigSetting Config = new("AppSettings.json");

        public static void Seed()
        {
            new RoleFactory();
            new PromotionFactory(3);
            new ClassroomFactory(5); 
            new UserFactory(40, "étudiant");
            new UserFactory(2, "admin");
            new UserFactory(5, "formateur");
            new UserFactory(2, "secrétaire");
            new AppartenirFactory();
            new SeanceFactory(30);
            new AttendanceFactory();
            new ProofFactory(10);
        }
    }
}
