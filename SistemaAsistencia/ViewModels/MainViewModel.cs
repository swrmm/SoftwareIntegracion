using System;
using System.Windows.Input;
using SistemaAsistencia.Models;

namespace SistemaAsistencia.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Usuario _usuarioActual = null!;
        private BaseViewModel _vistaActual = null!;
        private string _menuActivo = string.Empty;

        public event Action? SesionCerrada;

        public Usuario UsuarioActual
        {
            get => _usuarioActual;
            set
            {
                SetProperty(ref _usuarioActual, value);
                OnPropertyChanged(nameof(EsAdmin));
                OnPropertyChanged(nameof(NombreUsuario));
                OnPropertyChanged(nameof(RolTexto));
            }
        }

        public BaseViewModel VistaActual
        {
            get => _vistaActual;
            set => SetProperty(ref _vistaActual, value);
        }

        public bool EsAdmin => UsuarioActual?.Rol == RolUsuario.Administrador;
        public string NombreUsuario => UsuarioActual?.Nombre ?? string.Empty;
        public string RolTexto => EsAdmin ? "Administrador" : "Empleado";
        public string RolUsuarioText => RolTexto;
        public string InicialUsuario => !string.IsNullOrEmpty(NombreUsuario) ? NombreUsuario.Substring(0, 1).ToUpper() : "U";

        public string MenuActivo
        {
            get => _menuActivo;
            set => SetProperty(ref _menuActivo, value);
        }

        public ICommand NavegarCommand { get; }
        public ICommand CerrarSesionCommand { get; }

        public MainViewModel(Usuario usuario)
        {
            UsuarioActual = usuario;
            
            NavegarCommand = new RelayCommand(Navegar);
            CerrarSesionCommand = new RelayCommand(_ => SesionCerrada?.Invoke());

            Navegar("asistencia");
        }

        private void Navegar(object? parametro)
        {
            if (parametro is string vista)
            {
                MenuActivo = vista;
                switch (vista.ToLower())
                {
                    case "asistencia":
                        VistaActual = new AsistenciaViewModel(UsuarioActual);
                        break;
                    case "atrasos":
                        VistaActual = new ReporteAtrasosViewModel();
                        break;
                    case "salidas":
                        VistaActual = new ReporteSalidasViewModel();
                        break;
                    case "inasistencias":
                        VistaActual = new ReporteInasistenciasViewModel();
                        break;
                    case "usuarios":
                        VistaActual = new GestionUsuariosViewModel();
                        break;
                }
            }
        }
    }
}
