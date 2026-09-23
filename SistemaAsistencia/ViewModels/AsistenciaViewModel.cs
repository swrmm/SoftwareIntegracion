using System;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Threading;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;

namespace SistemaAsistencia.ViewModels
{
    public class AsistenciaViewModel : BaseViewModel
    {
        private string _horaActual = string.Empty;
        private string _fechaActual = string.Empty;
        private bool _tieneEntradaHoy;
        private bool _tieneSalidaHoy;
        private string _mensajeEstado = string.Empty;
        private string _estadoHoy = string.Empty;
        
        private readonly Usuario _usuarioActual;
        private readonly AsistenciaService _asistenciaService;
        private readonly DispatcherTimer _timer;

        public Usuario UsuarioActual => _usuarioActual;

        public string HoraActual
        {
            get => _horaActual;
            set => SetProperty(ref _horaActual, value);
        }

        public string FechaActual
        {
            get => _fechaActual;
            set => SetProperty(ref _fechaActual, value);
        }

        public bool TieneEntradaHoy
        {
            get => _tieneEntradaHoy;
            set
            {
                SetProperty(ref _tieneEntradaHoy, value);
                OnPropertyChanged(nameof(PuedeMarcarEntrada));
                OnPropertyChanged(nameof(PuedeMarcarSalida));
            }
        }

        public bool TieneSalidaHoy
        {
            get => _tieneSalidaHoy;
            set
            {
                SetProperty(ref _tieneSalidaHoy, value);
                OnPropertyChanged(nameof(PuedeMarcarSalida));
            }
        }

        public bool PuedeMarcarEntrada => !TieneEntradaHoy;
        public bool PuedeMarcarSalida => TieneEntradaHoy && !TieneSalidaHoy;

        public string MensajeEstado
        {
            get => _mensajeEstado;
            set => SetProperty(ref _mensajeEstado, value);
        }

        public string EstadoHoy
        {
            get => _estadoHoy;
            set => SetProperty(ref _estadoHoy, value);
        }

        public ICommand MarcarEntradaCommand { get; }
        public ICommand MarcarSalidaCommand { get; }

        public AsistenciaViewModel(Usuario usuario)
        {
            _usuarioActual = usuario;
            _asistenciaService = new AsistenciaService();
            
            MarcarEntradaCommand = new RelayCommand(MarcarEntrada, _ => PuedeMarcarEntrada);
            MarcarSalidaCommand = new RelayCommand(MarcarSalida, _ => PuedeMarcarSalida);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (s, e) => ActualizarReloj();
            _timer.Start();
            
            ActualizarReloj();
            CargarEstadoAsistencia();
        }

        private void ActualizarReloj()
        {
            var ahora = DateTime.Now;
            HoraActual = ahora.ToString("HH:mm:ss");
            
            var fechaStr = ahora.ToString("dddd, dd 'de' MMMM yyyy", new CultureInfo("es-ES"));
            if (fechaStr.Length > 0)
            {
                fechaStr = char.ToUpper(fechaStr[0]) + fechaStr.Substring(1);
            }
            FechaActual = fechaStr;
        }

        private void CargarEstadoAsistencia()
        {
            TieneEntradaHoy = _asistenciaService.VerificarEntradaHoy(_usuarioActual.Id);
            TieneSalidaHoy = _asistenciaService.VerificarSalidaHoy(_usuarioActual.Id);
            
            if (TieneEntradaHoy && TieneSalidaHoy)
                EstadoHoy = "Jornada completa";
            else if (TieneEntradaHoy)
                EstadoHoy = "Entrada registrada";
            else
                EstadoHoy = "Sin registros hoy";
        }

        private void MarcarEntrada(object? parameter)
        {
            var exito = _asistenciaService.RegistrarEntrada(_usuarioActual.Id);
            if (exito)
            {
                MensajeEstado = $"Entrada registrada a las {DateTime.Now:HH:mm}";
                CargarEstadoAsistencia();
            }
        }

        private void MarcarSalida(object? parameter)
        {
            var exito = _asistenciaService.RegistrarSalida(_usuarioActual.Id);
            if (exito)
            {
                MensajeEstado = $"Salida registrada a las {DateTime.Now:HH:mm}";
                CargarEstadoAsistencia();
            }
        }
    }
}
