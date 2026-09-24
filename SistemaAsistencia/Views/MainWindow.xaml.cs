using System.Windows;
using System.Windows.Input;
using SistemaAsistencia.Models;
using SistemaAsistencia.ViewModels;

namespace SistemaAsistencia.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(Usuario usuario)
        {
            InitializeComponent();
            var viewModel = new MainViewModel(usuario);
            viewModel.SesionCerrada += ViewModel_SesionCerrada;
            this.DataContext = viewModel;
        }

        private void ViewModel_SesionCerrada()
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
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

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_StateChanged(object sender, System.EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                MainWindowBorder.CornerRadius = new CornerRadius(0);
                MainWindowBorder.BorderThickness = new Thickness(0);
            }
            else
            {
                MainWindowBorder.CornerRadius = new CornerRadius(12);
                MainWindowBorder.BorderThickness = new Thickness(1);
            }
        }
    }
}
