using AutoMapper;
using ClientPortal.Entities;
using ClientPortal.Models;
using ClientPortal.Repositories.Interfaces;
using ClientPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientPortal.Services.Implementations
{
    public class TasksService:ServiceBase<TaskViewModel,ClientPortal.Entities.Task>,ITasksService
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IMapper _mapper;

        public TasksService(ITasksRepository tasksRepository, IMapper mapper) : base(tasksRepository, mapper)
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TaskViewModel>> GetAssignedTasksOfMemberAsync(Guid memberId)
        { 
            return _mapper.Map<IEnumerable<TaskViewModel>>(await _tasksRepository.GetAssignedTasksOfMemberAsync(memberId));
        }
    }
}
