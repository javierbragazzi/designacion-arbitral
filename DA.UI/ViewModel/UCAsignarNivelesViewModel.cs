namespace DA.UI.ViewModel
{
    using DA.BE;
    using DA.SS;
    using DA.UI.DataGrid;
    using MaterialDesignThemes.Wpf;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Defines the <see cref="UCAsignarNivelesViewModel" />.
    /// </summary>
    public class UCAsignarNivelesViewModel : ViewModelBaseLocal
    {
        #region Fields

        /// <summary>
        /// Defines the _arbitro.
        /// </summary>
        private List<BE.Arbitro> _arbitro;

        /// <summary>
        /// Defines the _arbitroSeleccionado.
        /// </summary>
        private BE.Arbitro _arbitroSeleccionado;

        /// <summary>
        /// Defines the _arbitrosFiltrados.
        /// </summary>
        private List<BE.Arbitro> _arbitrosFiltrados;

        /// <summary>
        /// Defines the _coleccionArbitros.
        /// </summary>
        private SortablePageableCollection<BE.Arbitro> _coleccionArbitros;

        /// <summary>
        /// Defines the _coleccionNiveles.
        /// </summary>
        private SortablePageableCollection<BE.Nivel> _coleccionNiveles;

        /// <summary>
        /// Defines the _habilitadoAsignar.
        /// </summary>
        private bool _habilitadoAsignar;

        /// <summary>
        /// Defines the _nivel.
        /// </summary>
        private List<BE.Nivel> _nivel;

        /// <summary>
        /// Defines the _nivelSeleccionado.
        /// </summary>
        private BE.Nivel _nivelSeleccionado;

        /// <summary>
        /// Defines the _visibilidad.
        /// </summary>
        private Visibility _visibilidad;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UCAsignarNivelesViewModel"/> class.
        /// </summary>
        public UCAsignarNivelesViewModel()
        {
            CargarArbitros();
            CargarNiveles();
            Visibilidad = Visibility.Collapsed;

            GoToNextPageCommand = new RelayCommand(a => ColeccionArbitros.GoToNextPage());
            GoToPreviousPageCommand = new RelayCommand(a => ColeccionArbitros.GoToPreviousPage());
            CleanCommand = new RelayCommand(ExecuteCleanCommand);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
            RunAsignarNiveles = new RelayCommand(ExecuteRunAsignarNiveles);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Arbitros.
        /// </summary>
        public List<BE.Arbitro> Arbitros { get => _arbitro; set => SetProperty(ref _arbitro, value); }

        /// <summary>
        /// Gets or sets the ArbitroSeleccionado.
        /// </summary>
        public BE.Arbitro ArbitroSeleccionado { get => _arbitroSeleccionado; set => SetProperty(ref _arbitroSeleccionado, value); }

        /// <summary>
        /// Gets or sets the ArbitrosFiltrados.
        /// </summary>
        public List<BE.Arbitro> ArbitrosFiltrados { get => _arbitrosFiltrados; set => SetProperty(ref _arbitrosFiltrados, value); }

        /// <summary>
        /// Gets the CleanCommand.
        /// </summary>
        public ICommand CleanCommand { get; private set; }

        /// <summary>
        /// Gets or sets the ColeccionArbitros.
        /// </summary>
        public SortablePageableCollection<BE.Arbitro> ColeccionArbitros
        {
            get
            {
                return _coleccionArbitros;
            }
            set
            {
                if (_coleccionArbitros != value)
                {
                    _coleccionArbitros = value;
                    SendPropertyChanged(() => ColeccionArbitros);
                }
            }
        }

        /// <summary>
        /// Gets or sets the ColeccionNiveles.
        /// </summary>
        public SortablePageableCollection<BE.Nivel> ColeccionNiveles
        {
            get
            {
                return _coleccionNiveles;
            }
            set
            {
                if (_coleccionNiveles != value)
                {
                    _coleccionNiveles = value;
                    SendPropertyChanged(() => ColeccionNiveles);
                }
            }
        }

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
        /// Gets the GoToNextPageCommand.
        /// </summary>
        public ICommand GoToNextPageCommand { get; private set; }

        /// <summary>
        /// Gets the GoToPreviousPageCommand.
        /// </summary>
        public ICommand GoToPreviousPageCommand { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether HabilitadoAsignar.
        /// </summary>
        public bool HabilitadoAsignar { get => _habilitadoAsignar; set => SetProperty(ref _habilitadoAsignar, value); }

        /// <summary>
        /// Gets or sets the Niveles.
        /// </summary>
        public List<BE.Nivel> Niveles { get => _nivel; set => SetProperty(ref _nivel, value); }

        /// <summary>
        /// Gets or sets the NivelSeleccionado.
        /// </summary>
        public BE.Nivel NivelSeleccionado { get => _nivelSeleccionado; set => SetProperty(ref _nivelSeleccionado, value); }

        /// <summary>
        /// Gets the RunAsignarNiveles.
        /// </summary>
        public ICommand RunAsignarNiveles { get; private set; }

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
        /// The ExecuteCleanCommand.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        public void ExecuteCleanCommand(object obj)
        {
            Limpiar();
        }

        /// <summary>
        /// The CargarArbitros.
        /// </summary>
        private void CargarArbitros()
        {
            BLL.Arbitro bllArbitro = new BLL.Arbitro();

            Arbitros = bllArbitro.ObtenerArbitrosReducido();
        }

        /// <summary>
        /// The CargarNiveles.
        /// </summary>
        private void CargarNiveles()
        {
            BLL.Nivel bllNivel = new BLL.Nivel();
            Niveles = bllNivel.ObtenerNiveles();
            Niveles.Add(new Nivel() { NombreNivel = "Sin nivel" });
        }

        /// <summary>
        /// The ExecuteRunAsignarNiveles.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunAsignarNiveles(object obj)
        {
            BLL.Nivel _nivelBLL = new BLL.Nivel();
            Mensaje vieMensaje = null;
            List<BE.Arbitro> lstNueva = _nivelBLL.AsignarNiveles(ArbitrosFiltrados);

            if (lstNueva != null)
            {
                ColeccionArbitros = new SortablePageableCollection<Arbitro>(lstNueva);
                vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Niveles Asignados", "Operación finalizada correctamente");
            }
            else
            {
                vieMensaje = new Mensaje(TipoMensaje.ERROR, "Niveles No Asignados", "Operación finalizada con errores");
            }

            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        /// <summary>
        /// The ExecuteSelectedItemChangedCommand.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            if (NivelSeleccionado != null && NivelSeleccionado.NombreNivel != null)
            {
                ColeccionNiveles = new SortablePageableCollection<Nivel>(Niveles);
                ArbitrosFiltrados = Arbitros.Where(arbitro => arbitro?.Nivel?.Id == NivelSeleccionado.Id).ToList();
                ColeccionArbitros = new SortablePageableCollection<Arbitro>(ArbitrosFiltrados);
                if (NivelSeleccionado.NombreNivel == "Sin nivel")
                {
                    ArbitrosFiltrados = Arbitros.Where(arbitro => arbitro.Nivel == null).ToList();
                    ColeccionArbitros = new SortablePageableCollection<Arbitro>(ArbitrosFiltrados);
                    HabilitadoAsignar = true;
                }
                else
                {
                    HabilitadoAsignar = false;
                }
                Visibilidad = Visibility.Visible;
            }
        }

        /// <summary>
        /// The Limpiar.
        /// </summary>
        private void Limpiar()
        {
            ArbitroSeleccionado = null;
            ColeccionArbitros = null;
            Visibilidad = Visibility.Collapsed;
        }

        #endregion
    }
}
