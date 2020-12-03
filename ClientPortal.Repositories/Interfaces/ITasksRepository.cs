using ClientPortal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientPortal.Repositories.Interfaces
{
    public interface ITasksRepository:IGenericRepository<Entities.Task>
    {
        Task<IEnumerable<Entities.Task>> GetAssignedTasksOfMemberAsync(Guid memberId);
    }
}
