using Microsoft.EntityFrameworkCore;
using SistemaAsistencia.Models;
using System;
using System.IO;

namespace SistemaAsistencia.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<RegistroAsistencia> RegistrosAsistencia { get; set; } = null!;

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "asistencia.db");
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Correo).IsUnique();
                entity.Property(e => e.Rol).HasConversion<string>();
            });

            modelBuilder.Entity<RegistroAsistencia>(entity =>
            {
                entity.Property(e => e.Accion).HasConversion<string>();
                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(e => new { e.UsuarioId, e.Fecha, e.Accion });
            });
        }
    }
}
