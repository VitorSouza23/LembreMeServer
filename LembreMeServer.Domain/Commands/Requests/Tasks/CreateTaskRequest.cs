using LembreMeServer.Domain.Commands.Requests.Tasks.Validators;
using LembreMeServer.Domain.Entities;
using MediatR;
using System;

namespace LembreMeServer.Domain.Commands.Requests.Tasks
{
    public class CreateTaskRequest : IRequest<long>, IValidable
    {
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public Location? Location { get; set; }

        public bool IsValid()
        {
            return new CreateTaskRequestValidator().Validate(this).IsValid;
        }
    }
}
