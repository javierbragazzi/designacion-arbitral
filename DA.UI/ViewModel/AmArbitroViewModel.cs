namespace DA.UI.ViewModel
{
    using DA.BE;
    using DA.SS;
    using MaterialDesignThemes.Wpf;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using RelayCommand = DA.UI.DataGrid.RelayCommand;

    /// <summary>
    /// Defines the <see cref="AmArbitroViewModel" />.
    /// </summary>
    public class AmArbitroViewModel : ViewModelBaseLocal
    {
        #region Fields

        /// <summary>
        /// Defines the _activo.
        /// </summary>
        private bool? _activo;

        /// <summary>
        /// Defines the _aniosexperiencia.
        /// </summary>
        private int _aniosexperiencia;

        /// <summary>
        /// Defines the _apellido.
        /// </summary>
        private string _apellido;

        /// <summary>
        /// Defines the _arbitroSeleccionado.
        /// </summary>
        private Arbitro _arbitroSeleccionado;

        /// <summary>
        /// Defines the _deporte.
        /// </summary>
        private Deporte _deporte;

        /// <summary>
        /// Defines the _deportes.
        /// </summary>
        private List<BE.Deporte> _deportes = new List<Deporte>();

        /// <summary>
        /// Defines the _dni.
        /// </summary>
        private string _dni;

        /// <summary>
        /// Defines the _examenfisico.
        /// </summary>
        private bool? _examenfisico;

        /// <summary>
        /// Defines the _examenteorico.
        /// </summary>
        private bool? _examenteorico;

        /// <summary>
        /// Defines the _fechanacimiento.
        /// </summary>
        private DateTime _fechanacimiento;

        /// <summary>
        /// Defines the _genero.
        /// </summary>
        private BE.Genero _genero;

        /// <summary>
        /// Defines the _generos.
        /// </summary>
        private List<BE.Genero> _generos = new List<Genero>();

        /// <summary>
        /// Defines the _habilitado.
        /// </summary>
        private bool? _habilitado;

        /// <summary>
        /// Defines the _id.
        /// </summary>
        private int _id;

        /// <summary>
        /// Defines the _licenciainternacional.
        /// </summary>
        private bool? _licenciainternacional;

        /// <summary>
        /// Defines the _nivel.
        /// </summary>
        private Nivel _nivel;

        /// <summary>
        /// Defines the _niveles.
        /// </summary>
        private List<BE.Nivel> _niveles = new List<Nivel>();

        /// <summary>
        /// Defines the _nombre.
        /// </summary>
        private string _nombre;

        /// <summary>
        /// Defines the _notaafa.
        /// </summary>
        private string _notaafa;

        /// <summary>
        /// Defines the _ranking.
        /// </summary>
        private int _ranking;

        /// <summary>
        /// Defines the _tipoMensaje.
        /// </summary>
        private TipoMensaje _tipoMensaje;

        /// <summary>
        /// Defines the _titulo.
        /// </summary>
        private string _titulo;

        /// <summary>
        /// Defines the _titulovalidoargentina.
        /// </summary>
        private bool? _titulovalidoargentina;

        /// <summary>
        /// Defines the _visibilidad.
        /// </summary>
        private Visibility _visibilidad;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AmArbitroViewModel"/> class.
        /// </summary>
        public AmArbitroViewModel()
        {
            Habilitado = false;
            CargarComboDeportes(null);
            CargarComboGeneros(null);
            this.Visibilidad = Visibility.Visible;
            RunGuardar = new RelayCommand(ExecuteRunGuardar);
            RunCancelar = new RelayCommand(ExecuteRunCancelar);
            SelectedItemChangedDeporteCommand = new RelayCommand(ExecuteSelectedItemChangedDeporteCommand);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Activo.
        /// </summary>
        public bool? Activo { get => _activo; set => SetProperty(ref _activo, value); }

        /// <summary>
        /// Gets or sets the AniosExperiencia.
        /// </summary>
        public int AniosExperiencia { get => _aniosexperiencia; set => SetProperty(ref _aniosexperiencia, value); }

        /// <summary>
        /// Gets or sets the Apellido.
        /// </summary>
        public string Apellido { get => _apellido; set => SetProperty(ref _apellido, value); }

        /// <summary>
        /// Gets or sets the ArbitroSeleccionado.
        /// </summary>
        public Arbitro ArbitroSeleccionado { get => _arbitroSeleccionado; set => SetProperty(ref _arbitroSeleccionado, value); }

        /// <summary>
        /// Gets or sets the Deporte.
        /// </summary>
        public Deporte Deporte { get => _deporte; set => SetProperty(ref _deporte, value); }

        /// <summary>
        /// Gets or sets the Deportes.
        /// </summary>
        public List<BE.Deporte> Deportes { get => _deportes; set => SetProperty(ref _deportes, value); }

        /// <summary>
        /// Gets or sets the DNI.
        /// </summary>
        public string DNI { get => _dni; set => SetProperty(ref _dni, value); }

        /// <summary>
        /// Gets or sets a value indicating whether Editar.
        /// </summary>
        public bool Editar { get; set; }

        /// <summary>
        /// Gets or sets the ExamenFisico.
        /// </summary>
        public bool? ExamenFisico { get => _examenfisico; set => SetProperty(ref _examenfisico, value); }

        /// <summary>
        /// Gets or sets the ExamenTeorico.
        /// </summary>
        public bool? ExamenTeorico { get => _examenteorico; set => SetProperty(ref _examenteorico, value); }

        /// <summary>
        /// Gets or sets the FechaNacimiento.
        /// </summary>
        public DateTime FechaNacimiento { get => _fechanacimiento; set => SetProperty(ref _fechanacimiento, value); }

        /// <summary>
        /// Gets or sets the Genero.
        /// </summary>
        public BE.Genero Genero { get => _genero; set => SetProperty(ref _genero, value); }

        /// <summary>
        /// Gets or sets the Generos.
        /// </summary>
        public List<BE.Genero> Generos { get => _generos; set => SetProperty(ref _generos, value); }

        /// <summary>
        /// Gets or sets the Habilitado.
        /// </summary>
        public bool? Habilitado { get => _habilitado; set => SetProperty(ref _habilitado, value); }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get => _id; set => SetProperty(ref _id, value); }

        /// <summary>
        /// Gets or sets the LicenciaInternacional.
        /// </summary>
        public bool? LicenciaInternacional { get => _licenciainternacional; set => SetProperty(ref _licenciainternacional, value); }

        /// <summary>
        /// Gets or sets the Nivel.
        /// </summary>
        public Nivel Nivel { get => _nivel; set => SetProperty(ref _nivel, value); }

        /// <summary>
        /// Gets or sets the Niveles.
        /// </summary>
        public List<BE.Nivel> Niveles { get => _niveles; set => SetProperty(ref _niveles, value); }

        /// <summary>
        /// Gets or sets the Nombre.
        /// </summary>
        public string Nombre { get => _nombre; set => SetProperty(ref _nombre, value); }

        /// <summary>
        /// Gets or sets the NotaAFA.
        /// </summary>
        public string NotaAFA { get => _notaafa; set => SetProperty(ref _notaafa, value); }

        /// <summary>
        /// Gets or sets the Ranking.
        /// </summary>
        public int Ranking { get => _ranking; set => SetProperty(ref _ranking, value); }

        /// <summary>
        /// Gets or sets the ResultadoAltaModificacion.
        /// </summary>
        public Resultado ResultadoAltaModificacion { get; set; }

        /// <summary>
        /// Gets the RunCancelar.
        /// </summary>
        public ICommand RunCancelar { get; }

        /// <summary>
        /// Gets the RunGuardar.
        /// </summary>
        public ICommand RunGuardar { get; }

        /// <summary>
        /// Gets or sets a value indicating whether SeCancelo.
        /// </summary>
        public bool SeCancelo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SeGuardo.
        /// </summary>
        public bool SeGuardo { get; set; }

        /// <summary>
        /// Gets the SelectedItemChangedDeporteCommand.
        /// </summary>
        public ICommand SelectedItemChangedDeporteCommand { get; }

        /// <summary>
        /// Gets or sets the TipoMensaje.
        /// </summary>
        public TipoMensaje TipoMensaje { get => _tipoMensaje; set => SetProperty(ref _tipoMensaje, value); }

        /// <summary>
        /// Gets or sets the Titulo.
        /// </summary>
        public string Titulo { get => _titulo; set => SetProperty(ref _titulo, value); }

        /// <summary>
        /// Gets or sets the TituloValidoArgentina.
        /// </summary>
        public bool? TituloValidoArgentina { get => _titulovalidoargentina; set => SetProperty(ref _titulovalidoargentina, value); }

        /// <summary>
        /// Gets or sets the Visibilidad.
        /// </summary>
        public Visibility Visibilidad { get => _visibilidad; set => SetProperty(ref _visibilidad, value); }

        #endregion

        #region Methods

        /// <summary>
        /// The CargarComboDeportes.
        /// </summary>
        /// <param name="selectedDeporte">The selectedDeporte<see cref="BE.Deporte"/>.</param>
        public void CargarComboDeportes(BE.Deporte selectedDeporte)
        {
            BLL.Deporte bllDeporte = new BLL.Deporte();

            Deportes = bllDeporte.ObtenerDeportes();

            if (selectedDeporte != null)
            {
                Deporte = selectedDeporte;
            }
            else
            {
                Deporte = Deportes[0];
            }
        }

        /// <summary>
        /// The CargarComboGeneros.
        /// </summary>
        /// <param name="selectedGenero">The selectedGenero<see cref="Genero"/>.</param>
        public void CargarComboGeneros(Genero selectedGenero)
        {
            BLL.Genero bllGenero = new BLL.Genero();

            Generos.Clear();

            foreach (Genero genero in bllGenero.ObtenerGeneros())
            {
                Generos.Add(genero);
            }

            if (selectedGenero != null)
            {
                Genero = selectedGenero;
            }
            else
            {
                Genero = new Genero() { Id = 1, Descripcion = "Masculino" };
            }
        }

        /// <summary>
        /// The CargarComboNivel.
        /// </summary>
        /// <param name="idDeporte">The idDeporte<see cref="int"/>.</param>
        public void CargarComboNivel(int idDeporte)
        {
            BLL.Nivel bllNivel = new BLL.Nivel();

            Niveles = bllNivel.ObtenerNivelesPorDeporte(idDeporte);
        }

        /// <summary>
        /// The ExecuteRunCancelar.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteRunCancelar(object obj)
        {
            SeCancelo = !SeGuardo;


            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        /// <summary>
        /// The ExecuteRunGuardar.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunGuardar(object obj)
        {

            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            switch (Editar)
            {
                case false:
                    ResultadoAltaModificacion = bllArbitro.Agregar(new BE.Arbitro()
                    {
                        Nombre = Nombre,
                        Apellido = Apellido,
                        FechaNacimiento = FechaNacimiento,
                        Nivel = Nivel,
                        Genero = Genero,
                        DNI = DNI,
                        Deporte = Deporte,
                        Habilitado = Activo,
                        Ranking = Ranking,
                        AniosExperiencia = AniosExperiencia,
                        NotaAFA = Convert.ToInt64(NotaAFA),
                        PoseeTituloValidoArgentina = TituloValidoArgentina,
                        PoseeLicenciaInternacional = LicenciaInternacional,
                        ExamenFisicoAprobado = ExamenFisico,
                        ExamenTeoricoAprobado = ExamenTeorico
                    });

                    break;
                case true:
                    Editar = false;
                    ResultadoAltaModificacion = bllArbitro.Editar(new BE.Arbitro()
                    {
                        Id = Id,
                        Nombre = Nombre,
                        Apellido = Apellido,
                        FechaNacimiento = FechaNacimiento,
                        Genero = Genero,
                        DNI = DNI,
                        Habilitado = Activo,
                        Nivel = Nivel,
                        Deporte = Deporte,
                        Ranking = Ranking,
                        AniosExperiencia = AniosExperiencia,
                        NotaAFA = Convert.ToInt64(NotaAFA),
                        PoseeTituloValidoArgentina = TituloValidoArgentina,
                        PoseeLicenciaInternacional = LicenciaInternacional,
                        ExamenFisicoAprobado = ExamenFisico,
                        ExamenTeoricoAprobado = ExamenTeorico

                    });

                    break;
            }

            SeGuardo = !ResultadoAltaModificacion.HayError;
            this.TipoMensaje = ResultadoAltaModificacion.HayError == false ? TipoMensaje.CORRECTO : TipoMensaje.ERROR;
            this.Visibilidad = Visibility.Collapsed;

            if (SeGuardo)
            {
                Limpiar();
                var vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Árbitro", "El árbitro se guardo con éxito");

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");
                }

                SeCancelo = false;

            }
            else
            {
                var vieMensaje = new Mensaje(TipoMensaje.ERROR, ResultadoAltaModificacion.Titulo, ResultadoAltaModificacion.Descripcion);

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");

                    DialogHost.CloseDialogCommand.Execute(null, vieMensaje);
                }
            }
        }

        /// <summary>
        /// The ExecuteSelectedItemChangedDeporteCommand.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteSelectedItemChangedDeporteCommand(object obj)
        {
            if (Deporte != null && Editar == false)
            {
                CargarComboNivel(Deporte.Id);

                Habilitado = true;
            }
        }

        /// <summary>
        /// The Limpiar.
        /// </summary>
        private void Limpiar()
        {
            this.AniosExperiencia = 0;
            this.Apellido = "";
            this.Nombre = "";
            this.DNI = "";
            this.ExamenFisico = false;
            this.ExamenTeorico = false;
            this.LicenciaInternacional = false;
            this.NotaAFA = "0";
            this.FechaNacimiento = DateTime.Now;
            this.TituloValidoArgentina = false;
            this.Ranking = 0;
        }

        #endregion
    }
}
