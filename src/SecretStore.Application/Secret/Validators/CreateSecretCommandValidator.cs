using Application.Secret.Commands.CreateSecret;
using FluentValidation;

namespace Application.Secret.Validators
{
    public class CreateSecretCommandValidator : AbstractValidator<CreateSecretCommand>
    {
        public CreateSecretCommandValidator()
        {
            RuleFor(command => command.Title).NotNull().NotEmpty();
            RuleFor(command => command.Description).NotNull().NotEmpty();
            RuleFor(command => command.Items.Count).GreaterThan(0);
        }
    }
}