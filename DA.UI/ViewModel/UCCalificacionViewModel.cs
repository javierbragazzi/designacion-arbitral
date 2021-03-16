namespace DA.UI.ViewModel
{
    using DA.BLL;
    using DA.SS;
    using DA.UI.ABM;
    using DA.UI.DataGrid;
    using MaterialDesignThemes.Wpf;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Defines the <see cref="UCCalificacionViewModel" />.
    /// </summary>
    public class UCCalificacionViewModel : ViewModelBaseLocal
    {
        #region Fields

        /// <summary>
        /// Defines the _filtros.
        /// </summary>
        private List<SS.Filtro> _filtros;

        /// <summary>
        /// Defines the _filtroSeleccionado.
        /// </summary>
        private SS.Filtro _filtroSeleccionado;

        /// <summary>
        /// Defines the _habilitado.
        /// </summary>
        private bool _habilitado;

        /// <summary>
        /// Defines the _partidos.
        /// </summary>
        private SortablePageableCollection<PartidoHelperUI> _partidos;

        /// <summary>
        /// Defines the _partidoSeleccionado.
        /// </summary>
        private PartidoHelperUI _partidoSeleccionado;

        /// <summary>
        /// Defines the _visibilidad.
        /// </summary>
        private Visibility _visibilidad;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UCCalificacionViewModel"/> class.
        /// </summary>
        public UCCalificacionViewModel()
        {
            CargarComboFiltros();
            Visibilidad = Visibility.Collapsed;

            GoToNextPageCommand = new RelayCommand(a => Partidos.GoToNextPage());
            GoToPreviousPageCommand = new RelayCommand(a => Partidos.GoToPreviousPage());
            CleanCommand = new RelayCommand(ExecuteCleanCommand);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
            SelectedPartidoChangedCommand = new RelayCommand(ExecuteSelectedPartidoChangedCommand);
            RunCargarCalificacion = new RelayCommand(ExecuteRunCargarCalificacion);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the CleanCommand.
        /// </summary>
        public ICommand CleanCommand { get; private set; }

        /// <summary>
        /// Gets the EntriesPerPageList.
        /// </summary>
        public List<int> EntriesPerPageList
        {
            get
            {
                return new List<int>() { 5, 10, 15 };
            }
        }

        /// <summary>
        /// Gets or sets the Filtros.
        /// </summary>
        public List<SS.Filtro> Filtros { get => _filtros; set => SetProperty(ref _filtros, value); }

        /// <summary>
        /// Gets or sets the FiltroSeleccionado.
        /// </summary>
        public SS.Filtro FiltroSeleccionado { get => _filtroSeleccionado; set => SetProperty(ref _filtroSeleccionado, value); }

        /// <summary>
        /// Gets the GoToNextPageCommand.
        /// </summary>
        public ICommand GoToNextPageCommand { get; private set; }

        /// <summary>
        /// Gets the GoToPreviousPageCommand.
        /// </summary>
        public ICommand GoToPreviousPageCommand { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether Habilitado.
        /// </summary>
        public bool Habilitado { get => _habilitado; set => SetProperty(ref _habilitado, value); }

        /// <summary>
        /// Gets or sets the Partidos.
        /// </summary>
        public SortablePageableCollection<PartidoHelperUI> Partidos
        {
            get
            {
                return _partidos;
            }
            set
            {
                if (_partidos != value)
                {
                    _partidos = value;
                    SendPropertyChanged(() => Partidos);
                }
            }
        }

        /// <summary>
        /// Gets or sets the PartidoSeleccionado.
        /// </summary>
        public PartidoHelperUI PartidoSeleccionado { get => _partidoSeleccionado; set => SetProperty(ref _partidoSeleccionado, value); }

        /// <summary>
        /// Gets the RunCargarCalificacion.
        /// </summary>
        public ICommand RunCargarCalificacion { get; private set; }

        /// <summary>
        /// Gets the SelectedItemChangedCommand.
        /// </summary>
        public ICommand SelectedItemChangedCommand { get; private set; }

        /// <summary>
        /// Gets the SelectedPartidoChangedCommand.
        /// </summary>
        public ICommand SelectedPartidoChangedCommand { get; private set; }

        /// <summary>
        /// Gets or sets the Visibilidad.
        /// </summary>
        public Visibility Visibilidad { get => _visibilidad; set => SetProperty(ref _visibilidad, value); }

        #endregion

        #region Methods

        /// <summary>
        /// The ExecuteCleanCommand.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        public void ExecuteCleanCommand(object obj)
        {
            Limpiar();
        }

        /// <summary>
        /// The CargarComboFiltros.
        /// </summary>
        private void CargarComboFiltros()
        {
            Filtros = new List<Filtro>();
            Filtros.Add(new Filtro() { Id = 1, Descripcion = "Sin calificación" });
            Filtros.Add(new Filtro() { Id = 2, Descripcion = "Con calificación" });
        }

        /// <summary>
        /// The CargarListaPartidos.
        /// </summary>
        private void CargarListaPartidos()
        {
            if (FiltroSeleccionado != null)
            {
                BLL.Partido bllPartido = new Partido();

                if (FiltroSeleccionado.Id == 1)
                    Partidos = new SortablePageableCollection<PartidoHelperUI>(bllPartido.ObtenerPartidosSinCalificacion());
                else
                    Partidos = new SortablePageableCollection<PartidoHelperUI>(bllPartido.ObtenerPartidosConCalificacion());


                Visibilidad = Visibility.Visible;
            }
        }

        /// <summary>
        /// The ExecuteRunCargarCalificacion.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunCargarCalificacion(object obj)
        {
            BLL.PartidoArbitro bllPartidoArbitro = new PartidoArbitro();
            List<BE.PartidoArbitro> partidoArbitros = bllPartidoArbitro.ObtenerPartidoArbitroPorPartidoId(PartidoSeleccionado.Id);

            AmCalificacionViewModel viewModel = new AmCalificacionViewModel(PartidoSeleccionado.ConvertirAPartido(), partidoArbitros);

            var view = new AmCalificacion
            {
                DataContext = viewModel
            };


            var result = await DialogHost.Show(view, "RootDialog");

            viewModel = (AmCalificacionViewModel)view.DataContext;

            if (viewModel.SeGuardo)
            {
                CargarListaPartidos();

            }
        }

        /// <summary>
        /// The ExecuteSelectedItemChangedCommand.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            CargarListaPartidos();
        }

        /// <summary>
        /// The ExecuteSelectedPartidoChangedCommand.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteSelectedPartidoChangedCommand(object obj)
        {
            Habilitado = PartidoSeleccionado != null;
        }

        /// <summary>
        /// The Limpiar.
        /// </summary>
        private void Limpiar()
        {
            FiltroSeleccionado = null;
            Partidos = null;
            Visibilidad = Visibility.Collapsed;
        }

        #endregion
    }
}
