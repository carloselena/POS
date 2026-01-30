using FluentValidation.Results;

namespace POS.Core.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; } = [];

        public ValidationException(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public ValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                Errors.Add(validationError.ErrorMessage);
            }
        }
    }
}
