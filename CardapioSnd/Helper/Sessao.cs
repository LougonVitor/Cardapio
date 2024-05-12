using CardapioSnd.Models;
using Newtonsoft.Json;

namespace CardapioSnd.Helper;

public class Sessao : ISessao
{
    private readonly IHttpContextAccessor _httpContext;

    public Sessao(IHttpContextAccessor meuHttpContext)
    {
        this._httpContext = meuHttpContext;
    }

    public UsuarioModel BuscarSessao()
    {
        string sessaoUser = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

        if (string.IsNullOrEmpty(sessaoUser)) return null;
        UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUser);
        return usuario;
    }

    public void CriarSessao(UsuarioModel usuario)
    {
        string sessaoUser = JsonConvert.SerializeObject(usuario);
        _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", sessaoUser);
    }

    public void RemoverSessao()
    {
        _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
    }
}