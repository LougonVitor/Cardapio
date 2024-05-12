using CardapioSnd.Data;
using CardapioSnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardapioSnd.Repositorio;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly BancoContext _bancoContext;
    public UsuarioRepositorio(BancoContext meuContexto)
    {
        this._bancoContext = meuContexto;   
    }

    public UsuarioModel Criar(UsuarioModel usuario)
    {
        try
        {
            usuario.DATA_CADASTRO = DateTime.Now;
            _bancoContext.USUARIO_SIS_CARDAPIO.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<UsuarioModel> BuscarTodosUsuario()
    {
        return _bancoContext.USUARIO_SIS_CARDAPIO.ToList();
    }

    public UsuarioModel BuscarUsuarioPorId(int id)
    {
        return _bancoContext.USUARIO_SIS_CARDAPIO.FirstOrDefault(x => x.ID_USUARIO == id);
    }

    public void DeletarUsuario(int id)
    {
        UsuarioModel usuarioDb = BuscarUsuarioPorId(id);

        if(usuarioDb != null) 
        {
            _bancoContext.USUARIO_SIS_CARDAPIO.Remove(usuarioDb);
            _bancoContext.SaveChanges();    
        }
    }

    public void Editar(UsuarioModel usuario)
    {
        UsuarioModel usuarioDb = BuscarUsuarioPorId(usuario.ID_USUARIO);

        if(usuarioDb != null)
        {
            usuarioDb.LOGIN = usuario.LOGIN;
            usuarioDb.NOME = usuario.NOME;
            usuarioDb.EMAIL = usuario.EMAIL;
            usuarioDb.PERFIL = usuario.PERFIL;
            usuarioDb.DATA_ATUALIZACAO = usuario.DATA_ATUALIZACAO;
            _bancoContext.USUARIO_SIS_CARDAPIO.Update(usuarioDb);
            _bancoContext.SaveChanges();
        }
        else
        {
            throw new Exception("Usuario não encontrado no banco de dados!");
        }
    }

    public UsuarioModel BuscarUsuarioPorLogin(string login)
    {
        try
        {
            UsuarioModel usuarioDb = _bancoContext.USUARIO_SIS_CARDAPIO.FirstOrDefault(o => o.LOGIN == login);
            return usuarioDb;
        }
        catch(Exception ex)
        {
            throw new Exception("Erro ao busca login no banco de dados: " + ex.Message);
        }
    }

    public UsuarioModel RedefinirSenha(UsuarioModel usuario)
    {
        _bancoContext.USUARIO_SIS_CARDAPIO.Update(usuario);
        _bancoContext.SaveChanges();
        return usuario;
    }
}