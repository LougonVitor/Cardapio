using CardapioSnd.Models;
using Microsoft.EntityFrameworkCore;

namespace CardapioSnd.Data;

public class BancoContext : DbContext
{
    public BancoContext (DbContextOptions<BancoContext> options) : base(options)
    {
    }
    
    public DbSet<UsuarioModel> USUARIO_SIS_CARDAPIO { get; set; }
    public DbSet<CardapioModel> CARDAPIO_SIS_CARDAPIO { get; set; }
    public DbSet<AlimentoModel> ALIMENTO_SIS_CARDAPIO { get; set; }
    
}