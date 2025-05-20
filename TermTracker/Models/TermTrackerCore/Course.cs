using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermTracker.Models.TermTrackerCore
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TermId { get; set; } // Foreign key to Term
        public string Title { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; }  // Not Started, In Progress, Completed
        public string Notes { get; set; }
    }
}
