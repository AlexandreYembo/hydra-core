using System.Collections.Generic;
using FluentValidation.Results;
using Hydra.Core.Abstractions.Validations;

namespace Hydra.Core.Validator
{
    public interface IValidationResult : IValidationResultAbstraction
    {
         IList<ValidationFailure> GetErrors();
    }
}