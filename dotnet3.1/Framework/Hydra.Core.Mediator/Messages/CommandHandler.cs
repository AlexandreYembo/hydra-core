using System.Threading.Tasks;
using Hydra.Core.Abstractions.Data;
using Hydra.Core.Abstractions.Validations;

namespace Hydra.Core.Mediator.Messages
{
     public abstract class CommandHandler
    {
        protected readonly IValidationResultAbstraction _validationResult;

        protected CommandHandler(IValidationResultAbstraction validationResult)
        {
            _validationResult = validationResult;
        }

        protected void AddError(string message) => 
            _validationResult.AddError(string.Empty, message);


        /// <summary>
        /// Persist the data on DB and also valid for errors.
        /// </summary>
        /// <param name="uow"></param>
        /// <returns></returns>
        protected async Task<IValidationResultAbstraction> Save(IUnitOfWork uow)
        {
            if(!await uow.Commit()) AddError("Error to persist the data");

            return _validationResult;
        }
    }
}