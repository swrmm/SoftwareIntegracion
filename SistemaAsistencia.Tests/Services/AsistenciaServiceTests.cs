using System;
using System.Linq;
using SistemaAsistencia.Data;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;
using Xunit;

namespace SistemaAsistencia.Tests.Services
{
    public class AsistenciaServiceTests
    {
        private readonly AsistenciaService _asistenciaService;
        private readonly UsuarioService _usuarioService;

        public AsistenciaServiceTests()
        {
            DatabaseInitializer.Initialize();
            _asistenciaService = new AsistenciaService();
            _usuarioService = new UsuarioService();
        }

        [Fact]
        public void RegistrarEntrada_PrimerMarcaje_DeberiaGuardarCorrectamente()
        {
            // Arrange
            string correo = $"asist_{Guid.NewGuid():N}@empresa.cl";
            _usuarioService.Crear("Empleado Asistencia", correo, "pass123", RolUsuario.Empleado);
            var usuario = _usuarioService.ObtenerTodos().First(u => u.Correo == correo);

            // Act
            bool resultado = _asistenciaService.RegistrarEntrada(usuario.Id);

            // Assert
            Assert.True(resultado);
            Assert.True(_asistenciaService.VerificarEntradaHoy(usuario.Id));
            Assert.True(_asistenciaService.TieneEntradaHoy(usuario.Id));
        }

        [Fact]
        public void RegistrarEntrada_SegundoMarcajeMismoDia_DeberiaRetornarFalse()
        {
            // Arrange
            string correo = $"asist_dup_{Guid.NewGuid():N}@empresa.cl";
            _usuarioService.Crear("Empleado Doble Entrada", correo, "pass123", RolUsuario.Empleado);
            var usuario = _usuarioService.ObtenerTodos().First(u => u.Correo == correo);
            _asistenciaService.RegistrarEntrada(usuario.Id);

            // Act - Reintento el mismo día
            bool resultadoSegundoMarcaje = _asistenciaService.RegistrarEntrada(usuario.Id);

            // Assert
            Assert.False(resultadoSegundoMarcaje);
        }

        [Fact]
        public void RegistrarSalida_PrimerMarcaje_DeberiaGuardarCorrectamente()
        {
            // Arrange
            string correo = $"salida_{Guid.NewGuid():N}@empresa.cl";
            _usuarioService.Crear("Empleado Salida", correo, "pass123", RolUsuario.Empleado);
            var usuario = _usuarioService.ObtenerTodos().First(u => u.Correo == correo);

            // Act
            bool resultado = _asistenciaService.RegistrarSalida(usuario.Id);

            // Assert
            Assert.True(resultado);
            Assert.True(_asistenciaService.VerificarSalidaHoy(usuario.Id));
            Assert.True(_asistenciaService.TieneSalidaHoy(usuario.Id));
        }
    }
}
