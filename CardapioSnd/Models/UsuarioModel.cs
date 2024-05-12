using CardapioSnd.Enums;
using System.ComponentModel.DataAnnotations;

namespace CardapioSnd.Models;

public class UsuarioModel
{
    [Key]
    public int ID_USUARIO { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string LOGIN {  get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string NOME { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string EMAIL { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string SENHA { get; set; }
    public DateTime DATA_CADASTRO { get; set; }
    public DateTime? DATA_ATUALIZACAO { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public PerfilEnum PERFIL { get; set; }
}