using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermTracker.Models
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Ignore]
        public string RemainingWeeks
        {
            get
            {
                var remaining = (EndDate - DateTime.Today).TotalDays / 7;
                return $"~{Math.Max(0, (int)remaining)} weeks remaining";
            }
        }
    }
}
