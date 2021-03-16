namespace DA.UI.ViewModel
{
    using DA.UI.DataGrid;
    using DA.UI.Principales.Designacion;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Defines the <see cref="Pagina1ControlViewModel" />.
    /// </summary>
    public class Pagina1ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the _busyFechas.
        /// </summary>
        private bool _busyFechas;

        /// <summary>
        /// Defines the _campeonatos.
        /// </summary>
        private List<BE.Campeonato> _campeonatos;

        /// <summary>
        /// Defines the _categorias.
        /// </summary>
        private List<BE.Categoria> _categorias;

        /// <summary>
        /// Defines the _deportes.
        /// </summary>
        private List<BE.Deporte> _deportes;

        /// <summary>
        /// Defines the _deporteSeleccionado.
        /// </summary>
        private BE.Deporte _deporteSeleccionado;

        /// <summary>
        /// Defines the _fechasDisponibles.
        /// </summary>
        private List<BE.Fecha> _fechasDisponibles;

        /// <summary>
        /// Defines the _habilitado.
        /// </summary>
        private bool _habilitado;

        /// <summary>
        /// Defines the _visibilidad.
        /// </summary>
        private Visibility _visibilidad;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagina1ControlViewModel"/> class.
        /// </summary>
        public Pagina1ControlViewModel()
        {
            CargarComboDeportes();
            Visibilidad = Visibility.Collapsed;
            Habilitado = false;

            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether BusyFechas.
        /// </summary>
        public bool BusyFechas { get => _busyFechas; set => SetProperty(ref _busyFechas, value); }

        /// <summary>
        /// Gets or sets the Campeonatos.
        /// </summary>
        public List<BE.Campeonato> Campeonatos { get => _campeonatos; set => SetProperty(ref _campeonatos, value); }

        /// <summary>
        /// Gets or sets the Categorias.
        /// </summary>
        public List<BE.Categoria> Categorias { get => _categorias; set => SetProperty(ref _categorias, value); }

        /// <summary>
        /// Gets or sets the Deportes.
        /// </summary>
        public List<BE.Deporte> Deportes { get => _deportes; set => SetProperty(ref _deportes, value); }

        /// <summary>
        /// Gets or sets the DeporteSeleccionado.
        /// </summary>
        public BE.Deporte DeporteSeleccionado { get => _deporteSeleccionado; set => SetProperty(ref _deporteSeleccionado, value); }

        /// <summary>
        /// Gets or sets the FechasDisponibles.
        /// </summary>
        public List<BE.Fecha> FechasDisponibles { get => _fechasDisponibles; set => SetProperty(ref _fechasDisponibles, value); }

        /// <summary>
        /// Gets or sets a value indicating whether Habilitado.
        /// </summary>
        public bool Habilitado { get => _habilitado; set => SetProperty(ref _habilitado, value); }

        /// <summary>
        /// Gets the SelectedItemChangedCommand.
        /// </summary>
        public ICommand SelectedItemChangedCommand { get; private set; }

        /// <summary>
        /// Gets or sets the Visibilidad.
        /// </summary>
        public Visibility Visibilidad { get => _visibilidad; set => SetProperty(ref _visibilidad, value); }

        #endregion

        #region Methods

        /// <summary>
        /// The Hidden.
        /// </summary>
        /// <param name="newViewModel">The newViewModel<see cref="ITransitionerViewModel"/>.</param>
        public void Hidden(ITransitionerViewModel newViewModel)
        {
        }

        /// <summary>
        /// The Shown.
        /// </summary>
        /// <param name="previousViewModel">The previousViewModel<see cref="ITransitionerViewModel"/>.</param>
        public void Shown(ITransitionerViewModel previousViewModel)
        {
            if (previousViewModel is Pagina4ControlViewModel)
                Limpiar();
        }

        /// <summary>
        /// The CargarComboDeportes.
        /// </summary>
        private void CargarComboDeportes()
        {
            BLL.Deporte bllDeporte = new BLL.Deporte();

            Deportes = bllDeporte.ObtenerDeportes();
        }

        /// <summary>
        /// The CargarFechas.
        /// </summary>
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

        /// <summary>
        /// The CargarInformacion.
        /// </summary>
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

        /// <summary>
        /// The ExecuteSelectedItemChangedCommand.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            var task = new Task(CargarInformacion);
            task.Start();
        }

        /// <summary>
        /// The Limpiar.
        /// </summary>
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

        #endregion
    }
}
