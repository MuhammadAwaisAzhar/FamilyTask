using ClientPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientPortal.Services.Interfaces
{
    public interface ITasksService:IServiceBase<TaskViewModel>
    {
        Task<IEnumerable<TaskViewModel>> GetAssignedTasksOfMemberAsync(Guid memberId);
    }
}
