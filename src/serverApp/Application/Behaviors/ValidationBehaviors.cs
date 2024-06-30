using Application.Abstractions.Messaging;
using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public sealed class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TRequest>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var errorsDictionary = _validators.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(x => x.PropertyName, x => x.ErrorMessage, (propName, errorMessages) => new
                {
                    key = propName,
                    errorMessage = errorMessages.Distinct().ToArray()
                })
                .ToDictionary(x => x.key, x => x.errorMessage);
            if (errorsDictionary.Any())
            {
                throw new ValidationErrorsException(errorsDictionary);
            }
            return await next();
        }
    }
}
