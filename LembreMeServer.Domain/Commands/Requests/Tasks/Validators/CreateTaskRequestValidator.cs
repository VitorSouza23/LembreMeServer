using FluentValidation;

namespace LembreMeServer.Domain.Commands.Requests.Tasks.Validators
{
    internal class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(c => c.Description)
                .MaximumLength(200)
                .WithMessage("A descrição deve ter no máximo 200 caracteres.");

            RuleFor(c => c.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("A descrição não pode ser vazia.");
        }
    }
}
