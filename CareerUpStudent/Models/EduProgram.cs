using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class EduProgram
    {
        public EduProgram()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Program { get; set; }
        public string Faculty { get; set; }
        public string Direction { get; set; }
        public string EduLevel { get; set; }
        public string Description { get; set; }
        public int? IdUniversity { get; set; }

        public virtual University IdUniversityNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
