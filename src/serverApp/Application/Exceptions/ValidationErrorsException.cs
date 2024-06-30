using Domain.Exceptions.Base;

namespace Application.Exceptions
{
    public class ValidationErrorsException : BadRequestException
    {
        public ValidationErrorsException(Dictionary<string, string[]> errors) : base($"Validation errors: {string.Join(",", errors)}") => Errors = errors;
        public Dictionary<string, string[]> Errors { get; }
    }
}
