using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Context
{
    public class BdContext : DbContext
    {
        public DbSet<Casa> Casas { get; set; }
        public DbSet<CasaUtilizador> CasaUtilizadors { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<HistoricoUtilizador> HistoricoUtilizadors { get; set; }
        public DbSet<Imagem> Imagems { get; set; }
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Notificacao> Notificacaos { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoNotificacaoTB> TipoNotificacaoTBs { get; set; }
        public DbSet<TipoUtilizadorTB> TipoUtilizadorTBs { get; set; }
        public DbSet<Utilizador> Utilizadors { get; set; }

        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //Campos Unicos
            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasIndex(e => e.username).IsUnique();
                entity.HasIndex(e => e.email).IsUnique();
            });

            //Definição dos relacionamentos
            modelBuilder.Entity<Casa>(entity => {
                entity.HasOne<Estado>(e => e.Estado).WithMany(c => c.Casas).HasForeignKey(f => f.idEstado);
                entity.HasOne<Morada>(m => m.Morada).WithMany(c => c.Casas).HasForeignKey(f => f.idMorada);
                entity.HasMany<CasaUtilizador>(c => c.CasaUtilizadors).WithOne(uh => uh.Casa).HasForeignKey(f => f.idCasa);
                entity.HasMany<Quarto>(q => q.Quartos).WithOne(c => c.Casa).HasForeignKey(f => f.idCasa);
            });

            modelBuilder.Entity<CasaUtilizador>().HasOne<Utilizador>(u => u.Utilizador)
                .WithMany(c => c.CasaUtilizadors).HasForeignKey(f => f.idUtilizador);
            
            modelBuilder.Entity<Comentario>().HasOne<Reserva>(r => r.Reserva)
                .WithMany(c => c.Comentarios).HasForeignKey(f => f.idReserva);

            modelBuilder.Entity<Estado>(entity => {
                entity.HasMany<Reserva>(r => r.Reservas).WithOne(e => e.Estado).HasForeignKey(f => f.idEstado);
                entity.HasMany<Quarto>(q => q.Quartos).WithOne(e => e.Estado).HasForeignKey(f => f.idEstado);
            });

            modelBuilder.Entity<HistoricoUtilizador>().HasOne<Utilizador>(u => u.Utilizador)
                .WithMany(h => h.HistoricoUtilizadors).HasForeignKey(f => f.idUtilizador);

            modelBuilder.Entity<Imagem>().HasOne<Quarto>(q => q.Quarto)
                .WithMany(i => i.Imagems).HasForeignKey(f => f.idQuarto);

            modelBuilder.Entity<Morada>().HasMany<Utilizador>(u => u.Utilizadors)
                .WithOne(m => m.Morada).HasForeignKey(f => f.idMorada);

            modelBuilder.Entity<Notificacao>(entity => {
                entity.HasOne<Utilizador>(u => u.Utilizador).WithMany(n => n.Notificacaos).HasForeignKey(f => f.idUtilizador);
                entity.HasOne<TipoNotificacaoTB>(t => t.TipoNotificacaoTB).WithMany(n => n.Notificacaos).HasForeignKey(f => f.idTipoNotificacao);
            });

            modelBuilder.Entity<Quarto>().HasMany<Reserva>(r => r.Reservas)
                .WithOne(q => q.Quarto).HasForeignKey(f => f.idQuarto);

            modelBuilder.Entity<Reserva>().HasOne<Utilizador>(u => u.Utilizador)
                .WithMany(r => r.Reservas).HasForeignKey(f => f.idUtilizador);

            modelBuilder.Entity<TipoUtilizadorTB>().HasMany<Utilizador>(u => u.Utilizadors)
                .WithOne(t => t.TipoUtilizadorTB).HasForeignKey(f => f.idTipUtilizador);
        }
    }
}
