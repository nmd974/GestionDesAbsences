using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDesAbsences.Models
{
    public partial class Appartenir
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PromotionId { get; set; }
        public long? Archived { get; set; }

        public virtual Promotion Promotion { get; set; }
        public virtual User User { get; set; }
    }
}
