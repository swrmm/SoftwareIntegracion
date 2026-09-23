using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaAsistencia.Data;
using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services
{
    public class ReporteAtrasoItem
    {
        public string NombreEmpleado { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public string HoraEntradaTexto => HoraEntrada.ToString(@"hh\:mm\:ss");
        public string FechaTexto => Fecha.ToString("dd/MM/yyyy");
    }

    public class ReporteSalidaItem
    {
        public string NombreEmpleado { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string HoraSalidaTexto => HoraSalida.ToString(@"hh\:mm\:ss");
        public string FechaTexto => Fecha.ToString("dd/MM/yyyy");
    }

    public class ReporteInasistenciaItem
    {
        public string NombreEmpleado { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string FechaTexto => Fecha.ToString("dd/MM/yyyy");
    }

    public class ReporteService
    {
        private static readonly TimeSpan HoraLimiteEntrada = new TimeSpan(9, 30, 0);
        private static readonly TimeSpan HoraLimiteSalida = new TimeSpan(17, 30, 0);

        public List<ReporteAtrasoItem> ObtenerAtrasos(DateTime fechaInicio, DateTime fechaFin)
        {
            using var context = new AppDbContext();
            return context.RegistrosAsistencia
                .Include(r => r.Usuario)
                .Where(r => r.Accion == TipoAccion.Entrada
                         && r.Fecha >= fechaInicio.Date
                         && r.Fecha <= fechaFin.Date
                         && r.Usuario!.Activo)
                .AsEnumerable()
                .Where(r => r.Hora > HoraLimiteEntrada)
                .OrderByDescending(r => r.Fecha)
                .ThenBy(r => r.Usuario!.Nombre)
                .Select(r => new ReporteAtrasoItem
                {
                    NombreEmpleado = r.Usuario!.Nombre,
                    Correo = r.Usuario.Correo,
                    Fecha = r.Fecha,
                    HoraEntrada = r.Hora
                })
                .ToList();
        }

        public List<ReporteSalidaItem> ObtenerSalidasAnticipadas(DateTime fechaInicio, DateTime fechaFin)
        {
            using var context = new AppDbContext();
            return context.RegistrosAsistencia
                .Include(r => r.Usuario)
                .Where(r => r.Accion == TipoAccion.Salida
                         && r.Fecha >= fechaInicio.Date
                         && r.Fecha <= fechaFin.Date
                         && r.Usuario!.Activo)
                .AsEnumerable()
                .Where(r => r.Hora < HoraLimiteSalida)
                .OrderByDescending(r => r.Fecha)
                .ThenBy(r => r.Usuario!.Nombre)
                .Select(r => new ReporteSalidaItem
                {
                    NombreEmpleado = r.Usuario!.Nombre,
                    Correo = r.Usuario.Correo,
                    Fecha = r.Fecha,
                    HoraSalida = r.Hora
                })
                .ToList();
        }

        public List<ReporteInasistenciaItem> ObtenerInasistencias(DateTime fechaInicio, DateTime fechaFin)
        {
            using var context = new AppDbContext();
            var usuarios = context.Usuarios.Where(u => u.Activo).ToList();
            var resultado = new List<ReporteInasistenciaItem>();

            for (var fecha = fechaInicio.Date; fecha <= fechaFin.Date; fecha = fecha.AddDays(1))
            {
                if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                if (fecha > DateTime.Today)
                    break;

                foreach (var usuario in usuarios)
                {
                    var tieneRegistro = context.RegistrosAsistencia
                        .Any(r => r.UsuarioId == usuario.Id && r.Fecha == fecha);

                    if (!tieneRegistro)
                    {
                        resultado.Add(new ReporteInasistenciaItem
                        {
                            NombreEmpleado = usuario.Nombre,
                            Correo = usuario.Correo,
                            Fecha = fecha
                        });
                    }
                }
            }

            return resultado.OrderByDescending(r => r.Fecha).ThenBy(r => r.NombreEmpleado).ToList();
        }
    }
}
