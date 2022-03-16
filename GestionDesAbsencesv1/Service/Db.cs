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
    }
}
