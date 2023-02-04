using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.Domain.Queries.StickyQueries
{
    public class StickyQuery
    {
        public string Id { get; set; }
        public string Cliente { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public string Content { get; set; } 
        public bool Completed{ get; set; }
        public bool Priority { get; set; }    
        public int Height { get; set; }  

        
    }
}
