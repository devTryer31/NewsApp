using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace News.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponce>
        : IPipelineBehavior<TRequest, TResponce> where TRequest : IRequest<TResponce>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public Task<TResponce> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponce> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var fails = _validators
                .Select(v => v.Validate(context))
                .SelectMany(res => res.Errors)
                .Where(fail => fail is not null)
                .ToList();

            if(fails.Any())
                throw new ValidationException(fails);

            return next();
        }
    }
}
