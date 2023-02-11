using MatuteNotes.Domain.Models;
using MatuteNotes.Domain.Queries.StickyQueries;
using MatuteNotes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.DataAcces.Repositories
{
    public class StickyNotesRepository : IStickyNoteRepository
    {
        //asdasdasdasd
        public Task<IEnumerable<StickyQuery>> GetListado(StickyQueryParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<int> SetData(StickyNote note, string acccion)
        {
            throw new NotImplementedException();
        }
    }
}
