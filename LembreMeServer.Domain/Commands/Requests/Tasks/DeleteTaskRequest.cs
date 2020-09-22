using LembreMeServer.Domain.Commands.Requests.Tasks.Validators;
using MediatR;

namespace LembreMeServer.Domain.Commands.Requests.Tasks
{
    public class DeleteTaskRequest : IRequest<bool>, IValidable
    {
        public long Id { get; set; }

        public bool IsValid()
        {
            return new DeleteTaskRequestValidator().Validate(this).IsValid;
        }
    }
}
