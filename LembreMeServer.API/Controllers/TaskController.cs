using AutoMapper;
using LembreMeServer.API.Models;
using LembreMeServer.Domain.Commands.Requests.Tasks;
using LembreMeServer.Domain.Commands.Responses.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LembreMeServer.API.Controllers
{
    [Route("api/v1/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TaskController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskModel>> Get([FromQuery] AllTasksParameters allTasksParameters)
        {
            IEnumerable<GetTaskResponse> getAllTasksResponse = await _mediator.Send(new GetAllTasksRequest() 
            { 
                OnlyCompleted = allTasksParameters.OnlyCompleted,
                OnlyNotCompleted = allTasksParameters.OnlyNotCompleted
            });
            return _mapper.Map<IEnumerable<TaskModel>>(getAllTasksResponse);
        }

        [HttpGet("{id}")]
        public async Task<TaskModel> Get(long id)
        {
            GetTaskResponse getTaskResponse = await _mediator.Send(new GetTaskRequest() { Id = id });
            return _mapper.Map<TaskModel>(getTaskResponse);
        }

        [HttpPost]
        public async Task<long> Post([FromBody] TaskModel taskModel)
        {
            CreateTaskRequest createTaskRequest = _mapper.Map<CreateTaskRequest>(taskModel);
            long newId = await _mediator.Send(createTaskRequest);
            return newId;
        }

        [HttpPut("{id}")]
        public async Task<bool> Put(long id, [FromBody] TaskModel taskModel)
        {
            UpdateTaskRequest updateTaskRequest = _mapper.Map<UpdateTaskRequest>(taskModel);
            updateTaskRequest.Id = id;
            bool success = await _mediator.Send(updateTaskRequest);
            return success;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            DeleteTaskRequest deleteTaskRequest = new DeleteTaskRequest() { Id = id };
            bool success = await _mediator.Send(deleteTaskRequest);
            return success;
        }

        [HttpPatch("{id}")]
        public async Task<bool> PatchCompleted(long id, [FromQuery] bool completed)
        {
            PatchCompletedTaskRequest patchCompletedTaskRequest = new PatchCompletedTaskRequest() { Id = id, Completed = completed };
            bool success = await _mediator.Send(patchCompletedTaskRequest);
            return success;
        }
    }
}
