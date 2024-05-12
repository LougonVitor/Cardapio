using CardapioSnd.Models;

namespace CardapioSnd.Repositorio;

public interface IUsuarioRepositorio
{
    UsuarioModel Criar(UsuarioModel usuario);
    List<UsuarioModel> BuscarTodosUsuario();
    UsuarioModel BuscarUsuarioPorId(int id);
    void DeletarUsuario(int id);
    void Editar(UsuarioModel usuario);
    UsuarioModel BuscarUsuarioPorLogin(string login);
    UsuarioModel RedefinirSenha(UsuarioModel usuario);
}