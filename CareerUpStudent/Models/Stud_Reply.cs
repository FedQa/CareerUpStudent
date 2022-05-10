using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerUpStudent.Models
{
    public class Stud_Reply
    {
        public Dictionary<int, Resume> Resumes { get; set; }
        public Dictionary<int, Reply> Replies { get; set; }

    }
}
