using System.Collections.Generic;
using FluentValidation.Results;

namespace Hydra.Core.Validator
{
    public interface IValidationResult
    {
         IList<ValidationFailure> GetErrors();
    }
}