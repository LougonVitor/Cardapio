using System.ComponentModel.DataAnnotations;

namespace CardapioSnd.Models;

public class CardapioModel
{
    [Key]
    public int ID_CARDAPIO { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public DateOnly DATA_CARDAPIO { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string GUARNICAO { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string CARNE { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string SALADA_LEGUMES { get; set; }

    public string? EXTRAS { get; set; }
}