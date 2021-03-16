namespace DA.UI.ViewModel
{
    using DA.SS;
    using DA.UI.Principales.Designacion;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Fecha = DA.BE.Fecha;
    using Partido = DA.BE.Partido;

    /// <summary>
    /// Defines the <see cref="Pagina2ControlViewModel" />.
    /// </summary>
    public class Pagina2ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the _arbitros.
        /// </summary>
        private List<BE.Arbitro> _arbitros;

        /// <summary>
        /// Defines the _busyArbitro.
        /// </summary>
        private bool _busyArbitro;

        /// <summary>
        /// Defines the _busyPartido.
        /// </summary>
        private bool _busyPartido;

        /// <summary>
        /// Defines the _deporteSeleccionado.
        /// </summary>
        private BE.Deporte _deporteSeleccionado;

        /// <summary>
        /// Defines the _habilitado.
        /// </summary>
        private bool _habilitado;

        /// <summary>
        /// Defines the _partidos.
        /// </summary>
        private List<PartidoHelperUI> _partidos;

        /// <summary>
        /// Defines the _previousViewModel.
        /// </summary>
        private ITransitionerViewModel _previousViewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagina2ControlViewModel"/> class.
        /// </summary>
        public Pagina2ControlViewModel()
        {
            Partidos = new List<PartidoHelperUI>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Arbitros.
        /// </summary>
        public List<BE.Arbitro> Arbitros
        {
            get
            {
                return _arbitros;
            }
            set
            {
                if (_arbitros != value)
                {
                    _arbitros = value;
                    SendPropertyChanged(() => Arbitros);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether BusyArbitro.
        /// </summary>
        public bool BusyArbitro { get => _busyArbitro; set => SetProperty(ref _busyArbitro, value); }

        /// <summary>
        /// Gets or sets a value indicating whether BusyPartido.
        /// </summary>
        public bool BusyPartido { get => _busyPartido; set => SetProperty(ref _busyPartido, value); }

        /// <summary>
        /// Gets or sets the DeporteSeleccionado.
        /// </summary>
        public BE.Deporte DeporteSeleccionado { get => _deporteSeleccionado; set => SetProperty(ref _deporteSeleccionado, value); }

        /// <summary>
        /// Gets or sets the FechasDisponibles.
        /// </summary>
        public List<BE.Fecha> FechasDisponibles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Habilitado.
        /// </summary>
        public bool Habilitado { get => _habilitado; set => SetProperty(ref _habilitado, value); }

        /// <summary>
        /// Gets or sets the Partidos.
        /// </summary>
        public List<PartidoHelperUI> Partidos
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
            _previousViewModel = previousViewModel;

            if (_previousViewModel is Pagina1ControlViewModel)
            {
                Pagina1ControlViewModel pag1Vm = (Pagina1ControlViewModel)_previousViewModel;
                FechasDisponibles = pag1Vm.FechasDisponibles;
            }

            var task = new Task(CargarVista);
            task.Start();
        }

        /// <summary>
        /// The CargarArbitros.
        /// </summary>
        private void CargarArbitros()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (o, ea) =>
            {

                BLL.Arbitro bllArbitro = new BLL.Arbitro();

                Arbitros = bllArbitro.ObtenerArbitrosConNivel();
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {

                BusyArbitro = false;
                Habilitado = true;
            };

            Habilitado = false;
            BusyArbitro = true;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// The CargarPartidos.
        /// </summary>
        private void CargarPartidos()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (o, ea) =>
            {
                List<PartidoHelperUI> partidosAux = new List<PartidoHelperUI>();

                if (_previousViewModel is Pagina1ControlViewModel)
                {
                    Pagina1ControlViewModel pag1Vm = (Pagina1ControlViewModel)_previousViewModel;

                    DeporteSeleccionado = pag1Vm.DeporteSeleccionado;

                    foreach (Fecha fecha in pag1Vm.FechasDisponibles)
                    {
                        foreach (Partido partido in fecha.Partidos)
                        {
                            partidosAux.Add(new PartidoHelperUI(partido));
                        }
                    }
                }

                Partidos = partidosAux;

            };
            worker.RunWorkerCompleted += (o, ea) =>
            {

                BusyPartido = false;
            };

            BusyPartido = true;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// The CargarVista.
        /// </summary>
        private void CargarVista()
        {
            Partidos.Clear();

            CargarPartidos();

            CargarArbitros();
        }

        #endregion
    }
}
