using Domino.Core.Entities;
using Domino.Core.Interfaces;
using Domino.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DominoContext _ctx;

        public UserRepository(DominoContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> GetLogin(User login)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Email== login.Email);
        }
    }
}
