using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDesAbsences.Models
{
    public partial class User
    {
        public User()
        {
            Appartenirs = new HashSet<Appartenir>();
            Attendances = new HashSet<Attendance>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Appartenir> Appartenirs { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
