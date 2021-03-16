namespace DA.UI.ViewModel
{
    using DA.SS;
    using DA.UI.DataGrid;
    using MaterialDesignThemes.Wpf;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Situacion = DA.SS.Situacion;

    /// <summary>
    /// Defines the <see cref="UCPromocionDescensoViewModel" />.
    /// </summary>
    public class UCPromocionDescensoViewModel : ViewModelBaseLocal
    {
        #region Fields

        /// <summary>
        /// Defines the _busyIndicator.
        /// </summary>
        private bool _busyIndicator;

        /// <summary>
        /// Defines the _habilitadoBorrar.
        /// </summary>
        private bool _habilitadoBorrar;

        /// <summary>
        /// Defines the _habilitadoCalcular.
        /// </summary>
        private bool _habilitadoCalcular;

        /// <summary>
        /// Defines the _habilitadoGuardar.
        /// </summary>
        private bool _habilitadoGuardar;

        /// <summary>
        /// Defines the _puntajes.
        /// </summary>
        private SortablePageableCollection<PuntajeArbitro> _puntajes;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UCPromocionDescensoViewModel"/> class.
        /// </summary>
        public UCPromocionDescensoViewModel()
        {
            //CargaGrillaPuntajes();
            HabilitadoBorrar = false;
            HabilitadoGuardar = false;
            HabilitadoCalcular = true;

            GoToNextPageCommand = new RelayCommand(a => Puntajes.GoToNextPage());
            GoToPreviousPageCommand = new RelayCommand(a => Puntajes.GoToPreviousPage());
            CleanCommand = new RelayCommand(ExecuteCleanCommand);
            RunGuardar = new RelayCommand(ExecuteRunGuardar);
            RunBorrar = new RelayCommand(ExecuteRunBorrar);
            RunCalcular = new RelayCommand(ExecuteRunCalcular);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether BusyIndicator.
        /// </summary>
        public bool BusyIndicator { get => _busyIndicator; set => SetProperty(ref _busyIndicator, value); }

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
                return new List<int>() { 5, 10, 15, 20 };
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
        /// Gets or sets a value indicating whether HabilitadoBorrar.
        /// </summary>
        public bool HabilitadoBorrar { get => _habilitadoBorrar; set => SetProperty(ref _habilitadoBorrar, value); }

        /// <summary>
        /// Gets or sets a value indicating whether HabilitadoCalcular.
        /// </summary>
        public bool HabilitadoCalcular { get => _habilitadoCalcular; set => SetProperty(ref _habilitadoCalcular, value); }

        /// <summary>
        /// Gets or sets a value indicating whether HabilitadoGuardar.
        /// </summary>
        public bool HabilitadoGuardar { get => _habilitadoGuardar; set => SetProperty(ref _habilitadoGuardar, value); }

        /// <summary>
        /// Gets or sets the Puntajes.
        /// </summary>
        public SortablePageableCollection<PuntajeArbitro> Puntajes { get => _puntajes; set => SetProperty(ref _puntajes, value); }

        /// <summary>
        /// Gets the RunBorrar.
        /// </summary>
        public ICommand RunBorrar { get; private set; }

        /// <summary>
        /// Gets the RunCalcular.
        /// </summary>
        public ICommand RunCalcular { get; private set; }

        /// <summary>
        /// Gets the RunGuardar.
        /// </summary>
        public ICommand RunGuardar { get; private set; }

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
        /// The CargaGrillaPuntajes.
        /// </summary>
        private void CargaGrillaPuntajes()
        {
            Puntajes = null;
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();

            Puntajes = new SortablePageableCollection<PuntajeArbitro>(bllCalificacion.ObtenerPuntajeDeTemporada());

            if (Puntajes.GetAllObjects().Count != 0)
            {
                HabilitadoCalcular = true;
            }
            else
            {
                HabilitadoCalcular = false;
            }
        }

        /// <summary>
        /// The ExecuteRunBorrar.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteRunBorrar(object obj)
        {
            Puntajes = null;
            HabilitadoGuardar = false;
            HabilitadoCalcular = true;
        }

        /// <summary>
        /// The ExecuteRunCalcular.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteRunCalcular(object obj)
        {
            CargaGrillaPuntajes();
            HabilitadoCalcular = false;
            HabilitadoGuardar = true;
            HabilitadoBorrar = true;
        }

        /// <summary>
        /// The ExecuteRunGuardar.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunGuardar(object obj)
        {

            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            Mensaje vieMensaje = null;

            MensajeConsulta mensajeConsulta = new MensajeConsulta();

            object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");

            Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
            switch (respuesta)
            {
                case Respuesta.Si:
                    Resultado resultado = new Resultado(false, "");

                    foreach (PuntajeArbitro puntaje in Puntajes.GetAllObjects())
                    {
                        resultado = puntaje.IdNivelNuevo == -1 ? bllCalificacion.ActualizarProcesado(puntaje) : bllCalificacion.ActualizarNuevoNivel(puntaje);

                        if (puntaje.Situacion == Situacion.Baja)
                            resultado = bllCalificacion.ActualizarBaja(puntaje);

                        if (resultado.HayError)
                        {
                            break;
                        }

                    }

                    if (resultado.HayError == false)
                    {
                        vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Promoción / Descenso", "La operación se realizó con éxito");
                        Limpiar();
                        CargaGrillaPuntajes();
                    }
                    else
                    {
                        vieMensaje = new Mensaje(TipoMensaje.ERROR, "Promoción / Descenso", resultado.Descripcion);
                    }
                    break;

                default:
                    break;
            }

            //vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Promoción / Descenso", "Debe seleccionar un Arbitro");

            if (vieMensaje != null)
            {
                var resul = await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        /// <summary>
        /// The Limpiar.
        /// </summary>
        private void Limpiar()
        {

            Puntajes = null;
        }

        #endregion
    }
}
