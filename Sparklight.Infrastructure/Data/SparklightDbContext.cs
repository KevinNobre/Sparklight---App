using Microsoft.EntityFrameworkCore;
using Sparklight.Domain.Entities;

namespace Sparklight.Data
{
    public class SparklightDbContext : DbContext
    {
        public SparklightDbContext(DbContextOptions<SparklightDbContext> options) : base(options)
        {
        }

        // DbSets para cada entidade
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aparelho> Aparelhos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Pontuacao> Pontuacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Usuario
            modelBuilder.Entity<Usuario>().ToTable("tb_usuario");

            // Configuração da entidade Aparelho
            modelBuilder.Entity<Aparelho>().ToTable("tb_aparelho");

            // Configuração da entidade Item
            modelBuilder.Entity<Item>().ToTable("tb_item").HasKey(i => i.ItemId);

            // Configuração da entidade Historico
            modelBuilder.Entity<Historico>().ToTable("tb_historico").HasKey(h => h.HistoricoId);

            // Configuração da entidade Pontuacao
            modelBuilder.Entity<Pontuacao>().ToTable("tb_pontuacao").HasKey(p => p.PontuacaoId);


        }
    }
}
