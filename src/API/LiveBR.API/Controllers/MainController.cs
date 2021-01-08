using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LiveBR.API.Controllers
{
    [ApiController]
    public abstract class MainController: ControllerBase
    {
        public ICollection<string> Errors { get; set; } = new List<string>();
        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValidOperation()) return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagem", Errors.ToArray() }
            }));
        }

        public IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(x => x.Errors);

            foreach (var erro in erros)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool IsValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddError(string error)
        {
            Errors.Add(error);
        }

        protected void ClearErrorCollection()
        {
            Errors.Clear();
        }
    }
}