using GestionDesAbsencesv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class StudentViewModel
    {
        User _user;
        
        public User UserConnected
        {
            set
            {
                _user = value;
            }
        }
        public string AbsenteeismRate
        {
            get
            {
                double nb = GetAbsenceDays() / GetAllDaysTraining();
                double tx = nb * 100;
                return tx.ToString();
            }
        }

        public string NumbersDaysAbsence
        {
            get => GetAbsenceDays().ToString();
        }

        public string NumberTrainingDays
        {
            get => GetAllDaysTraining().ToString();
        }

        int GetAllDaysTraining()
        {
           return  _user.Attendances.Count();
        }
        int GetAbsenceDays()
        {
            return _user.Attendances.Where(c => c.MissingType > 0).Count();
        }

    }
}
