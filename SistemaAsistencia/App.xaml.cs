using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using SistemaAsistencia.Data;

namespace SistemaAsistencia
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            DispatcherUnhandledException += App_DispatcherUnhandledException;

            try
            {
                base.OnStartup(e);
                DatabaseInitializer.Initialize();
            }
            catch (Exception ex)
            {
                LogAndShowError("Fatal error during startup initialization", ex);
            }
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            LogAndShowError("Unhandled UI Exception", e.Exception);
            e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                LogAndShowError("Unhandled Domain Exception", ex);
            }
        }

        public static void LogAndShowError(string title, Exception ex)
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash.log");
            string message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {title}:\n{ex}\n\n";
            
            try
            {
                File.AppendAllText(logPath, message);
            }
            catch { }

            MessageBox.Show($"{title}:\n{ex.Message}\n\nConsulte 'crash.log' para más detalles.", "Error de Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
