using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SistemaAsistencia.Services;
using Xunit;

namespace SistemaAsistencia.Tests.Services
{
    public class ExportServiceTests
    {
        private readonly ExportService _exportService;

        public ExportServiceTests()
        {
            _exportService = new ExportService();
        }

        [Fact]
        public void GenerarCsvAtrasos_FormateaCorrectamente()
        {
            // Arrange
            var items = new List<ReporteAtrasoItem>
            {
                new ReporteAtrasoItem
                {
                    NombreEmpleado = "Juan Perez",
                    Correo = "juan@empresa.cl",
                    Fecha = new DateTime(2026, 10, 15),
                    HoraEntrada = new TimeSpan(9, 45, 0)
                }
            };

            // Act
            var csv = _exportService.GenerarCsvAtrasos(items);

            // Assert
            Assert.Contains("Empleado;Correo;Fecha;Hora de Entrada", csv);
            Assert.Contains("Juan Perez;juan@empresa.cl;15/10/2026;09:45:00", csv);
        }

        [Fact]
        public void GenerarCsvSalidas_FormateaCorrectamente()
        {
            // Arrange
            var items = new List<ReporteSalidaItem>
            {
                new ReporteSalidaItem
                {
                    NombreEmpleado = "Maria Soto",
                    Correo = "maria@empresa.cl",
                    Fecha = new DateTime(2026, 10, 16),
                    HoraSalida = new TimeSpan(16, 30, 0)
                }
            };

            // Act
            var csv = _exportService.GenerarCsvSalidas(items);

            // Assert
            Assert.Contains("Empleado;Correo;Fecha;Hora de Salida", csv);
            Assert.Contains("Maria Soto;maria@empresa.cl;16/10/2026;16:30:00", csv);
        }

        [Fact]
        public void GenerarCsvInasistencias_FormateaCorrectamente()
        {
            // Arrange
            var items = new List<ReporteInasistenciaItem>
            {
                new ReporteInasistenciaItem
                {
                    NombreEmpleado = "Carlos Diaz",
                    Correo = "carlos@empresa.cl",
                    Fecha = new DateTime(2026, 10, 17)
                }
            };

            // Act
            var csv = _exportService.GenerarCsvInasistencias(items);

            // Assert
            Assert.Contains("Empleado;Correo;Fecha", csv);
            Assert.Contains("Carlos Diaz;carlos@empresa.cl;17/10/2026", csv);
        }

        [Fact]
        public void GenerarCsv_EscapaCaracteresEspeciales()
        {
            // Arrange
            var items = new List<ReporteAtrasoItem>
            {
                new ReporteAtrasoItem
                {
                    NombreEmpleado = "Lopez; Garcia, \"Pedro\"",
                    Correo = "pedro@empresa.cl",
                    Fecha = new DateTime(2026, 10, 18),
                    HoraEntrada = new TimeSpan(10, 0, 0)
                }
            };

            // Act
            var csv = _exportService.GenerarCsvAtrasos(items);

            // Assert
            Assert.Contains("\"Lopez; Garcia, \"\"Pedro\"\"\"", csv);
        }

        [Fact]
        public void GuardarArchivo_EscribeArchivoUtf8ConBom()
        {
            // Arrange
            string tempFile = Path.Combine(Path.GetTempPath(), $"test_export_{Guid.NewGuid()}.csv");
            string contenido = "Header1;Header2\nValor1;Valor2";

            try
            {
                // Act
                _exportService.GuardarArchivo(tempFile, contenido);

                // Assert
                Assert.True(File.Exists(tempFile));
                byte[] bytes = File.ReadAllBytes(tempFile);
                // Check UTF8 BOM: 0xEF, 0xBB, 0xBF
                Assert.True(bytes.Length >= 3);
                Assert.Equal(0xEF, bytes[0]);
                Assert.Equal(0xBB, bytes[1]);
                Assert.Equal(0xBF, bytes[2]);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }
    }
}
