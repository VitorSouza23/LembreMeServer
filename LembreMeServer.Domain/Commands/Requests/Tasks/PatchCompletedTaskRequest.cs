using MediatR;

namespace LembreMeServer.Domain.Commands.Requests.Tasks
{
    public class PatchCompletedTaskRequest : IRequest<bool>
    {
        public long Id { get; set; }
        public bool Completed { get; set; }
    }
}
