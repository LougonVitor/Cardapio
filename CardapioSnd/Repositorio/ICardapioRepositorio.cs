using CardapioSnd.Models;

namespace CardapioSnd.Repositorio;

public interface ICardapioRepositorio
{
    CardapioModel AdicionarCardapio(CardapioAdicionarModel model);
    CardapioAdicionarModel BuscarAlimentos();
    List<CardapioModel> ListarTodos();
    CardapioModel BuscarPorId(int id);
    void DeletarCardapio(int id);
    CardapioModel EditarCardapio(CardapioModel model);
    CardapioModel BuscarCardapioDoDia();
    List<CardapioModel> BuscarCardapioSemana();
}