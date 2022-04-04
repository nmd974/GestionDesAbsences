using GestionDesAbsencesv1.Service;
using GestionDesAbsencesv1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestionDesAbsencesv1.Models.Form
{
    class Boutton
    {
        string _content;
        string _kind;
        Page _page;
        private ICommand _changePageFrame;

        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        public string Kind
        {
            get
            {
                return _kind;
            }
            set
            {
                _kind = value;
            }
        }

        public Page Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
            }
        }

        public ICommand ChangePageFrame
        {
            get
            {
                if (_changePageFrame == null)
                {
                    _changePageFrame = new RelayCommand(
                        param => this.ChangePage()
                    );
                }
                return _changePageFrame;
            }
        }

        void ChangePage() 
        {
            LayoutHome.HomeFrame.Content = new Login();
        }

    }
}
