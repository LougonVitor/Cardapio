using CardapioSnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace CardapioSnd.Models;

public class UsuarioRedefinirSenhaModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string Login {  get; set; }
    public DateTime? DataAtualizacao { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string Senha { get; set; }
}