using System;
using System.Collections.Generic;
using System.Windows.Input;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;

namespace SistemaAsistencia.ViewModels
{
    public class ReporteAtrasosViewModel : BaseViewModel
    {
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private List<ReporteAtrasoItem> _registros = new();
        private readonly ReporteService _reporteService;

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

        public List<ReporteAtrasoItem> Registros
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

        public ICommand GenerarReporteCommand { get; }

        public ReporteAtrasosViewModel()
        {
            _reporteService = new ReporteService();
            
            var hoy = DateTime.Today;
            FechaInicio = new DateTime(hoy.Year, hoy.Month, 1);
            FechaFin = hoy;

            GenerarReporteCommand = new RelayCommand(_ => GenerarReporte());
            
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            Registros = _reporteService.ObtenerAtrasos(FechaInicio, FechaFin);
        }
    }
}
