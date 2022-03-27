using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class CompanyReview
    {
        public int Id { get; set; }
        public int RatingStud { get; set; }
        public string Comments { get; set; }
        public int IsVisible { get; set; }
        public int? IdStudent { get; set; }
        public int? IdVacancy { get; set; }

        public virtual Student IdStudentNavigation { get; set; }
        public virtual Vacancy IdVacancyNavigation { get; set; }
    }
}
