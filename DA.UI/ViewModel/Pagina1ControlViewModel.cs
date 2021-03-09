using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DA.BE;
using DA.UI.DataGrid;
using DA.UI.Principales.Designacion;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    public class Pagina1ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {
        private bool _habilitado;

        public bool Habilitado
        {
            get => _habilitado;
            set => SetProperty(ref _habilitado, value);
        }

        private List<BE.Categoria> _categorias;

        public List<BE.Categoria> Categorias
        {
            get => _categorias;
            set => SetProperty(ref _categorias, value);
        }

        private List<BE.Campeonato> _campeonatos;

        public List<BE.Campeonato> Campeonatos
        {
            get => _campeonatos;
            set => SetProperty(ref _campeonatos, value);
        }

        private List<BE.Deporte> _deportes;

        public List<BE.Deporte> Deportes
        {
            get => _deportes;
            set => SetProperty(ref _deportes, value);
        }

        private BE.Deporte _deporteSeleccionado;

        public BE.Deporte DeporteSeleccionado
        {
            get => _deporteSeleccionado;
            set => SetProperty(ref _deporteSeleccionado, value);
        }

        private List<BE.Fecha> _fechasDisponibles;

        public List<BE.Fecha> FechasDisponibles
        {
            get => _fechasDisponibles;
            set => SetProperty(ref _fechasDisponibles, value);
        }

        private bool _busyFechas;

        public bool BusyFechas
        {
            get => _busyFechas;
            set => SetProperty(ref _busyFechas, value);
        }


        private Visibility _visibilidad;

        public Visibility Visibilidad
        {
            get => _visibilidad;
            set => SetProperty(ref _visibilidad, value);
        }

        public Pagina1ControlViewModel()
        {
            CargarComboDeportes();
            Visibilidad = Visibility.Collapsed;
            Habilitado = false;

            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);


        }

        private void CargarComboDeportes()
        {
            BLL.Deporte bllDeporte = new BLL.Deporte();

            Deportes = bllDeporte.ObtenerDeportes();
        }

   

        #region Propiedades




        #endregion

        #region Commands


        public ICommand SelectedItemChangedCommand { get; private set; }

       
        #endregion
        
        private void  ExecuteSelectedItemChangedCommand(object obj)
        {
            var task = new Task(CargarInformacion);
            task.Start();
         

        }

        private void CargarInformacion()
        {
            if (DeporteSeleccionado != null)
            {

                Visibilidad = Visibility.Visible;

                BLL.Categoria bllCategoria = new BLL.Categoria();
                BLL.Campeonato bllCampeonato = new BLL.Campeonato();
               

                Categorias = bllCategoria.ObtenerCategoriasPorIdDeporte(DeporteSeleccionado.Id);
                Campeonatos = bllCampeonato.ObtenerCampeonatosReducidoPorIdDeporte(DeporteSeleccionado.Id);
                CargarFechas();
                
              

                Visibilidad = Visibility.Collapsed;
            }
        }

        private void CargarFechas()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (o, ea) =>
            {
                BLL.Fecha bllFecha = new BLL.Fecha();
                FechasDisponibles = bllFecha.ObtenerFechasNoDesignadas(DeporteSeleccionado.Id);

            };
            worker.RunWorkerCompleted += (o, ea) =>
            {

                BusyFechas = false;
                Habilitado = true;
            };
       
            BusyFechas = true;
            worker.RunWorkerAsync();
      
        }


        private void Limpiar()
        {
            if (Deportes != null)
                Deportes.Clear();

            DeporteSeleccionado = null;
            CargarComboDeportes();
            
            if (Categorias != null)
                Categorias.Clear();
            
            if (Campeonatos != null)
                Campeonatos.Clear();

            if (FechasDisponibles != null)
                FechasDisponibles.Clear();

            Habilitado = false;
        }

   
        public void Hidden(ITransitionerViewModel newViewModel)
        {
            //if (newViewModel is Pagina2ControlViewModel)
            //{
            //    if(((Pagina2ControlViewModel)newViewModel).Arbitros != null)
            //        ((Pagina2ControlViewModel)newViewModel).Arbitros.Clear();

            //    if(((Pagina2ControlViewModel)newViewModel).Partidos != null)
            //        ((Pagina2ControlViewModel)newViewModel).Partidos.Clear();


            //}
        }

        public void Shown(ITransitionerViewModel previousViewModel)
        {
            if (previousViewModel is Pagina4ControlViewModel)
                Limpiar();
        }
    }
}
