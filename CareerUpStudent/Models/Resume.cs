using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class Resume
    {
        public Resume()
        {
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int? IdStudent { get; set; }

        public virtual Student IdStudentNavigation { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
