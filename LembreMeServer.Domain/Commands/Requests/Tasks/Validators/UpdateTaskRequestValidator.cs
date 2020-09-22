using FluentValidation;

namespace LembreMeServer.Domain.Commands.Requests.Tasks.Validators
{
    internal class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskRequestValidator()
        {
            RuleFor(u => u.Description)
                .MaximumLength(200)
                .WithMessage("A descrição deve ter no máximo 200 caracteres.");

            RuleFor(u => u.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("A descrição não pode ser vazia.");

            RuleFor(u => u.Id)
                .GreaterThan(0)
                .WithMessage("O ID da tarefa não pode ser igual ou menor que zero.");
        }
    }
}
