using FluentValidation.Results;

namespace Sinco.Prueba.Colegio.Application.Exceptions
{
    public class CustomValidationException : ApplicationException
    {
        public CustomValidationException() : base("One or more validation errors occurred")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public CustomValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(g => g.Key, g => g.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
