using CardapioSnd.Filters;
using CardapioSnd.Models;
using CardapioSnd.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CardapioSnd.Controllers;

[FiltroUsuarioAdmin]
public class CardapioController : Controller
{
    private readonly IAlimentoRepositorio _alimentoRepositorio;
    private readonly ICardapioRepositorio _cardapioRepositorio;
    public CardapioController(IAlimentoRepositorio alimentoRepositorio, ICardapioRepositorio cardapioRepositorio)
    {
        this._alimentoRepositorio = alimentoRepositorio;
        this._cardapioRepositorio = cardapioRepositorio;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AdicionarCardapio()
    {
        CardapioAdicionarModel cardapioAdicionar = _cardapioRepositorio.BuscarAlimentos();
        cardapioAdicionar.DataCardapio = DateOnly.FromDateTime(DateTime.Now);
        return View(cardapioAdicionar);
    }

    public IActionResult GerenciarCardapio()
    {
        List<CardapioModel> listaCardapio = _cardapioRepositorio.ListarTodos();
        return View(listaCardapio);
    }

    public IActionResult AdicionarAlimento()
    {
        return View();
    }

    public IActionResult GerenciarAlimento()
    {
        List<AlimentoModel> alimentos = _alimentoRepositorio.BuscarTodosAlimentos();
        return View(alimentos);
    }

    public IActionResult EditarCardapio(int id)
    {
        CardapioModel cardapio = _cardapioRepositorio.BuscarPorId(id);
        return View(cardapio);
    }

    public IActionResult ApagarCardapio(int id)
    {
        CardapioModel cardapio = _cardapioRepositorio.BuscarPorId(id);
        return View(cardapio);
    }

    public IActionResult EditarAlimento(int id)
    {
        AlimentoModel alimento = _alimentoRepositorio.BuscarAlimentoPorId(id);
        return View(alimento);
    }

    public IActionResult ApagarAlimento(int id)
    {
        AlimentoModel alimento = _alimentoRepositorio.BuscarAlimentoPorId(id);
        return View(alimento);
    }




    //CRUD
    [HttpPost]
    public IActionResult AdicionarAlimento(AlimentoModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _alimentoRepositorio.AdicionarAlimento(model);
                TempData["MenssagemSucesso"] = "Alimento adicionado com sucesso!";
                return View("Index");
            }
            else
            {
                TempData["MenssagemErro"] = "Preencha todos os campos corretamente!";
                return View();
            }
        }
        catch (Exception ex)
        {
            TempData["MenssagemErro"] = "Erro ao adicionar alimento, tente novamente!";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult EditarAlimento(AlimentoModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _alimentoRepositorio.EditarAlimento(model);
                TempData["MenssagemSucesso"] = "Alimento editado com sucesso!";
                return RedirectToAction("GerenciarAlimento");
            }
            else
            {
                TempData["MenssagemErro"] = "Preencha todos os campos corretamente!";
                return View();
            }
        }
        catch (Exception ex)
        {
            TempData["MenssagemErro"] = $"Erro ao editar alimento!";
            return RedirectToAction("GerenciarAlimento");
        }
    }

    public IActionResult DeletarAlimento(int id)
    {
        try
        {
            _alimentoRepositorio.DeletarAlimento(id);
            TempData["MenssagemSucesso"] = "Alimento deletado com sucesso!";
            return RedirectToAction("GerenciarALimento");
        }
        catch (Exception ex)
        {
            TempData["MenssagemErro"] = $"Erro ao deletar alimento!";
            return RedirectToAction("GerenciarAlimento");
        }
    }



    [HttpPost]
    public IActionResult AdicionarCardapio(CardapioAdicionarModel model)
    {
        try
        {
            _cardapioRepositorio.AdicionarCardapio(model);
            TempData["MenssagemSucesso"] = "Cardápio adicionado com sucesso!";
            return View("Index");
        }
        catch (Exception ex)
        {
            TempData["MenssagemErro"] = "Ja existe um cardápio com esta data cadastrada";
            CardapioAdicionarModel cardapioAdicionar = _cardapioRepositorio.BuscarAlimentos();
            cardapioAdicionar.DataCardapio = DateOnly.FromDateTime(DateTime.Now);
            return View(cardapioAdicionar);   
            //return RedirectToAction("Index");
        }
    }

    public IActionResult DeletarCardapio(int id)
    {
        try
        {
            _cardapioRepositorio.DeletarCardapio(id);
            TempData["MenssagemSucesso"] = "Cardápio deletado com sucesso!";
            return RedirectToAction("GerenciarCardapio");
        }
        catch (Exception ex)
        {
            TempData["MenssagemErro"] = "Erro ao deletar cardápio!";
            return RedirectToAction("ApagarCardapio");
        }
    }

    [HttpPost]
    public IActionResult EditarCardapio(CardapioModel model)
    {
        try
        {
            if(ModelState.IsValid)
            {
                _cardapioRepositorio.EditarCardapio(model);
                TempData["MenssagemSucesso"] = "Cardápio alterado com sucesso!";
                return RedirectToAction("GerenciarCardapio");
            }
            else
            {
                TempData["MenssagemErro"] = $"Prencha os campos corretamente!";
                return View();
            }
        }
        catch (Exception ex)
        {
            TempData["MenssagemErro"] = $"Erro no banco de dados!";
            return View();
        }
    }
}