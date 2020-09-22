using LembreMeServer.Domain.Commands.Requests.Tasks.Validators;
using LembreMeServer.Domain.Commands.Responses.Tasks;
using MediatR;

namespace LembreMeServer.Domain.Commands.Requests.Tasks
{
    public class GetTaskRequest : IRequest<GetTaskResponse>, IValidable
    {
        public long Id { get; set; }

        public bool IsValid()
        {
            return new GetTaskRequestValidator().Validate(this).IsValid;
        }
    }
}
