using FluentValidation;

namespace LembreMeServer.Domain.Commands.Requests.Tasks.Validators
{
    internal class GetTaskRequestValidator : AbstractValidator<GetTaskRequest>
    {
        public GetTaskRequestValidator()
        {
            RuleFor(u => u.Id)
                .GreaterThan(0)
                .WithMessage("O ID da tarefa não pode ser menor ou igual a zero");
        }
    }
}
