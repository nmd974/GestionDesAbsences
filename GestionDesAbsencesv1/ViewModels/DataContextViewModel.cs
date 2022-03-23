using GestionDesAbsencesv1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class DataContextViewModel
    {
        public DataContextViewModel()
        {
            Db.Bdd.Database.EnsureCreated();
        }

        RoleViewModel _roles = new();
        PromotionViewModel _promotion = new();
        UserViewModel _user = new();
        AppartenirViewModel _appartenir = new();
        ClassroomViewModel _classroom = new();
        ProofViewModel _proof = new();
        SeanceViewModel _seance = new();
        AttencdanceViewModel _attendance = new();
        LoginViewModel _login = new();

        public LoginViewModel Login
        {
            get
            {
                return _login;
            }
        }

        public RoleViewModel Roles
        {
            get
            {
                return _roles;
            }
        }

        public PromotionViewModel Promotion
        {
            get
            {
                return _promotion;
            }
        }
        public UserViewModel User
        {
            get
            {
                return _user;
            }
        }
        public AppartenirViewModel Appartenir
        {
            get
            {
                return _appartenir;
            }
        }
        public ClassroomViewModel Classroom
        {
            get
            {
                return _classroom;
            }
        }
        public ProofViewModel Proof
        {
            get
            {
                return _proof;
            }
        }

        public SeanceViewModel Seance
        {
            get
            {
                return _seance;
            }
        }
        public AttencdanceViewModel Attencdance
        {
            get
            {
                return _attendance;
            }
        }
    }
}
