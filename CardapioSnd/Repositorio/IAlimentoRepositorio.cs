using CardapioSnd.Models;

namespace CardapioSnd.Repositorio;

public interface IAlimentoRepositorio
{
    AlimentoModel AdicionarAlimento(AlimentoModel model);
    List<AlimentoModel> BuscarTodosAlimentos();
    AlimentoModel BuscarAlimentoPorId(int id);
    AlimentoModel EditarAlimento(AlimentoModel model);
    void DeletarAlimento(int id);
}