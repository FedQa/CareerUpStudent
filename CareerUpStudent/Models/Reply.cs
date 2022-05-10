using System;
using System.Collections.Generic;

#nullable disable

namespace CareerUpStudent.Models
{
    public partial class Reply
    {
        public int Id { get; set; }
        public int Answer { get; set; }
        public DateTime AnswerDate { get; set; }
        public int IdResume { get; set; }
        public int IdVacancy { get; set; }

        public virtual Resume IdResumeNavigation { get; set; }
        public virtual Vacancy IdVacancyNavigation { get; set; }
    }
}
