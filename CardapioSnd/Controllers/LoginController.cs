using CardapioSnd.Filters;
using CardapioSnd.Helper;
using CardapioSnd.Models;
using CardapioSnd.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardapioSnd.Controllers;

public class LoginController : Controller
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly ISessao _sessao;

    public LoginController(IUsuarioRepositorio usuarioRepo, ISessao sessao, IHttpContextAccessor myContext)
    {
        this._usuarioRepositorio = usuarioRepo;
        this._sessao = sessao;
        this._httpContext = myContext;
    }

    public IActionResult Index()
    {
        string user = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
        if (string.IsNullOrEmpty(user))
        {
            return View();
        }
        else
        {
            TempData["MenssagemErro"] = "Ja existe uma sessão logada!";
            return RedirectToAction("Index", "Home");
        }
        
    }

    [HttpPost]
    public IActionResult Entrar(LoginModel loginModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                UsuarioModel usuarioEncontrado = _usuarioRepositorio.BuscarUsuarioPorLogin(loginModel.Login);
                if (usuarioEncontrado != null && usuarioEncontrado.SENHA == loginModel.Senha)
                {
                    _sessao.CriarSessao(usuarioEncontrado);

                    TempData["MenssagemSucesso"] = "Login efetuado com sucesso!";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MenssagemErro"] = "Usuario ou Senha incorretos, por favor, tente novamente!";
                    return View("Index");
                    throw new Exception("Erro ao fazer login, tente novamente");
                }
            }
            else
            {
                TempData["MenssagemErro"] = "Preencha todos os campos corretamente!";
                return View("Index");
            }
        }
        catch (Exception ex) 
        {
            TempData["MenssagemErro"] = $"Erro ao efetuar o login, {ex.Message}";
            return View("Index");
        }
    }

    public IActionResult Sair()
    {
        try
        {
            _sessao.RemoverSessao();
            TempData["MenssagemSucesso"] = "Sessão encerrada com sucesso!";
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            TempData["MenssagemErro"] = "Erro ao encerrar sessão!";
            return RedirectToAction("Index", "Home");
        }
    }
}