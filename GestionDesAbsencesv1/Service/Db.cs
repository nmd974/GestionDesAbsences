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
            new PromotionFactory(10);
            new ClassroomFactory(10);
            new SeanceFactory(10);
            new UserFactory(20, "étudiant");
            new UserFactory(2, "admin");
            new UserFactory(5, "formateur");
            new UserFactory(2, "secrétaire");
            new ProofFactory(10);
            new AppartenirFactory();
            new AttendanceFactory();
        }
    }
}
