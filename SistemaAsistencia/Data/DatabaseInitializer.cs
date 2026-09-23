using System.Linq;
using SistemaAsistencia.Models;

namespace SistemaAsistencia.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            if (!context.Usuarios.Any(u => u.Rol == RolUsuario.Administrador))
            {
                var admin = new Usuario
                {
                    Nombre = "Administrador",
                    Correo = "admin@empresa.cl",
                    Contrasena = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Rol = RolUsuario.Administrador,
                    Activo = true
                };
                context.Usuarios.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
