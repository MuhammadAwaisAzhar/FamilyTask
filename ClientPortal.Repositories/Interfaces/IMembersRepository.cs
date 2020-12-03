using ClientPortal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientPortal.Repositories.Interfaces
{
    public interface IMembersRepository:IGenericRepository<Member>
    {
        Task<IEnumerable<Member>> GetMemberTaskDetailsAsync();       
    }
}
