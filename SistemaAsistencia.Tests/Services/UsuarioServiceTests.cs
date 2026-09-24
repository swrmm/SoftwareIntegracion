using System;
using System.Linq;
using SistemaAsistencia.Data;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;
using Xunit;

namespace SistemaAsistencia.Tests.Services
{
    public class UsuarioServiceTests
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            DatabaseInitializer.Initialize();
            _usuarioService = new UsuarioService();
        }

        [Fact]
        public void CrearUsuario_ConDatosValidos_DeberiaCrearUsuarioCorrectamente()
        {
            // Arrange
            string correoPrueba = $"test_{Guid.NewGuid():N}@empresa.cl";

            // Act
            bool resultado = _usuarioService.Crear("Juan Perez", correoPrueba, "pass123", RolUsuario.Empleado);

            // Assert
            Assert.True(resultado);

            var usuario = _usuarioService.ObtenerTodos().FirstOrDefault(u => u.Correo == correoPrueba);
            Assert.NotNull(usuario);
            Assert.Equal("Juan Perez", usuario.Nombre);
            Assert.Equal(RolUsuario.Empleado, usuario.Rol);
        }

        [Fact]
        public void CrearUsuario_ConCorreoDuplicado_DeberiaRetornarFalse()
        {
            // Act - Intentar crear usuario con correo de admin ya existente
            bool resultado = _usuarioService.Crear("Otro Admin", "admin@empresa.cl", "pass123", RolUsuario.Administrador);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void ModificarUsuario_ConDatosValidos_DeberiaActualizarRegistro()
        {
            // Arrange
            string correoBase = $"mod_{Guid.NewGuid():N}@empresa.cl";
            _usuarioService.Crear("Original", correoBase, "pass123", RolUsuario.Empleado);
            var usuario = _usuarioService.ObtenerTodos().First(u => u.Correo == correoBase);

            // Act
            string nuevoCorreo = $"mod2_{Guid.NewGuid():N}@empresa.cl";
            bool resultado = _usuarioService.Modificar(usuario.Id, "Nombre Modificado", nuevoCorreo, "nuevaClave123", RolUsuario.Administrador);

            // Assert
            Assert.True(resultado);
            var usuarioModificado = _usuarioService.ObtenerPorId(usuario.Id);
            Assert.NotNull(usuarioModificado);
            Assert.Equal("Nombre Modificado", usuarioModificado.Nombre);
            Assert.Equal(nuevoCorreo, usuarioModificado.Correo);
            Assert.Equal(RolUsuario.Administrador, usuarioModificado.Rol);
        }

        [Fact]
        public void EliminarUsuario_DeberiaDesactivarUsuario()
        {
            // Arrange
            string correo = $"elim_{Guid.NewGuid():N}@empresa.cl";
            _usuarioService.Crear("Para Eliminar", correo, "pass123", RolUsuario.Empleado);
            var usuario = _usuarioService.ObtenerTodos().First(u => u.Correo == correo);

            // Act
            bool resultado = _usuarioService.Eliminar(usuario.Id);

            // Assert
            Assert.True(resultado);
            var usuarioInactivo = _usuarioService.ObtenerPorId(usuario.Id);
            Assert.NotNull(usuarioInactivo);
            Assert.False(usuarioInactivo.Activo);
        }
    }
}
