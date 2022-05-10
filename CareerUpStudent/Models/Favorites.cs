using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerUpStudent.Models
{
    public class Favorites
    {
        [Key]
        public string ItemId { get; set; }

        public string FavId { get; set; }

        public int VacancyId { get; set; }

        public virtual Vacancy Vacancy { get; set; }
    }
}
