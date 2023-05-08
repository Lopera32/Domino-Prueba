using Domino.Core.Entities;
using Domino.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Infrastructure.Repositories
{
    public interface IUserRepository 
    {
        Task<User> GetLogin(User login);
    }
}
