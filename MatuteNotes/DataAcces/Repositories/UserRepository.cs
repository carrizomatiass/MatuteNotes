﻿using MatuteNotes.Domain.Models;
using MatuteNotes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.DataAcces.Repositories
{
    public class UserRepository : IUserRepository
    {
        //asdasdasd
        public Task<IEnumerable<Usuary>> GetLogin(string usuario)
        {
            throw new NotImplementedException();
        }
    }
}
