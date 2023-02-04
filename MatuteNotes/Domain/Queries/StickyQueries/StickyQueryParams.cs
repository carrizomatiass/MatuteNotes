using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.Domain.Queries.StickyQueries
{
    public class StickyQueryParams
    {

        public bool @Completed { get; set; } 
        public string @IdUser { get; set; }  
        public bool @FilterDate { get; set; }
        public DateTime @StarDate { get; set; }
        public DateTime @EndDate { get; set; }


    }
}
