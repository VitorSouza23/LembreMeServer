using FluentValidation;

namespace LembreMeServer.Domain.Commands.Requests.Tasks.Validators
{
    internal class DeleteTaskRequestValidator : AbstractValidator<DeleteTaskRequest>
    {
        public DeleteTaskRequestValidator()
        {
            RuleFor(d => d.Id)
                .GreaterThan(0)
                .WithMessage("O ID da tarefa não pode ser menor ou igual a zero.");
        }
    }
}
