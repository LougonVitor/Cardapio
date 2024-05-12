using CardapioSnd.Models;
using CardapioSnd.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CardapioSnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICardapioRepositorio _cardapioRepositorio;

        public HomeController(ILogger<HomeController> logger, ICardapioRepositorio cardapioRepositorio)
        {
            this._logger = logger;
            this._cardapioRepositorio = cardapioRepositorio;
        }

        public IActionResult Index()
        {
            CardapioModel cardapioDia = _cardapioRepositorio.BuscarCardapioDoDia();
            return View(cardapioDia);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CardapioSemana()
        {
            List<CardapioModel> cardapios = _cardapioRepositorio.BuscarCardapioSemana();

            return View(cardapios);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
