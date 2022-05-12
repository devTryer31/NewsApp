using FluentValidation;
using System;

namespace News.Application.News.Commands.Create
{
    public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommandRequest>
    {
        public CreateNewsCommandValidator()
        {
            RuleFor(req => req.UserId).NotEqual(Guid.Empty);
            RuleFor(req => req.Title).NotEmpty().MaximumLength(150);
        }
    }
}
