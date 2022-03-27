using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string UserName { get; set; }
        public int? IdRole { get; set; }
        public int? IdStudent { get; set; }
        public int? IdHr { get; set; }

        public virtual Hr IdHrNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual Student IdStudentNavigation { get; set; }
    }
}
