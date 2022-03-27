using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class Vacancy
    {
        public Vacancy()
        {
            CompanyReviews = new HashSet<CompanyReview>();
            Replies = new HashSet<Reply>();
            StudentReviews = new HashSet<StudentReview>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string ExperienceRequired { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string EmploymentType { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }
        public string Conditions { get; set; }
        public string Salary { get; set; }
        public int IsActive { get; set; }
        public int? IdCompany { get; set; }
        public int? IdHr { get; set; }

        public virtual Company IdCompanyNavigation { get; set; }
        public virtual ICollection<CompanyReview> CompanyReviews { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<StudentReview> StudentReviews { get; set; }
    }
}
