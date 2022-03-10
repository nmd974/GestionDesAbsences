using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDesAbsences.Models
{
    public partial class Classroom
    {
        public Classroom()
        {
            Seances = new HashSet<Seance>();
        }

        public long Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Seance> Seances { get; set; }
    }
}
