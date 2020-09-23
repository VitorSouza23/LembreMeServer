using AutoMapper;
using LembreMeServer.Domain.Commands.Requests.Tasks;
using LembreMeServer.Domain.Commands.Responses.Tasks;
using LembreMeServer.Domain.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskDomain = LembreMeServer.Domain.Entities.Task;

namespace LembreMeServer.Domain.Handlers
{
    public class TaskRequestHandler : IRequestHandler<CreateTaskRequest, long>,
        IRequestHandler<UpdateTaskRequest, bool>,
        IRequestHandler<DeleteTaskRequest, bool>,
        IRequestHandler<GetTaskRequest, GetTaskResponse>,
        IRequestHandler<GetAllTasksRequest, IEnumerable<GetTaskResponse>>,
        IRequestHandler<PatchCompletedTaskRequest, bool>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                TaskDomain task = _mapper.Map<TaskDomain>(request);
                await _taskRepository.AddAsync(task);
                return task.Id;
            }
            return -1;
        }

        public async Task<bool> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                TaskDomain currentTask = await _taskRepository.GetAsync(request.Id);
                if(currentTask != null)
                {
                    _mapper.Map(request, currentTask);
                    await _taskRepository.UpdateAsync(request.Id, currentTask);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                await _taskRepository.RemoveAsync(request.Id);
                return true;
            }
            return false;
        }

        public async Task<GetTaskResponse> Handle(GetTaskRequest request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                TaskDomain task = await _taskRepository.GetAsync(request.Id);
                return _mapper.Map<GetTaskResponse>(task);
            }
            return null;
        }

        public async Task<IEnumerable<GetTaskResponse>> Handle(GetAllTasksRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<TaskDomain> tasks = await _taskRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetTaskResponse>>(tasks);
        }

        public async Task<bool> Handle(PatchCompletedTaskRequest request, CancellationToken cancellationToken)
        {
            TaskDomain task = await _taskRepository.GetAsync(request.Id);
            if(task != null)
            {
                task.Completed = request.Completed;
                await _taskRepository.UpdateAsync(request.Id, task);
                return true;
            }
            return false;
        }
    }
}
