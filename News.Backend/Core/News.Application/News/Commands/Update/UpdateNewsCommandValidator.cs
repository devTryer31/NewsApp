using FluentValidation;
using System;

namespace News.Application.News.Commands.Update
{
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommandRequest>
    {
        public UpdateNewsCommandValidator()
        {
            RuleFor(req => req.UserId).NotEqual(Guid.Empty);
            RuleFor(req => req.Id).NotEqual(Guid.Empty);
            RuleFor(req => req.Title).MinimumLength(150).NotEmpty();
        }
    }
}
