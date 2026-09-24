using System.Linq;
using SistemaAsistencia.Data;
using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services
{
    /// <summary>
    /// Servicio encargado de la autenticación de usuarios y gestión de la sesión activa.
    /// </summary>
    public class AuthService
    {
        /// <summary>
        /// Obtiene el usuario autenticado actualmente en la sesión de la aplicación.
        /// </summary>
        public Usuario? UsuarioActual { get; private set; }

        /// <summary>
        /// Autentica un usuario verificando su correo y contraseña contra la base de datos.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <param name="contrasena">Contraseña en texto plano ingresada.</param>
        /// <returns><c>true</c> si las credenciales son válidas y la cuenta está activa; de lo contrario, <c>false</c>.</returns>
        public bool Login(string correo, string contrasena)
        {
            using var context = new AppDbContext();
            var usuario = context.Usuarios.FirstOrDefault(u => u.Correo == correo && u.Activo);

            if (usuario == null)
                return false;

            if (!BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena))
                return false;

            UsuarioActual = usuario;
            return true;
        }

        /// <summary>
        /// Cierra la sesión activa actualizando <see cref="UsuarioActual"/> a null.
        /// </summary>
        public void Logout()
        {
            UsuarioActual = null;
        }

        /// <summary>
        /// Indica si el usuario actualmente autenticado posee el rol de Administrador.
        /// </summary>
        public bool EsAdmin => UsuarioActual?.Rol == RolUsuario.Administrador;
    }
}

