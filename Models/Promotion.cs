using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDesAbsences.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            Appartenirs = new HashSet<Appartenir>();
        }

        public long Id { get; set; }
        public long Label { get; set; }

        public virtual ICollection<Appartenir> Appartenirs { get; set; }
    }
}
