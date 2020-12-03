using ClientPortal.Entities;
using ClientPortal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPortal.Repositories.Implementations
{
    public class TasksRepository:GenericRepository<Entities.Task>,ITasksRepository
    {

        public TasksRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Entities.Task>> GetAssignedTasksOfMemberAsync(Guid memberId)
        {
           return await this._context.Set<Entities.Task>().Where(tasks=>tasks.AssignedMemeberId==memberId).ToListAsync();
        }
    }
}
