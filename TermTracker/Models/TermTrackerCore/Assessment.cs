using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermTracker.Models.TermTrackerCore
{
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int CourseId { get; set; } // Foreign key to Course
        public string Title { get; set; }

        public string Type { get; set; } // "Objective" or "Performance"
        public DateTime DueDate { get; set; }

        public bool HasNotification { get; set; }
    }
}
