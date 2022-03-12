using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class Actions
    {
        static DataContextViewModel _viewModel = new();

        public static DataContextViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
        }
    }
}
