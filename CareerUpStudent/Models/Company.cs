using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class Company
    {
        public Company()
        {
            Hrs = new HashSet<Hr>();
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<Hr> Hrs { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
