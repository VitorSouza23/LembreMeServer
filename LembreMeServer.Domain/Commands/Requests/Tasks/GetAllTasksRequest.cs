﻿using LembreMeServer.Domain.Commands.Responses.Tasks;
using MediatR;
using System.Collections.Generic;

namespace LembreMeServer.Domain.Commands.Requests.Tasks
{
    public class GetAllTasksRequest : IRequest<IEnumerable<GetTaskResponse>>
    {
        public bool OnlyCompleted { get; set; }
        public bool OnlyNotCompleted { get; set; }
    }
}
