using CardapioSnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CardapioSnd.Filters;

public class FiltroUsuarioAdmin : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
        if(string.IsNullOrEmpty(sessaoUsuario))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
        }
        else
        {
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            if(sessaoUsuario == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
            }

            if (usuario.PERFIL != Enums.PerfilEnum.Admin && usuario.PERFIL != Enums.PerfilEnum.SuperAdmin)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Filtro" }, { "action", "Index" } });
            }
        }
        base.OnActionExecuted(context);
    }
}