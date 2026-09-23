using System.Windows;
using System.Windows.Input;
using SistemaAsistencia.ViewModels;

namespace SistemaAsistencia.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var viewModel = new LoginViewModel();
            viewModel.LoginExitoso += ViewModel_LoginExitoso;
            this.DataContext = viewModel;
        }

        private void ViewModel_LoginExitoso(Models.Usuario usuario)
        {
            var mainWindow = new MainWindow(usuario);
            mainWindow.Show();
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Normal)
                    this.WindowState = WindowState.Maximized;
                else
                    this.WindowState = WindowState.Normal;
            }
            else
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CorreoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (DataContext is LoginViewModel vm && vm.LoginCommand.CanExecute(txtPassword))
                {
                    vm.LoginCommand.Execute(txtPassword);
                }
            }
        }
    }
}
