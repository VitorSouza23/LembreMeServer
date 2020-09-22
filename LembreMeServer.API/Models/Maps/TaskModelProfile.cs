using AutoMapper;
using LembreMeServer.Domain.Commands.Requests.Tasks;
using LembreMeServer.Domain.Commands.Responses.Tasks;

namespace LembreMeServer.API.Models.Maps
{
    public class TaskModelProfile : Profile
    {
        public TaskModelProfile()
        {
            CreateMap<TaskModel, CreateTaskRequest>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(source => source.Location));
            CreateMap<TaskModel, UpdateTaskRequest>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(source => source.Location));
            CreateMap<GetTaskResponse, TaskModel>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(source => source.Location));
        }
    }
}
