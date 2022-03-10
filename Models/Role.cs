using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDesAbsences.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
