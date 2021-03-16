namespace DA.UI.ViewModel
{
    using DA.BE;
    using DA.SS;
    using DA.UI.ABM;
    using DA.UI.DataGrid;
    using MaterialDesignThemes.Wpf;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Defines the <see cref="AdmArbitroViewModel" />.
    /// </summary>
    public class AdmArbitroViewModel : ViewModelBaseLocal
    {
        #region Fields

        /// <summary>
        /// Defines the _viewModelAmArbitro.
        /// </summary>
        private readonly AmArbitro _amArbitro;

        /// <summary>
        /// Defines the _arbitros.
        /// </summary>
        private List<BE.Arbitro> _arbitros;

        /// <summary>
        /// Defines the _arbitroSeleccionado.
        /// </summary>
        private BE.Arbitro _arbitroSeleccionado;

        /// <summary>
        /// Defines the _busyIndicator.
        /// </summary>
        private bool _busyIndicator;

        /// <summary>
        /// Defines the _coleccionArbitro.
        /// </summary>
        private SortablePageableCollection<BE.Arbitro> _coleccionArbitro;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdmArbitroViewModel"/> class.
        /// </summary>
        public AdmArbitroViewModel()
        {

            _amArbitro = new AmArbitro()
            {
                DataContext = new AmArbitroViewModel()
            };

            CargaGrillaArbitro();
            GoToNextPageCommand = new RelayCommand(a => ColeccionArbitro.GoToNextPage());
            GoToPreviousPageCommand = new RelayCommand(a => ColeccionArbitro.GoToPreviousPage());
            CleanCommand = new RelayCommand(ExecuteCleanCommand);
            RunAltaArbitro = new RelayCommand(ExecuteRunAltaArbitro);
            RunEditarArbitro = new RelayCommand(ExecuteRunEditarArbitro);
            RunGuardarArbitro = new RelayCommand(ExecuteRunGuardarArbitro);
            RunEliminarArbitro = new RelayCommand(ExecuteRunEliminarArbitro);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Arbitros.
        /// </summary>
        public List<BE.Arbitro> Arbitros { get => _arbitros; set => SetProperty(ref _arbitros, value); }

        /// <summary>
        /// Gets or sets the ArbitroSeleccionado.
        /// </summary>
        public BE.Arbitro ArbitroSeleccionado { get => _arbitroSeleccionado; set => SetProperty(ref _arbitroSeleccionado, value); }

        /// <summary>
        /// Gets or sets a value indicating whether BusyIndicator.
        /// </summary>
        public bool BusyIndicator { get => _busyIndicator; set => SetProperty(ref _busyIndicator, value); }

        /// <summary>
        /// Gets the CleanCommand.
        /// </summary>
        public ICommand CleanCommand { get; private set; }

        /// <summary>
        /// Gets or sets the ColeccionArbitro.
        /// </summary>
        public SortablePageableCollection<BE.Arbitro> ColeccionArbitro
        {
            get
            {
                return _coleccionArbitro;
            }
            set
            {
                if (_coleccionArbitro != value)
                {
                    _coleccionArbitro = value;
                    SendPropertyChanged(() => ColeccionArbitro);
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
        /// Gets the RunAltaArbitro.
        /// </summary>
        public ICommand RunAltaArbitro { get; private set; }

        /// <summary>
        /// Gets the RunEditarArbitro.
        /// </summary>
        public ICommand RunEditarArbitro { get; private set; }

        /// <summary>
        /// Gets the RunEliminarArbitro.
        /// </summary>
        public ICommand RunEliminarArbitro { get; private set; }

        /// <summary>
        /// Gets the RunGuardarArbitro.
        /// </summary>
        public ICommand RunGuardarArbitro { get; private set; }

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
        /// The CargaGrillaArbitro.
        /// </summary>
        private void CargaGrillaArbitro()
        {
            ColeccionArbitro = null;
            BLL.Arbitro blllArbitro = new BLL.Arbitro();

            Arbitros = blllArbitro.ObtenerArbitrosReducido();

            ColeccionArbitro = new SortablePageableCollection<BE.Arbitro>(Arbitros);
        }

        /// <summary>
        /// The ExecuteRunAltaArbitro.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunAltaArbitro(object obj)
        {
            AmArbitroViewModel viewModel = (AmArbitroViewModel)_amArbitro.DataContext;
            viewModel.SeCancelo = true;
            ((AmArbitroViewModel)_amArbitro.DataContext).Id = 0;
            ((AmArbitroViewModel)_amArbitro.DataContext).Nombre = string.Empty;
            ((AmArbitroViewModel)_amArbitro.DataContext).Apellido = string.Empty;
            ((AmArbitroViewModel)_amArbitro.DataContext).Ranking = 0;
            ((AmArbitroViewModel)_amArbitro.DataContext).AniosExperiencia = 0;
            ((AmArbitroViewModel)_amArbitro.DataContext).NotaAFA = "0";
            ((AmArbitroViewModel)_amArbitro.DataContext).Genero = new Genero() { Id = 1, Descripcion = "Masculino" };
            ((AmArbitroViewModel)_amArbitro.DataContext).DNI = string.Empty;
            ((AmArbitroViewModel)_amArbitro.DataContext).Activo = true;
            ((AmArbitroViewModel)_amArbitro.DataContext).FechaNacimiento = DateTime.Now;
            ((AmArbitroViewModel)_amArbitro.DataContext).TituloValidoArgentina = false;
            ((AmArbitroViewModel)_amArbitro.DataContext).LicenciaInternacional = false;
            ((AmArbitroViewModel)_amArbitro.DataContext).ExamenTeorico = false;
            ((AmArbitroViewModel)_amArbitro.DataContext).ExamenFisico = false;

            ((AmArbitroViewModel)_amArbitro.DataContext).Nivel = null;
            ((AmArbitroViewModel)_amArbitro.DataContext).Deporte = new Deporte() { Id = 1, Descripcion = "Futsal" }; ;

            ((AmArbitroViewModel)_amArbitro.DataContext).Visibilidad = Visibility.Visible;
            ((AmArbitroViewModel)_amArbitro.DataContext).Titulo = "Alta de árbitro";

            await DialogHost.Show(_amArbitro, "RootDialog");

            Mensaje vieMensaje = null;

            if (viewModel.SeCancelo == false)
            {
                if (viewModel.SeGuardo)
                {
                    Limpiar();
                    CargaGrillaArbitro();
                }

            }
        }

        /// <summary>
        /// The ExecuteRunEditarArbitro.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunEditarArbitro(object obj)
        {
            Mensaje vieMensaje = null;

            AmArbitro frmAmArbitro = new AmArbitro();

            if (ArbitroSeleccionado != null)
            {
                AmArbitroViewModel viewModelAmArbitro = new AmArbitroViewModel();

                viewModelAmArbitro.Titulo = "Editar Árbitro";
                viewModelAmArbitro.ArbitroSeleccionado = ArbitroSeleccionado;

                viewModelAmArbitro.Id = ArbitroSeleccionado.Id;
                viewModelAmArbitro.Nombre = ArbitroSeleccionado.Nombre;
                viewModelAmArbitro.Apellido = ArbitroSeleccionado.Apellido;
                viewModelAmArbitro.Ranking = ArbitroSeleccionado.Ranking;
                viewModelAmArbitro.AniosExperiencia = ArbitroSeleccionado.AniosExperiencia;
                viewModelAmArbitro.NotaAFA = ArbitroSeleccionado.NotaAFA.ToString();
                viewModelAmArbitro.LicenciaInternacional = ArbitroSeleccionado.PoseeLicenciaInternacional;

                viewModelAmArbitro.DNI = ArbitroSeleccionado.DNI;
                viewModelAmArbitro.Activo = ArbitroSeleccionado.Habilitado;
                viewModelAmArbitro.FechaNacimiento = ArbitroSeleccionado.FechaNacimiento;

                viewModelAmArbitro.TituloValidoArgentina = ArbitroSeleccionado.PoseeTituloValidoArgentina;
                viewModelAmArbitro.ExamenTeorico = ArbitroSeleccionado.ExamenTeoricoAprobado;
                viewModelAmArbitro.ExamenFisico = ArbitroSeleccionado.ExamenFisicoAprobado;

                viewModelAmArbitro.CargarComboDeportes(ArbitroSeleccionado.Deporte);
                viewModelAmArbitro.CargarComboGeneros(ArbitroSeleccionado.Genero);
                viewModelAmArbitro.Deporte = ArbitroSeleccionado.Deporte;
                viewModelAmArbitro.Habilitado = true;
                viewModelAmArbitro.CargarComboNivel(ArbitroSeleccionado.Deporte.Id);
                viewModelAmArbitro.Nivel = ArbitroSeleccionado.Nivel;
                //viewModelAmArbitro.Genero = ArbitroSeleccionado.Genero;
                viewModelAmArbitro.Visibilidad = Visibility.Visible;

                viewModelAmArbitro.Editar = true;

                frmAmArbitro.DataContext = viewModelAmArbitro;

                var result = await DialogHost.Show(frmAmArbitro, "RootDialog");

                if (viewModelAmArbitro.SeCancelo == false)
                {
                    if (viewModelAmArbitro.SeGuardo)
                    {
                        Limpiar();
                        CargaGrillaArbitro();

                    }

                }

            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Editar árbitro", "Debe seleccionar un árbitro para editar");

            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        /// <summary>
        /// The ExecuteRunEliminarArbitro.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunEliminarArbitro(object obj)
        {
            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            Mensaje vieMensaje = null;


            if (ArbitroSeleccionado != null)
            {

                MensajeConsulta mensajeConsulta = new MensajeConsulta();

                object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");

                Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
                switch (respuesta)
                {
                    case Respuesta.Si:
                        {

                            Resultado resultado = bllArbitro.Quitar(ArbitroSeleccionado);

                            if (resultado.HayError == false)
                            {
                                vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Baja de árbitro",
                                    "Se elimino el árbitro seleccionado");
                            }
                            else
                                vieMensaje = new Mensaje(TipoMensaje.ERROR, "Baja de árbitro",
                                    "El árbitro no pudo ser eliminado");

                            Limpiar();
                            CargaGrillaArbitro();
                        }
                        break;

                }

            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Eliminar árbitro", "Debe seleccionar un Arbitro");


            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        /// <summary>
        /// The ExecuteRunGuardarArbitro.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunGuardarArbitro(object obj)
        {

            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            Mensaje vieMensaje = null;


            if (ArbitroSeleccionado != null)
            {

                MensajeConsulta mensajeConsulta = new MensajeConsulta();

                object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");

                Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
                switch (respuesta)
                {
                    case Respuesta.Si:
                        Resultado resultado = null;
                        foreach (Arbitro arbitro in Arbitros)
                        {
                            resultado = bllArbitro.Editar(arbitro);
                        }


                        if (resultado.HayError == false)
                        {
                            vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Edición de Arbitro", "Se editó el Arbitro seleccionado");
                            Limpiar();
                            CargaGrillaArbitro();
                        }
                        else
                        {
                            vieMensaje = new Mensaje(TipoMensaje.ERROR, "Edición de Arbitro", resultado.Descripcion);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Eliminar Arbitro", "Debe seleccionar un Arbitro");

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
            ArbitroSeleccionado = null;
            ColeccionArbitro = null;
        }

        #endregion
    }
}
