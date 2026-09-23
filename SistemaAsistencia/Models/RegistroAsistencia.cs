using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAsistencia.Models
{
    /// <summary>
    /// Tipo de marcaje registrado en el sistema.
    /// </summary>
    public enum TipoAccion
    {
        /// <summary>Marcaje de inicio de jornada laboral.</summary>
        Entrada,
        /// <summary>Marcaje de fin de jornada laboral.</summary>
        Salida
    }

    /// <summary>
    /// Representa un evento de marcaje de asistencia de un usuario en una fecha y hora determinada.
    /// </summary>
    public class RegistroAsistencia
    {
        /// <summary>
        /// Identificador único del registro de asistencia.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// ID del usuario al que pertenece el registro (Clave Foránea).
        /// </summary>
        [Required]
        public int UsuarioId { get; set; }
        
        /// <summary>
        /// Objeto de navegación hacia la entidad Usuario.
        /// </summary>
        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
        
        /// <summary>
        /// Tipo de marcaje (Entrada o Salida).
        /// </summary>
        [Required]
        public TipoAccion Accion { get; set; }
        
        /// <summary>
        /// Fecha del marcaje (formato YYYY-MM-DD).
        /// </summary>
        [Required]
        public DateTime Fecha { get; set; }
        
        /// <summary>
        /// Hora exacta en que se realizó el marcaje.
        /// </summary>
        [Required]
        public TimeSpan Hora { get; set; }
    }
}

