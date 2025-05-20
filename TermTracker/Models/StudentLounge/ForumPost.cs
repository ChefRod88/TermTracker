using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermTracker.Models.StudentLounge
{
    public class ForumPost
    {
        public int PostId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string Tag { get; set; }
    }

}
