using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class University
    {
        public University()
        {
            EduPrograms = new HashSet<EduProgram>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<EduProgram> EduPrograms { get; set; }
    }
}
