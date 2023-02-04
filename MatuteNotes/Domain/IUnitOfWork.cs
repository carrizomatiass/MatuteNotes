using MatuteNotes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.Domain
{
    public interface IUnitOfWork : IDisposable
    {

        IStickyNoteRepository Stickys { get; }
        IUserRepository users { get; }
    }
}
