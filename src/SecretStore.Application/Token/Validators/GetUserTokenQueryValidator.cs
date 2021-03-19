using Application.Token.Queries;
using FluentValidation;

namespace Application.Token.Validators
{
    public class GetUserTokenQueryValidator : AbstractValidator<GetUserTokenQuery>
    {
        public GetUserTokenQueryValidator()
        {
            RuleFor(query => query.UserName).NotNull().NotEmpty();
            RuleFor(query => query.Password).NotNull().NotEmpty();
        }
    }
}