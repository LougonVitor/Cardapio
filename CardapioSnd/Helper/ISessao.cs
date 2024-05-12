using CardapioSnd.Models;

namespace CardapioSnd.Helper;

public interface ISessao
{
    void CriarSessao(UsuarioModel usuario);
    void RemoverSessao();
    UsuarioModel BuscarSessao();
}