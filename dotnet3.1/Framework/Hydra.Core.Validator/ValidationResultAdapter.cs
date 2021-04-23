using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Hydra.Core.Validator
{
    public class ValidationResultAdapter : IValidationResult
    {
        private readonly ValidationResult _validationResult;

        public ValidationResultAdapter()
        {
            _validationResult = new ValidationResult();
        }

        public void AddError(string message) =>
            _validationResult.Errors.Add(new ValidationFailure(string.Empty, message));

        public void AddError(string property, string message) =>
            _validationResult.Errors.Add(new ValidationFailure(property, message));

        public IList<ValidationFailure> GetErrors() => _validationResult?.Errors;

        public bool IsValid => _validationResult.IsValid;
    }
}