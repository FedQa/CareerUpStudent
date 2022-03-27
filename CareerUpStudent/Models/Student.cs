using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class Student
    {
        public Student()
        {
            CompanyReviews = new HashSet<CompanyReview>();
            Resumes = new HashSet<Resume>();
            StudentReviews = new HashSet<StudentReview>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string StudCode { get; set; }
        public string StudGroup { get; set; }
        public int JobStatus { get; set; }
        public int CourseNumber { get; set; }
        public string EduForm { get; set; }
        public string PlaceType { get; set; }
        public int? IdEduProgram { get; set; }

        public virtual EduProgram IdEduProgramNavigation { get; set; }
        public virtual ICollection<CompanyReview> CompanyReviews { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
        public virtual ICollection<StudentReview> StudentReviews { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
