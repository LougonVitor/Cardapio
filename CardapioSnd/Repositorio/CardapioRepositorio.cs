using CardapioSnd.Data;
using CardapioSnd.Models;
using Microsoft.EntityFrameworkCore;
using static CardapioSnd.Models.CardapioAdicionarModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CardapioSnd.Repositorio;

public class CardapioRepositorio : ICardapioRepositorio
{
    private readonly BancoContext _bancoContext;
    public CardapioRepositorio(BancoContext context)
    {
        _bancoContext = context;
    }

    public CardapioModel AdicionarCardapio(CardapioAdicionarModel model)
    {
        CardapioModel cardapioDb = _bancoContext.CARDAPIO_SIS_CARDAPIO.FirstOrDefault(x => x.DATA_CARDAPIO == model.DataCardapio);
        if (cardapioDb == null)
        {
            CardapioModel cardapio = new CardapioModel();
            cardapio.DATA_CARDAPIO = model.DataCardapio;
            cardapio.GUARNICAO = $"{model.AlimentoGuarnicaoSelect} {model.AlimentoGuarnicaoInput}";
            cardapio.CARNE = $"{model.AlimentoCarneSelect} {model.AlimentoCarneInput}";
            cardapio.SALADA_LEGUMES = $"{model.AlimentoSaladaSelect} {model.AlimentoSaladaInput}";
            cardapio.EXTRAS = $"{model.AlimentoExtraSelect} {model.AlimentoExtraInput}";

            _bancoContext.CARDAPIO_SIS_CARDAPIO.Add(cardapio);
            _bancoContext.SaveChanges();
            return cardapio;
        }
        else
        {
            throw new Exception("Cardapio com data ja cadastrada!");
        }
    }

    public CardapioAdicionarModel BuscarAlimentos()
    {
        
        List<AlimentoModel> alimentoGuarnicao = _bancoContext.ALIMENTO_SIS_CARDAPIO.Where(x => x.TP_ALIMENT0 == "Gaurnição").ToList();
        List<AlimentoModel> alimentoSalada = _bancoContext.ALIMENTO_SIS_CARDAPIO.Where(x => x.TP_ALIMENT0 == "Salada e Legumes").ToList();
        List<AlimentoModel> alimentoCarne = _bancoContext.ALIMENTO_SIS_CARDAPIO.Where(x => x.TP_ALIMENT0 == "Carne").ToList();
        List<AlimentoModel> alimentoExtra = _bancoContext.ALIMENTO_SIS_CARDAPIO.Where(x => x.TP_ALIMENT0 == "Extras").ToList();

        CardapioAdicionarModel cardapioAdicionar = new CardapioAdicionarModel
        {
            AlimentoGuarnicao = alimentoGuarnicao,
            AlimentoSalada = alimentoSalada,
            AlimentoCarne = alimentoCarne,
            AlimentoExtra = alimentoExtra
        };

        return cardapioAdicionar;
    }

    public CardapioModel BuscarCardapioDoDia()
    {
        DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
        CardapioModel cardapioDoDia = _bancoContext.CARDAPIO_SIS_CARDAPIO.FirstOrDefault(x => x.DATA_CARDAPIO == dataAtual);
        return cardapioDoDia;
    }

    public List<CardapioModel> BuscarCardapioSemana()
    {
        DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
        DateOnly dataFinal = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
        List<CardapioModel> cardapiosSemana = _bancoContext.CARDAPIO_SIS_CARDAPIO.Where(x => x.DATA_CARDAPIO >= dataAtual && x.DATA_CARDAPIO < dataFinal).ToList();
        return cardapiosSemana;
    }

    public CardapioModel BuscarPorId(int id)
    {
        CardapioModel cardapioDb = _bancoContext.CARDAPIO_SIS_CARDAPIO.FirstOrDefault(x => x.ID_CARDAPIO == id);
        if (cardapioDb != null) 
        {
            return cardapioDb;
        }
        else
        {
            throw new Exception("Cardapio não encontrado no banco de dados!");
        }
    }

    public void DeletarCardapio(int id)
    {
        CardapioModel cardapioDb = BuscarPorId(id);
        _bancoContext.CARDAPIO_SIS_CARDAPIO.Remove(cardapioDb);
        _bancoContext.SaveChanges();
    }

    public CardapioModel EditarCardapio(CardapioModel model)
    {
        try
        {
            CardapioModel cardapioDb = BuscarPorId(model.ID_CARDAPIO);
            if (cardapioDb != null)
            {
                cardapioDb.DATA_CARDAPIO = model.DATA_CARDAPIO;
                cardapioDb.GUARNICAO = model.GUARNICAO;
                cardapioDb.CARNE = model.CARNE;
                cardapioDb.SALADA_LEGUMES = model.SALADA_LEGUMES;
                if(string.IsNullOrEmpty(model.EXTRAS))
                {
                    cardapioDb.EXTRAS = "";
                }
                else
                {
                    cardapioDb.EXTRAS = model.EXTRAS;
                }
                //cardapioDb.Extras = model.Extras;
                _bancoContext.CARDAPIO_SIS_CARDAPIO.Update(cardapioDb);
                _bancoContext.SaveChanges();
                return cardapioDb;
            }
            return cardapioDb;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro no banco de dados: " + ex.Message);
        }
    }

    public List<CardapioModel> ListarTodos()
    {
        return _bancoContext.CARDAPIO_SIS_CARDAPIO.ToList();
    }
}