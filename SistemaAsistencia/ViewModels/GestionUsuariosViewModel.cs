using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;

namespace SistemaAsistencia.ViewModels
{
    public class GestionUsuariosViewModel : BaseViewModel
    {
        private List<Usuario> _usuarios = new();
        private Usuario? _usuarioSeleccionado;
        private string _nombre = string.Empty;
        private string _correo = string.Empty;
        private RolUsuario _rolSeleccionado = RolUsuario.Empleado;
        private bool _modoEdicion;
        private bool _mostrarFormulario;
        private string _mensajeEstado = string.Empty;
        private string _formError = string.Empty;
        
        private readonly UsuarioService _usuarioService;

        public List<Usuario> Usuarios
        {
            get => _usuarios;
            set => SetProperty(ref _usuarios, value);
        }

        public Usuario? UsuarioSeleccionado
        {
            get => _usuarioSeleccionado;
            set
            {
                if (SetProperty(ref _usuarioSeleccionado, value) && value != null)
                {
                    Nombre = value.Nombre;
                    Correo = value.Correo;
                    RolSeleccionado = value.Rol;
                }
            }
        }

        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string Correo
        {
            get => _correo;
            set => SetProperty(ref _correo, value);
        }

        public RolUsuario RolSeleccionado
        {
            get => _rolSeleccionado;
            set
            {
                if (SetProperty(ref _rolSeleccionado, value))
                {
                    OnPropertyChanged(nameof(FormRolIndex));
                }
            }
        }

        public int FormRolIndex
        {
            get => RolSeleccionado == RolUsuario.Administrador ? 1 : 0;
            set => RolSeleccionado = value == 1 ? RolUsuario.Administrador : RolUsuario.Empleado;
        }

        public bool ModoEdicion
        {
            get => _modoEdicion;
            set => SetProperty(ref _modoEdicion, value);
        }

        public bool MostrarFormulario
        {
            get => _mostrarFormulario;
            set => SetProperty(ref _mostrarFormulario, value);
        }

        public string MensajeEstado
        {
            get => _mensajeEstado;
            set
            {
                SetProperty(ref _mensajeEstado, value);
                OnPropertyChanged(nameof(TieneMensaje));
            }
        }

        public string FormError
        {
            get => _formError;
            set => SetProperty(ref _formError, value);
        }

        public bool TieneMensaje => !string.IsNullOrEmpty(MensajeEstado);

        public ICommand NuevoUsuarioCommand { get; }
        public ICommand EditarUsuarioCommand { get; }
        public ICommand GuardarCommand { get; }
        public ICommand EliminarCommand { get; }
        public ICommand CancelarCommand { get; }
        public ICommand CargarUsuariosCommand { get; }

        public GestionUsuariosViewModel()
        {
            _usuarioService = new UsuarioService();
            
            NuevoUsuarioCommand = new RelayCommand(_ => NuevoUsuario());
            EditarUsuarioCommand = new RelayCommand(p => EditarUsuario(p as Usuario));
            GuardarCommand = new RelayCommand(p => Guardar(p));
            EliminarCommand = new RelayCommand(p => Eliminar(p as Usuario));
            CancelarCommand = new RelayCommand(_ => { MostrarFormulario = false; FormError = string.Empty; });
            CargarUsuariosCommand = new RelayCommand(_ => CargarUsuarios());

            CargarUsuarios();
        }

        public void CargarUsuarios()
        {
            Usuarios = _usuarioService.ObtenerUsuarios();
        }

        private void NuevoUsuario()
        {
            UsuarioSeleccionado = null;
            Nombre = string.Empty;
            Correo = string.Empty;
            RolSeleccionado = RolUsuario.Empleado;
            ModoEdicion = false;
            MostrarFormulario = true;
            MensajeEstado = string.Empty;
            FormError = string.Empty;
        }

        private void EditarUsuario(Usuario? usuario)
        {
            var target = usuario ?? UsuarioSeleccionado;
            if (target != null)
            {
                UsuarioSeleccionado = target;
                Nombre = target.Nombre;
                Correo = target.Correo;
                RolSeleccionado = target.Rol;
                ModoEdicion = true;
                MostrarFormulario = true;
                MensajeEstado = string.Empty;
                FormError = string.Empty;
            }
        }

        private void Guardar(object? parameter)
        {
            string contrasena = string.Empty;
            if (parameter is PasswordBox passBox)
            {
                contrasena = passBox.Password;
            }

            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Correo) || (!ModoEdicion && string.IsNullOrWhiteSpace(contrasena)))
            {
                FormError = "Todos los campos son obligatorios";
                return;
            }

            if (!ModoEdicion && _usuarioService.ExisteCorreo(Correo))
            {
                FormError = "Ya existe un usuario registrado con este correo";
                return;
            }

            FormError = string.Empty;

            if (ModoEdicion && UsuarioSeleccionado != null)
            {
                var exito = _usuarioService.Modificar(UsuarioSeleccionado.Id, Nombre, Correo, string.IsNullOrWhiteSpace(contrasena) ? null : contrasena, RolSeleccionado);
                if (exito)
                {
                    MensajeEstado = $"Usuario '{Nombre}' modificado exitosamente";
                }
                else
                {
                    FormError = "Error al modificar el usuario";
                    return;
                }
            }
            else
            {
                var exito = _usuarioService.Crear(Nombre, Correo, contrasena, RolSeleccionado);
                if (exito)
                {
                    MensajeEstado = $"Usuario '{Nombre}' creado exitosamente";
                }
                else
                {
                    FormError = "Error al crear el usuario";
                    return;
                }
            }

            MostrarFormulario = false;
            CargarUsuarios();
        }

        private void Eliminar(Usuario? usuario)
        {
            var target = usuario ?? UsuarioSeleccionado;
            if (target != null)
            {
                var exito = _usuarioService.Eliminar(target.Id);
                if (exito)
                {
                    MensajeEstado = $"Usuario '{target.Nombre}' eliminado exitosamente";
                    MostrarFormulario = false;
                    CargarUsuarios();
                }
            }
        }
    }
}
