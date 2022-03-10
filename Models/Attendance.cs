using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDesAbsences.Models
{
    public partial class Attendance
    {
        public long Id { get; set; }
        public long Late { get; set; }
        public double MissingType { get; set; }
        public long UserId { get; set; }
        public long SeanceId { get; set; }
        public long? ProofId { get; set; }

        public virtual Proof Proof { get; set; }
        public virtual Seance Seance { get; set; }
        public virtual User User { get; set; }
    }
}
