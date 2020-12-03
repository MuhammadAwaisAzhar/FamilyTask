using AutoMapper;
using ClientPortal.Entities;
using ClientPortal.Models;

namespace ClientPortal.Mapper
{
    public class TasksMappingProfile : Profile
    {
        public TasksMappingProfile()
        {
            CreateMap<Task, TaskViewModel>()
                .ForMember(taskViewModel => taskViewModel.TaskId, options => options.MapFrom(task => task.Id));
                
            CreateMap<TaskViewModel, Task>()
                .ForMember(task => task.Id, options => options.MapFrom(taskViewModel => (taskViewModel.TaskId==null|| taskViewModel.TaskId==new System.Guid())?System.Guid.NewGuid():taskViewModel.TaskId))
                .ForMember(task => task.AssignedMember, options => options.Ignore());
        }
    }
}
