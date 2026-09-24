using System;
using System.Linq;
using SistemaAsistencia.Data;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;
using Xunit;

namespace SistemaAsistencia.Tests.Services
{
    public class ReporteServiceTests
    {
        private readonly ReporteService _reporteService;
        private readonly UsuarioService _usuarioService;

        public ReporteServiceTests()
        {
            DatabaseInitializer.Initialize();
            _reporteService = new ReporteService();
            _usuarioService = new UsuarioService();
        }

        [Fact]
        public void ObtenerAtrasos_RetornaListaReporteAtrasos()
        {
            // Arrange
            DateTime inicio = DateTime.Today.AddDays(-7);
            DateTime fin = DateTime.Today;

            // Act
            var atrasos = _reporteService.ObtenerAtrasos(inicio, fin);

            // Assert
            Assert.NotNull(atrasos);
        }

        [Fact]
        public void ObtenerSalidasAnticipadas_RetornaListaReporteSalidas()
        {
            // Arrange
            DateTime inicio = DateTime.Today.AddDays(-7);
            DateTime fin = DateTime.Today;

            // Act
            var salidas = _reporteService.ObtenerSalidasAnticipadas(inicio, fin);

            // Assert
            Assert.NotNull(salidas);
        }

        [Fact]
        public void ObtenerInasistencias_RetornaListaReporteInasistencias()
        {
            // Arrange
            DateTime inicio = DateTime.Today.AddDays(-7);
            DateTime fin = DateTime.Today;

            // Act
            var inasistencias = _reporteService.ObtenerInasistencias(inicio, fin);

            // Assert
            Assert.NotNull(inasistencias);
        }
    }
}
