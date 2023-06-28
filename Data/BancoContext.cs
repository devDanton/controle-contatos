using ControleContatos.Models;
using Microsoft.EntityFrameworkCore; //pacote que permite herdar o contexto db

namespace ControleContatos.Data
{
    public class BancoContext : DbContext //Herdando conexto do banco de dados
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
