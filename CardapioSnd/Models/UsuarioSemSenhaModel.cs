using CardapioSnd.Enums;

namespace CardapioSnd.Models;

public class UsuarioSemSenhaModel
{
    public int Id { get; set; }
    public string Login {  get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public PerfilEnum Perfil { get; set; }
}