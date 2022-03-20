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

        readonly RoleViewModel _roles = new();
        readonly PromotionViewModel _promotion = new();
        readonly UserViewModel _user = new();
        readonly AppartenirViewModel _appartenir = new();
        readonly ClassroomViewModel _classroom = new();
        readonly ProofViewModel _proof = new();
        readonly SeanceViewModel _seance = new();
        readonly AttencdanceViewModel _attendance = new();
        readonly LoginViewModel _login = new();

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
