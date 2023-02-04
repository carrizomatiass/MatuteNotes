using MatuteNotes.Domain.Models;
using MatuteNotes.Domain.Queries.StickyQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.Domain.Repositories
{
    public interface IStickyNoteRepository
    {
        Task<IEnumerable<StickyQuery>> GetListado(StickyQueryParams @params);

        Task<int> SetData(StickyNote note, string acccion);

    }
}
