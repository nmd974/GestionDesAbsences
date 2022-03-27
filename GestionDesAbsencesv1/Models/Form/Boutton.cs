using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.Models.Form
{
    class Boutton
    {
        string _content;
        string _kind;
        object _actionButton;

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
        object ActionButton
        {
            get
            {
                return _actionButton;
            }
            set
            {
                _actionButton = value;
            }
        }


    }
}
