using CardapioSnd.Data;
using CardapioSnd.Models;

namespace CardapioSnd.Repositorio;

public class AlimentoRepositorio : IAlimentoRepositorio
{
    private readonly BancoContext _bancoContext;
    public AlimentoRepositorio(BancoContext contexto)
    {
        this._bancoContext = contexto;
    }

    public AlimentoModel AdicionarAlimento(AlimentoModel model)
    {
        _bancoContext.ALIMENTO_SIS_CARDAPIO.Add(model);
        _bancoContext.SaveChanges();
        return model;
    }

    public List<AlimentoModel> BuscarTodosAlimentos()
    {
        List<AlimentoModel> alimentos = _bancoContext.ALIMENTO_SIS_CARDAPIO.ToList();
        return alimentos;
    }

    public AlimentoModel BuscarAlimentoPorId(int id)
    {
        AlimentoModel ali = _bancoContext.ALIMENTO_SIS_CARDAPIO.FirstOrDefault(o => o.ID_ALIMENTO == id);
        if(ali != null)
        {
            return ali;
        }
        else
        {
            throw new Exception("Alimento não encotrado no banco de dados!");
        }
    }

    public AlimentoModel EditarAlimento(AlimentoModel model)
    {
        _bancoContext.ALIMENTO_SIS_CARDAPIO.Update(model);
        _bancoContext.SaveChanges();
        return model;
    }

    public void DeletarAlimento(int id)
    {
        AlimentoModel alimentoDb = BuscarAlimentoPorId(id);

        if(alimentoDb != null)
        {
            _bancoContext.ALIMENTO_SIS_CARDAPIO.Remove(alimentoDb);
            _bancoContext.SaveChanges();
        }
        else
        {
            throw new Exception("Alimento não encontrado no banco de dados!");
        }
    }
}