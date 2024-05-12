using System.ComponentModel.DataAnnotations;

namespace CardapioSnd.Models;

public class AlimentoModel
{
    [Key]
    public int ID_ALIMENTO { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string TP_ALIMENT0 { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string DS_ALIMENTO { get; set; }
}