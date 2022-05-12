using FluentValidation;
using System;

namespace News.Application.News.Queries.GetNewsTitlesList
{
    public class GetNewsTitilesListValidator : AbstractValidator<GetNewsTitilesListRequest>
    {
        public GetNewsTitilesListValidator()
        {
            RuleFor(req => req.UserId).NotEqual(Guid.Empty);
        }
    }
}
