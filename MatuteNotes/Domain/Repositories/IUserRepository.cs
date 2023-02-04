using MatuteNotes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.Domain.Repositories
{
    public interface IUserRepository
    { 

        Task<IEnumerable<Usuary>>GetLogin(string usuario);
    }
}
