using PersistencePoc.Core.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PersistencePoc.Infra.EntityFrameworkSix.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Server=localhost;Database=poc-test;User Id=entity;Password=Password@123")
        {
        }

        public DbSet<Cep>? Ceps { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<ClienteConcessionaria>? ClienteConcessionarias { get; set; }
        public DbSet<Concessionaria>? Concessionarias { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Proposta>? Propostas { get; set; }
        public DbSet<Seguro>? Seguros { get; set; }
        public DbSet<Simulacao>? Simulacoes { get; set; }
        public DbSet<TipoDocumento>? TiposDocumento { get; set; }
        public DbSet<Vendedor>? Vendedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Cep>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.Cep)
                .WithMany(c => c!.Enderecos)
                .HasForeignKey(e => e.CepId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cliente>()
                .HasOptional(c => c.TipoDocumento)
                .WithMany()
                .HasForeignKey(c => c.TipoDocumentoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.Cliente)
                .WithMany(c => c!.Enderecos)
                .HasForeignKey(e => e.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClienteConcessionaria>()
                .HasKey(cc => cc.Id);

            modelBuilder.Entity<ClienteConcessionaria>()
                .HasRequired(cc => cc.Cliente)
                .WithMany(c => c!.ClienteConcessionarias)
                .HasForeignKey(cc => cc.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClienteConcessionaria>()
                .HasRequired(cc => cc.Concessionaria)
                .WithMany(c => c!.ClienteConcessionarias)
                .HasForeignKey(cc => cc.ConcessionariaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Concessionaria>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Concessionaria>()
                .HasRequired(c => c.Endereco)
                .WithMany(e => e!.Concessionarias)
                .HasForeignKey(c => c.EnderecoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendedor>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Vendedor>()
                .HasRequired(v => v.Concessionaria)
                .WithMany(c => c!.Vendedores)
                .HasForeignKey(v => v.ConcessionariaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendedor>()
                .HasRequired(v => v.TipoDocumento)
                .WithMany()
                .HasForeignKey(v => v.TipoDocumentoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Simulacao>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Simulacao>()
                .HasRequired(s => s.Produto)
                .WithMany(p => p!.Simulacoes)
                .HasForeignKey(s => s.ProdutoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proposta>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Proposta>()
                .HasRequired(p => p.Cliente)
                .WithMany(c => c!.Propostas)
                .HasForeignKey(p => p.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proposta>()
                .HasRequired(p => p.Produto)
                .WithMany(pr => pr!.Propostas)
                .HasForeignKey(p => p.ProdutoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proposta>()
                .HasRequired(p => p.Concessionaria)
                .WithMany(c => c!.Propostas)
                .HasForeignKey(p => p.ConcessionariaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proposta>()
                .HasOptional(p => p.Seguro)
                .WithMany(s => s!.Propostas)
                .HasForeignKey(p => p.SeguroId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proposta>()
                .HasRequired(p => p.Vendedor)
                .WithMany(v => v!.Propostas)
                .HasForeignKey(p => p.VendedorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seguro>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Seguro>()
                .HasRequired(s => s.Cliente)
                .WithMany(c => c!.Seguros)
                .HasForeignKey(s => s.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seguro>()
                .HasRequired(s => s.Produto)
                .WithMany(p => p!.Seguros)
                .HasForeignKey(s => s.ProdutoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seguro>()
                .HasRequired(s => s.Concessionaria)
                .WithMany(c => c!.Seguros)
                .HasForeignKey(s => s.ConcessionariaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Simulacao>()
                .HasRequired(s => s.Cliente)
                .WithMany(c => c!.Simulacoes)
                .HasForeignKey(s => s.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Simulacao>()
                .HasRequired(s => s.Concessionaria)
                .WithMany(c => c!.Simulacoes)
                .HasForeignKey(s => s.ConcessionariaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoDocumento>()
                .HasKey(td => td.Id);
        }
    }
}
