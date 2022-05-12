using FluentValidation;
using System;

namespace News.Application.News.Commands.Delete
{
    public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommandRequest>
    {
        public DeleteNewsCommandValidator()
        {
            RuleFor(req => req.UserId).NotEqual(Guid.Empty);
            RuleFor(req => req.Id).NotEqual(Guid.Empty);
        }
    }
}
