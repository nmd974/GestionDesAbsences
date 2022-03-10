using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDesAbsences.Models
{
    public partial class Seance
    {
        public Seance()
        {
            Attendances = new HashSet<Attendance>();
        }

        public long Id { get; set; }
        public string Datetime { get; set; }
        public string Label { get; set; }
        public long? ClassroomId { get; set; }

        public virtual Classroom Classroom { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
