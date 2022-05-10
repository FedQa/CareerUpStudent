using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CareerUpStudent.Models
{
    [Keyless]
    public class ReplyResume
    {
        public int ReplyId { get; set; }
        public int ResumeId { get; set; }
        public Reply Reply { get; set; }
        public Resume Resume { get; set; }
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        


    }
}
