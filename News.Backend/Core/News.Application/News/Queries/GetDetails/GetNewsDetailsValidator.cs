using FluentValidation;
using System;

namespace News.Application.News.Queries.GetDetails
{
    public class GetNewsDetailsValidator : AbstractValidator<GetNewsDetailsRequest>
    {
        public GetNewsDetailsValidator()
        {
            RuleFor(req => req.UserId).NotEqual(Guid.Empty);
            RuleFor(req => req.Id).NotEqual(Guid.Empty);
        }
    }
}
