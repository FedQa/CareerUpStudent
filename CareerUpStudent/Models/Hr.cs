using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class Hr
    {
        public Hr()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int? IdCompany { get; set; }

        public virtual Company IdCompanyNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
