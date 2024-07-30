using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace MedCare.Application.Shared.Behavior
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : Response
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? await Errors(failures)
                : await next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new Response(CodeStateResponse.RequiredFields);

            foreach (var failure in failures)
            {
                response.AddError(failure.ErrorMessage);
            }

            return Task.FromResult(response as TResponse);
        }
    }
}
