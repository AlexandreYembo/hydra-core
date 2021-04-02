using System.Collections.Generic;

namespace Hydra.Core.Abstractions.Validations
{
    /// <summary>
    /// Interface to implement an specific validation
    /// </summary>
    public interface IValidationResultAbstraction
    {
         void AddError(string message);
         void AddError(string property, string message);
    }
}