using MatuteNotes.DataAcces.AdoNet;
using MatuteNotes.DataAcces.Repositories;
using MatuteNotes.Domain;
using MatuteNotes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.DataAcces
{
    public class UnitOfWork : IUnitOfWork
    {

        AdoContext _adoContext;
        private string adoNetUrl = ConfigurationManager.ConnectionStrings["dbase"].ConnectionString;
        public UnitOfWork()
        {
            _adoContext = new AdoContext(adoNetUrl);
            Stickys = new StickyNotesRepository();
            Users = new UserRepository();

        }

        public IStickyNoteRepository Stickys { get; private set; } 

        public IUserRepository Users { get; private set; }

        public void Dispose()
        { 
            throw new NotImplementedException();
        }
    }
}
