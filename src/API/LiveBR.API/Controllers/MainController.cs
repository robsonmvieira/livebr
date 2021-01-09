using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LiveBR.API.Controllers
{
    [ApiController]
    public abstract class MainController: Controller
    {
        protected ICollection<string> Errors = new List<string>();
        
        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValidOperation()) return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagem", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(x => x.Errors);

            foreach (var erro in erros)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        private bool IsValidOperation()
        {
            return !Errors.Any();
        }

        private void AddError(string error)
        {
            Errors.Add(error);
        }

        protected void ClearErrorCollection()
        {
            Errors.Clear();
        }
    }
}