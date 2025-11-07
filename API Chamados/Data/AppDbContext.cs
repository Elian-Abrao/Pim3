using System;
using System.Collections.Generic;
using API_Chamados.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Chamados.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Chamado> Chamados { get; set; }

    public virtual DbSet<Mensagem> Mensagems { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.HasIndex(e => e.Nome, "categoria_nome_key").IsUnique();

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Chamado>(entity =>
        {
            entity.HasKey(e => e.IdChamado).HasName("chamado_pkey");

            entity.ToTable("chamado");

            entity.Property(e => e.IdChamado).HasColumnName("id_chamado");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.DataAbertura)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_abertura");
            entity.Property(e => e.DataEncerramento)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_encerramento");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.PrioridadeId).HasColumnName("prioridade_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'aberto'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Chamados)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_chamado_categoria");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Chamados)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_chamado_usuario");
        });

        modelBuilder.Entity<Mensagem>(entity =>
        {
            entity.HasKey(e => e.IdMensagem).HasName("mensagem_pkey");

            entity.ToTable("mensagem");

            entity.Property(e => e.IdMensagem).HasColumnName("id_mensagem");
            entity.Property(e => e.Conteudo).HasColumnName("conteudo");
            entity.Property(e => e.DataEnvio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_envio");
            entity.Property(e => e.IdChamado).HasColumnName("id_chamado");
            entity.Property(e => e.IdRemetente).HasColumnName("id_remetente");

            entity.HasOne(d => d.IdChamadoNavigation).WithMany(p => p.Mensagems)
                .HasForeignKey(d => d.IdChamado)
                .HasConstraintName("fk_mensagem_chamado");

            entity.HasOne(d => d.IdRemetenteNavigation).WithMany(p => p.Mensagems)
                .HasForeignKey(d => d.IdRemetente)
                .HasConstraintName("fk_mensagem_remetente");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "usuario_email_key").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.SenhaHash)
                .HasMaxLength(255)
                .HasColumnName("senha_hash");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
