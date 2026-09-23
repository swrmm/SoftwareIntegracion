using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaAsistencia.Models
{
    /// <summary>
    /// Define los roles de acceso dentro del sistema de asistencia.
    /// </summary>
    public enum RolUsuario
    {
        /// <summary>Usuario estándar con permisos de marcaje de entrada/salida.</summary>
        Empleado,
        /// <summary>Usuario administrativo con acceso a gestión de usuarios y reportes.</summary>
        Administrador
    }

    /// <summary>
    /// Representa a un usuario dentro del sistema de asistencia.
    /// Contiene la información personal, credenciales y rol asignado.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario (Clave Primaria).
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        /// <summary>
        /// Correo electrónico institucional (Único en el sistema).
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Correo { get; set; } = string.Empty;
        
        /// <summary>
        /// Contraseña encriptada mediante algoritmo BCrypt.
        /// </summary>
        [Required]
        public string Contrasena { get; set; } = string.Empty;
        
        /// <summary>
        /// Rol asignado al usuario (Empleado o Administrador).
        /// </summary>
        public RolUsuario Rol { get; set; } = RolUsuario.Empleado;
        
        /// <summary>
        /// Fecha y hora en la que fue registrado el usuario en el sistema.
        /// </summary>
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Estado de la cuenta (True para activo, False si ha sido dado de baja).
        /// </summary>
        public bool Activo { get; set; } = true;
    }
}

