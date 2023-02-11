using MatuteNotes.DataAcces.Repositories;
using MatuteNotes.Domain;
using MatuteNotes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.DataAcces
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork()
        {
            Stickys = new StickyNotesRepository();
            Users = new UserRepository();

        }

        //asdasdasdasd
        public IStickyNoteRepository Stickys { get; private set; } 

        public IUserRepository Users { get; private set; }

        public void Dispose()
        { 
            throw new NotImplementedException();
        }
    }
}
