using LembreMeServer.Domain.Commands.Requests.Tasks.Validators;
using LembreMeServer.Domain.Entities;
using MediatR;
using System;

namespace LembreMeServer.Domain.Commands.Requests.Tasks
{
    public class UpdateTaskRequest : IRequest<bool>, IValidable
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public virtual Location? Location { get; set; }

        public bool IsValid()
        {
            return new UpdateTaskRequestValidator().Validate(this).IsValid;
        }
    }
}
