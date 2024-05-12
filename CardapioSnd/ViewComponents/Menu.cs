using CardapioSnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CardapioSnd.ViewComponents;

public class Menu : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string sessaoUser = HttpContext.Session.GetString("sessaoUsuarioLogado");
        UsuarioModel user = new UsuarioModel();
        if (string.IsNullOrEmpty(sessaoUser)) return View(user);
        UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUser);
        return View(usuario);
    }
}