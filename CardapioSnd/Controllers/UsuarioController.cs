using CardapioSnd.Filters;
using CardapioSnd.Models;
using CardapioSnd.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CardapioSnd.Controllers;

[FiltroUsuarioSuperAdmin]
public class UsuarioController : Controller
{
    private readonly IUsuarioRepositorio _repositorio;
    public UsuarioController(IUsuarioRepositorio repo)
    {
        this._repositorio = repo;
    }
    public IActionResult Index()
    {
        List<UsuarioModel> usuarios = _repositorio.BuscarTodosUsuario();
        return View(usuarios);
    }

    public IActionResult Criar()
    {
        return View();
    }

    public IActionResult Editar(int id)
    {
        UsuarioModel usuario = _repositorio.BuscarUsuarioPorId(id);
        if(usuario != null)
        {
            return View(usuario);
        }
        else
        {
            throw new Exception("Usuario não encontado no banco de dados");
        }
    }

    public IActionResult Apagar(int id)
    {
        UsuarioModel usuario = _repositorio.BuscarUsuarioPorId(id);
        if (usuario != null)
        {
            return View(usuario);
        }
        else
        {
            throw new Exception("Usuario não encontado no banco de dados");
        }
    }

    public IActionResult Senha(int id)
    {
        UsuarioModel usuario = _repositorio.BuscarUsuarioPorId(id);
        return View(usuario);
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _repositorio.Criar(usuario);

                TempData["MenssagemSucesso"] = "Usuário Adicionado Com Sucesso!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MenssagemErro"] = "Preencha todos os campos corretamente!";
                return View("Criar");
            }
        }
        catch (Exception ex)
        {
            TempData["MensagemErro"] = "Erro ao Adicionar Usuário, favor tentar novamente";
            throw new Exception("Erro ao adicionar usuário!");
        }
    }

    [HttpPost]
    public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenha)
    {
        try
        {
            if (ModelState.IsValid)
            {
                UsuarioModel usuario = new UsuarioModel
                {
                    ID_USUARIO = usuarioSemSenha.Id,
                    LOGIN = usuarioSemSenha.Login,
                    NOME = usuarioSemSenha.Nome,
                    EMAIL = usuarioSemSenha.Email,
                    PERFIL = usuarioSemSenha.Perfil,
                    DATA_ATUALIZACAO = DateTime.Now
                };

                _repositorio.Editar(usuario);

                TempData["MenssagemSucesso"] = "Usuário Editado Com Sucesso!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MenssagemErro"] = "Preencha todos os campos corretamente!";
                return View("Editar");
            }
        }
        catch
        {
            TempData["MenssagemErro"] = "Erro ao editar usuário, tente novamente!";
            throw new Exception("Erro ao editar usuário!");
        }
    }

    public IActionResult Deletar(int id)
    {
        try
        {
            _repositorio.DeletarUsuario(id);

            TempData["MenssagemSucesso"] = "Usuário Deletado Com Sucesso!";

            return RedirectToAction("Index");
        }
        catch
        {
            TempData["MenssagemErro"] = "Erro ao deletar usuário, tente novamente!";
            throw new Exception("Erro ao deletar usuário!");
        }
    }

    [HttpPost]
    public IActionResult Senha(UsuarioRedefinirSenhaModel user)
    {
        try
        {
            if(ModelState.IsValid)
            {
                UsuarioModel usuarioDb = _repositorio.BuscarUsuarioPorId(user.Id);

                if (usuarioDb != null)
                {
                    usuarioDb.SENHA = user.Senha;
                    _repositorio.RedefinirSenha(usuarioDb);
                    TempData["MenssagemSucesso"] = "Senha do Usuário Redefinida Com Sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MenssagemErro"] = "Erro ao encontrar usuario no banco de dados!";
                    return View();
                }
            }
            else
            {
                TempData["MenssagemErro"] = "Preecha todos os campos corretamente!";
                return View();
            }
        }
        catch (Exception ex)
        {
            TempData["MenssagemErro"] = $"Erro ao redefinir a senha do usuário, tente novamente!";
            return RedirectToAction("Index");  
        }
    }
}
