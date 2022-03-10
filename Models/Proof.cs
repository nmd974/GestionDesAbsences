using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDesAbsences.Models
{
    public partial class Proof
    {
        public Proof()
        {
            Attendances = new HashSet<Attendance>();
        }

        public long Id { get; set; }
        public long? Justify { get; set; }
        public string Comment { get; set; }
        public string Motive { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
