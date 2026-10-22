using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;

namespace SistemaAsistencia.ViewModels
{
    public class ReporteSalidasViewModel : BaseViewModel
    {
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private List<ReporteSalidaItem> _registros = new();
        private string _mensajeExportacion = string.Empty;
        private readonly ReporteService _reporteService;
        private readonly ExportService _exportService;

        public DateTime FechaInicio
        {
            get => _fechaInicio;
            set => SetProperty(ref _fechaInicio, value);
        }

        public DateTime FechaFin
        {
            get => _fechaFin;
            set => SetProperty(ref _fechaFin, value);
        }

        public List<ReporteSalidaItem> Registros
        {
            get => _registros;
            set
            {
                SetProperty(ref _registros, value);
                OnPropertyChanged(nameof(TotalRegistros));
                OnPropertyChanged(nameof(SinResultados));
            }
        }

        public int TotalRegistros => Registros?.Count ?? 0;
        public bool SinResultados => Registros != null && Registros.Count == 0;

        public string MensajeExportacion
        {
            get => _mensajeExportacion;
            set => SetProperty(ref _mensajeExportacion, value);
        }

        public Func<string, string?>? SeleccionarRutaGuardado { get; set; }

        public ICommand GenerarReporteCommand { get; }
        public ICommand ExportarCommand { get; }

        public ReporteSalidasViewModel()
        {
            _reporteService = new ReporteService();
            _exportService = new ExportService();
            
            var hoy = DateTime.Today;
            FechaInicio = new DateTime(hoy.Year, hoy.Month, 1);
            FechaFin = hoy;

            GenerarReporteCommand = new RelayCommand(_ => GenerarReporte());
            ExportarCommand = new RelayCommand(_ => Exportar());
            
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            Registros = _reporteService.ObtenerSalidasAnticipadas(FechaInicio, FechaFin);
            MensajeExportacion = string.Empty;
        }

        public void Exportar()
        {
            if (Registros == null || Registros.Count == 0)
            {
                MensajeExportacion = "No hay registros disponibles para exportar.";
                return;
            }

            string nombreSugerido = $"Reporte_SalidasAnticipadas_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            string? ruta = SeleccionarRutaGuardado != null
                ? SeleccionarRutaGuardado(nombreSugerido)
                : ObtenerRutaDialogo(nombreSugerido);

            if (!string.IsNullOrEmpty(ruta))
            {
                try
                {
                    var csv = _exportService.GenerarCsvSalidas(Registros);
                    _exportService.GuardarArchivo(ruta, csv);
                    MensajeExportacion = $"Reporte exportado exitosamente: {Path.GetFileName(ruta)}";
                }
                catch (Exception ex)
                {
                    MensajeExportacion = $"Error al exportar: {ex.Message}";
                }
            }
        }

        private string? ObtenerRutaDialogo(string defaultFileName)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*",
                FileName = defaultFileName
            };
            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }
    }
}
