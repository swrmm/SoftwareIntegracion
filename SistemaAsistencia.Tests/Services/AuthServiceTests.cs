using System;
using System.IO;
using SistemaAsistencia.Data;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;
using Xunit;

namespace SistemaAsistencia.Tests.Services
{
    public class AuthServiceTests : IDisposable
    {
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            DatabaseInitializer.Initialize();
            _authService = new AuthService();
        }

        public void Dispose()
        {
            // Limpieza si es necesaria
        }

        [Fact]
        public void Login_ConCredencialesCorrectas_DeberiaRetornarTrue()
        {
            // Act
            bool resultado = _authService.Login("admin@empresa.cl", "admin123");

            // Assert
            Assert.True(resultado);
            Assert.NotNull(_authService.UsuarioActual);
            Assert.Equal("admin@empresa.cl", _authService.UsuarioActual.Correo);
            Assert.True(_authService.EsAdmin);
        }

        [Fact]
        public void Login_ConContrasenaIncorrecta_DeberiaRetornarFalse()
        {
            // Act
            bool resultado = _authService.Login("admin@empresa.cl", "clave_erronea");

            // Assert
            Assert.False(resultado);
            Assert.Null(_authService.UsuarioActual);
        }

        [Fact]
        public void Login_ConUsuarioInexistente_DeberiaRetornarFalse()
        {
            // Act
            bool resultado = _authService.Login("noexiste@empresa.cl", "admin123");

            // Assert
            Assert.False(resultado);
            Assert.Null(_authService.UsuarioActual);
        }

        [Fact]
        public void Logout_DeberiaLimpiarSesionUsuario()
        {
            // Arrange
            _authService.Login("admin@empresa.cl", "admin123");
            Assert.NotNull(_authService.UsuarioActual);

            // Act
            _authService.Logout();

            // Assert
            Assert.Null(_authService.UsuarioActual);
        }
    }
}
