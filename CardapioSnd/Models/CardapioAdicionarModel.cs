using System.ComponentModel.DataAnnotations;

namespace CardapioSnd.Models;

public class CardapioAdicionarModel
{
    [Required(ErrorMessage = "Campo Obrigatório!")]
    public DateOnly DataCardapio { get; set; }


    public List<AlimentoModel> AlimentoGuarnicao { get; set; }
    public List<AlimentoModel> AlimentoCarne { get; set; }
    public List<AlimentoModel> AlimentoSalada { get; set; }
    public List<AlimentoModel> AlimentoExtra { get; set; }


    public string AlimentoGuarnicaoSelect { get; set; }
    public string AlimentoGuarnicaoInput { get; set; }


    public string AlimentoCarneSelect { get; set; }
    public string AlimentoCarneInput { get; set; }


    public string AlimentoSaladaSelect { get; set; }
    public string AlimentoSaladaInput { get; set; }


    public string AlimentoExtraSelect { get; set; }
    public string AlimentoExtraInput { get; set; }
}