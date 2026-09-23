using System;
using System.Windows.Controls;
using System.Windows.Input;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;

namespace SistemaAsistencia.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _correo = string.Empty;
        private string _mensajeError = string.Empty;
        private bool _isLoading;
        private readonly AuthService _authService;

        public event Action<Usuario>? LoginExitoso;

        public string Correo
        {
            get => _correo;
            set => SetProperty(ref _correo, value);
        }

        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _authService = new AuthService();
            LoginCommand = new RelayCommand(EjecutarLogin);
        }

        private void EjecutarLogin(object? parameter)
        {
            if (parameter is PasswordBox passwordBox)
            {
                string contrasena = passwordBox.Password;

                if (string.IsNullOrWhiteSpace(Correo) || string.IsNullOrWhiteSpace(contrasena))
                {
                    MensajeError = "Ingrese su correo y contraseña";
                    return;
                }

                MensajeError = string.Empty;
                IsLoading = true;

                try
                {
                    bool exito = _authService.Login(Correo, contrasena);
                    if (exito && _authService.UsuarioActual != null)
                    {
                        LoginExitoso?.Invoke(_authService.UsuarioActual);
                    }
                    else
                    {
                        MensajeError = "Correo o contraseña incorrectos";
                    }
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }
    }
}
