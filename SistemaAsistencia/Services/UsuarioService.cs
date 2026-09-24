using System.Collections.Generic;
using System.Linq;
using SistemaAsistencia.Data;
using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services
{
    /// <summary>
    /// Servicio encargado de la gestión de usuarios (CRUD) y mantenimiento de cuentas en el sistema.
    /// </summary>
    public class UsuarioService
    {
        /// <summary>
        /// Obtiene la lista de todos los usuarios activos ordenados por nombre.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Usuario"/> activos.</returns>
        public List<Usuario> ObtenerTodos()
        {
            using var context = new AppDbContext();
            return context.Usuarios.Where(u => u.Activo).OrderBy(u => u.Nombre).ToList();
        }

        /// <summary>Alias para <see cref="ObtenerTodos"/>.</summary>
        public List<Usuario> ObtenerUsuarios() => ObtenerTodos();

        /// <summary>
        /// Busca un usuario por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
        /// <returns>El objeto <see cref="Usuario"/> encontrado o <c>null</c>.</returns>
        public Usuario? ObtenerPorId(int id)
        {
            using var context = new AppDbContext();
            return context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Verifica si existe una cuenta activa asociada al correo electrónico especificado.
        /// </summary>
        /// <param name="correo">Correo a consultar.</param>
        /// <returns><c>true</c> si existe un usuario activo con dicho correo; de lo contrario, <c>false</c>.</returns>
        public bool ExisteCorreo(string correo)
        {
            using var context = new AppDbContext();
            return context.Usuarios.Any(u => u.Correo == correo && u.Activo);
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema codificando su contraseña con BCrypt.
        /// </summary>
        /// <param name="nombre">Nombre completo.</param>
        /// <param name="correo">Correo electrónico único.</param>
        /// <param name="contrasena">Contraseña en texto plano.</param>
        /// <param name="rol">Rol asignado (Empleado / Administrador).</param>
        /// <returns><c>true</c> si el usuario fue registrado correctamente; <c>false</c> si el correo ya existe.</returns>
        public bool Crear(string nombre, string correo, string contrasena, RolUsuario rol)
        {
            using var context = new AppDbContext();
            if (context.Usuarios.Any(u => u.Correo == correo))
                return false;

            var usuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contrasena = BCrypt.Net.BCrypt.HashPassword(contrasena),
                Rol = rol,
                Activo = true
            };

            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return true;
        }

        /// <summary>Alias para <see cref="Crear"/> utilizando la entidad Usuario.</summary>
        public bool CrearUsuario(Usuario u, string contrasena)
        {
            return Crear(u.Nombre, u.Correo, contrasena, u.Rol);
        }

        /// <summary>
        /// Modifica los datos de un usuario existente. Si se provee nueva contraseña, la actualiza encriptada.
        /// </summary>
        /// <param name="id">ID del usuario a modificar.</param>
        /// <param name="nombre">Nuevo nombre completo.</param>
        /// <param name="correo">Nuevo correo electrónico.</param>
        /// <param name="nuevaContrasena">Nueva contraseña en texto plano (opcional).</param>
        /// <param name="rol">Nuevo rol asignado.</param>
        /// <returns><c>true</c> si la actualización fue exitosa; <c>false</c> si el usuario no existe o el correo pertenece a otro usuario.</returns>
        public bool Modificar(int id, string nombre, string correo, string? nuevaContrasena, RolUsuario rol)
        {
            using var context = new AppDbContext();
            var usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return false;

            if (context.Usuarios.Any(u => u.Correo == correo && u.Id != id))
                return false;

            usuario.Nombre = nombre;
            usuario.Correo = correo;
            usuario.Rol = rol;

            if (!string.IsNullOrEmpty(nuevaContrasena))
                usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);

            context.SaveChanges();
            return true;
        }

        /// <summary>Alias para <see cref="Modificar"/> utilizando la entidad Usuario.</summary>
        public bool ModificarUsuario(Usuario u, string? nuevaContrasena)
        {
            return Modificar(u.Id, u.Nombre, u.Correo, nuevaContrasena, u.Rol);
        }

        /// <summary>
        /// Desactiva (baja lógica) a un usuario en el sistema.
        /// </summary>
        /// <param name="id">ID del usuario a desactivar.</param>
        /// <returns><c>true</c> si la operación fue exitosa; <c>false</c> si el usuario no existe.</returns>
        public bool Eliminar(int id)
        {
            using var context = new AppDbContext();
            var usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return false;

            usuario.Activo = false;
            context.SaveChanges();
            return true;
        }

        /// <summary>Alias para <see cref="Eliminar"/>.</summary>
        public bool EliminarUsuario(int id) => Eliminar(id);
    }
}

