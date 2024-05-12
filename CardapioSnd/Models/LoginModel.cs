using System.ComponentModel.DataAnnotations;

namespace CardapioSnd.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Senha { get; set; }
}