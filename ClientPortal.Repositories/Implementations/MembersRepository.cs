using ClientPortal.Entities;
using ClientPortal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientPortal.Repositories.Implementations
{
    public class MembersRepository : GenericRepository<Member>, IMembersRepository
    {
        private readonly DbContext _context;

        public MembersRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Member>> GetMemberTaskDetailsAsync()
        {
            return await _context.Set<Member>().Include(x => x.Tasks).ToListAsync();
        }
    }
}
