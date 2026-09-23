using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaAsistencia.Data;
using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services
{
    /// <summary>
    /// Servicio encargado del registro y consulta de eventos de asistencia (Entradas y Salidas).
    /// </summary>
    public class AsistenciaService
    {
        /// <summary>
        /// Registra la hora de entrada del usuario para el día actual.
        /// </summary>
        /// <param name="usuarioId">ID del usuario que realiza el marcaje.</param>
        /// <returns><c>true</c> si el registro fue exitoso; <c>false</c> si ya tenía un marcaje de entrada hoy.</returns>
        public bool RegistrarEntrada(int usuarioId)
        {
            using var context = new AppDbContext();
            var hoy = DateTime.Today;
            var yaRegistro = context.RegistrosAsistencia
                .Any(r => r.UsuarioId == usuarioId && r.Fecha == hoy && r.Accion == TipoAccion.Entrada);

            if (yaRegistro) return false;

            var registro = new RegistroAsistencia
            {
                UsuarioId = usuarioId,
                Accion = TipoAccion.Entrada,
                Fecha = hoy,
                Hora = DateTime.Now.TimeOfDay
            };

            context.RegistrosAsistencia.Add(registro);
            context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Registra la hora de salida del usuario para el día actual.
        /// </summary>
        /// <param name="usuarioId">ID del usuario que realiza el marcaje.</param>
        /// <returns><c>true</c> si el registro fue exitoso; <c>false</c> si ya tenía un marcaje de salida hoy.</returns>
        public bool RegistrarSalida(int usuarioId)
        {
            using var context = new AppDbContext();
            var hoy = DateTime.Today;
            var yaRegistro = context.RegistrosAsistencia
                .Any(r => r.UsuarioId == usuarioId && r.Fecha == hoy && r.Accion == TipoAccion.Salida);

            if (yaRegistro) return false;

            var registro = new RegistroAsistencia
            {
                UsuarioId = usuarioId,
                Accion = TipoAccion.Salida,
                Fecha = hoy,
                Hora = DateTime.Now.TimeOfDay
            };

            context.RegistrosAsistencia.Add(registro);
            context.SaveChanges();
            return true;
        }

        /// <summary>Alias para <see cref="VerificarEntradaHoy"/>.</summary>
        public bool TieneEntradaHoy(int usuarioId) => VerificarEntradaHoy(usuarioId);
        /// <summary>Alias para <see cref="VerificarSalidaHoy"/>.</summary>
        public bool TieneSalidaHoy(int usuarioId) => VerificarSalidaHoy(usuarioId);

        /// <summary>
        /// Verifica si el usuario especificado ya registró entrada el día de hoy.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns><c>true</c> si ya registró entrada hoy; de lo contrario, <c>false</c>.</returns>
        public bool VerificarEntradaHoy(int usuarioId)
        {
            using var context = new AppDbContext();
            return context.RegistrosAsistencia
                .Any(r => r.UsuarioId == usuarioId && r.Fecha == DateTime.Today && r.Accion == TipoAccion.Entrada);
        }

        /// <summary>
        /// Verifica si el usuario especificado ya registró salida el día de hoy.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns><c>true</c> si ya registró salida hoy; de lo contrario, <c>false</c>.</returns>
        public bool VerificarSalidaHoy(int usuarioId)
        {
            using var context = new AppDbContext();
            return context.RegistrosAsistencia
                .Any(r => r.UsuarioId == usuarioId && r.Fecha == DateTime.Today && r.Accion == TipoAccion.Salida);
        }

        /// <summary>
        /// Obtiene todos los marcajes de asistencia del usuario realizados en la fecha actual.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns>Lista de registros de asistencia del día ordenados por hora.</returns>
        public List<RegistroAsistencia> ObtenerRegistrosHoy(int usuarioId)
        {
            using var context = new AppDbContext();
            return context.RegistrosAsistencia
                .Where(r => r.UsuarioId == usuarioId && r.Fecha == DateTime.Today)
                .OrderBy(r => r.Hora)
                .ToList();
        }
    }
}

