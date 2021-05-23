using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Hydra.Core.Mediator.Communication;
using Hydra.Core.Mediator.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hydra.Core.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();
        
        protected ActionResult CustomResponse(object result = null)
        {
            if(ValidOperation()) return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>{
                { "Messages", Errors.ToArray()}
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(s => s.Errors);

            foreach (var error in errors)
            {
                AddErrors(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse<TResponse>(CommandResult<TResponse> commandResult)
        {
            if(commandResult.ValidationResult.IsValid == false){
                return CustomResponse(commandResult.ValidationResult);
            }
            return CustomResponse(commandResult.Payload);
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddErrors(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult response)
        {
            ResponseHasErrors(response);

            return CustomResponse();
        }

        protected bool ResponseHasErrors(ResponseResult response)
        {
            if (response == null || !response.Errors.Messages.Any()) return false;

            foreach (var message in response.Errors.Messages)
            {
                AddErrors(message);
            }

            return true;
        }

        protected bool ValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddErrors(string erro)
        {
            Errors.Add(erro);
        }

        protected void ClearErrors()
        {
            Errors.Clear();
        }
    }
}