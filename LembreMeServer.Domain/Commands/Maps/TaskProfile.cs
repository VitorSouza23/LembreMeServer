using AutoMapper;
using LembreMeServer.Domain.Commands.Requests.Tasks;
using LembreMeServer.Domain.Commands.Responses.Tasks;
using LembreMeServer.Domain.Entities;

namespace LembreMeServer.Domain.Commands.Maps
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskRequest, Task>();
            CreateMap<UpdateTaskRequest, Task>();
            CreateMap<Task, GetTaskResponse>();
        }
    }
}
