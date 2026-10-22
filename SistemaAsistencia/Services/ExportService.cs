using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SistemaAsistencia.Services
{
    /// <summary>
    /// Servicio para la exportación de reportes a formatos de ofimática (CSV / Excel).
    /// </summary>
    public class ExportService
    {
        private static string EscaparCampo(string? texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            if (texto.Contains(';') || texto.Contains('"') || texto.Contains('\n') || texto.Contains('\r'))
            {
                return $"\"{texto.Replace("\"", "\"\"")}\"";
            }
            return texto;
        }

        /// <summary>
        /// Genera el contenido CSV delimitado por punto y coma para el reporte de atrasos.
        /// </summary>
        public string GenerarCsvAtrasos(IEnumerable<ReporteAtrasoItem> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Empleado;Correo;Fecha;Hora de Entrada");

            foreach (var item in items)
            {
                sb.AppendLine($"{EscaparCampo(item.NombreEmpleado)};{EscaparCampo(item.Correo)};{item.FechaTexto};{item.HoraEntradaTexto}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Genera el contenido CSV delimitado por punto y coma para el reporte de salidas anticipadas.
        /// </summary>
        public string GenerarCsvSalidas(IEnumerable<ReporteSalidaItem> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Empleado;Correo;Fecha;Hora de Salida");

            foreach (var item in items)
            {
                sb.AppendLine($"{EscaparCampo(item.NombreEmpleado)};{EscaparCampo(item.Correo)};{item.FechaTexto};{item.HoraSalidaTexto}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Genera el contenido CSV delimitado por punto y coma para el reporte de inasistencias.
        /// </summary>
        public string GenerarCsvInasistencias(IEnumerable<ReporteInasistenciaItem> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Empleado;Correo;Fecha");

            foreach (var item in items)
            {
                sb.AppendLine($"{EscaparCampo(item.NombreEmpleado)};{EscaparCampo(item.Correo)};{item.FechaTexto}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda el contenido en un archivo de texto con codificación UTF-8 con BOM para máxima compatibilidad con Microsoft Excel.
        /// </summary>
        public void GuardarArchivo(string rutaArchivo, string contenido)
        {
            File.WriteAllText(rutaArchivo, contenido, new UTF8Encoding(true));
        }
    }
}
