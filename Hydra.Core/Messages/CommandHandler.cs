using System.Threading.Tasks;
using FluentValidation.Results;
using Hydra.Core.Data;

namespace Hydra.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message) => 
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));

        protected async Task<ValidationResult> Save(IUnitOfWork uow)
        {
                if(await uow.Commit()) AddError("Error to save the customer");

            return ValidationResult;
        }
    }
}