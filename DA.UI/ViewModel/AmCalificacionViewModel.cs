namespace DA.UI.ViewModel
{
    using DA.BE;
    using DA.SS;
    using DA.UI.DataGrid;
    using MaterialDesignThemes.Wpf;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Defines the <see cref="AmCalificacionViewModel" />.
    /// </summary>
    public class AmCalificacionViewModel : ViewModelBaseLocal
    {
        #region Fields

        /// <summary>
        /// Defines the _arbitros.
        /// </summary>
        private List<BE.Arbitro> _arbitros;

        /// <summary>
        /// Defines the _arbitroSeleccionado.
        /// </summary>
        private BE.Arbitro _arbitroSeleccionado;

        /// <summary>
        /// Defines the _condicionPuntajeAsistente.
        /// </summary>
        private int _condicionPuntajeAsistente;

        /// <summary>
        /// Defines the _condicionPuntajePrincipal.
        /// </summary>
        private int _condicionPuntajePrincipal;

        /// <summary>
        /// Defines the _dificultadPuntajeAsistente.
        /// </summary>
        private int _dificultadPuntajeAsistente;

        /// <summary>
        /// Defines the _dificultadPuntajePrincipal.
        /// </summary>
        private int _dificultadPuntajePrincipal;

        /// <summary>
        /// Defines the _disciplinaPuntajeAsistente.
        /// </summary>
        private int _disciplinaPuntajeAsistente;

        /// <summary>
        /// Defines the _disciplinaPuntajePrincipal.
        /// </summary>
        private int _disciplinaPuntajePrincipal;

        /// <summary>
        /// Defines the _habilitado.
        /// </summary>
        private bool _habilitado;

        /// <summary>
        /// Defines the _jugadasPuntajeAsistente.
        /// </summary>
        private int _jugadasPuntajeAsistente;

        /// <summary>
        /// Defines the _jugadasPuntajePrincipal.
        /// </summary>
        private int _jugadasPuntajePrincipal;

        /// <summary>
        /// Defines the _reglasPuntajeAsistente.
        /// </summary>
        private int _reglasPuntajeAsistente;

        /// <summary>
        /// Defines the _reglasPuntajePrincipal.
        /// </summary>
        private int _reglasPuntajePrincipal;

        /// <summary>
        /// Defines the _tipoMensaje.
        /// </summary>
        private TipoMensaje _tipoMensaje;

        /// <summary>
        /// Defines the _visibilidad.
        /// </summary>
        private Visibility _visibilidad;

        /// <summary>
        /// Defines the _visibilidadAsistente.
        /// </summary>
        private Visibility _visibilidadAsistente;

        /// <summary>
        /// Defines the _visibilidadPrincipal.
        /// </summary>
        private Visibility _visibilidadPrincipal;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AmCalificacionViewModel"/> class.
        /// </summary>
        public AmCalificacionViewModel()
        {

            RunGuardar = new RelayCommand(ExecuteRunGuardar);
            RunCancelar = new RelayCommand(ExecuteRunCancelar);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmCalificacionViewModel"/> class.
        /// </summary>
        /// <param name="partido">The partido<see cref="BE.Partido"/>.</param>
        /// <param name="partidoArbitros">The partidoArbitros<see cref="List{BE.PartidoArbitro}"/>.</param>
        public AmCalificacionViewModel(BE.Partido partido, List<BE.PartidoArbitro> partidoArbitros)
        {
            Visibilidad = Visibility.Collapsed;
            VisibilidadPrincipal = Visibility.Collapsed;
            VisibilidadAsistente = Visibility.Collapsed;
            Habilitado = false;
            Partido = partido;
            Arbitros = new List<Arbitro>();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                //foreach (KeyValuePair<Arbitro, TipoArbitro> arbitroYTipo in Partido.ArbitrosYTipos)
                foreach (PartidoArbitro partidoArbitro in partidoArbitros)
                {
                    partidoArbitro.Arbitro.NombreCompletoYTipoArbitro += partidoArbitro.Arbitro.NombreCompleto + " - " + partidoArbitro.TipoArbitro.Descripcion;
                    Arbitros.Add(partidoArbitro.Arbitro);

                    if (partidoArbitro.Calificacion != null)
                    {
                        if (partidoArbitro.TipoArbitro.Descripcion.Equals("Principal"))
                        {
                            CalifTemporalPrincipal = partidoArbitro.Calificacion;
                            EstablecerCalificaciones("Principal");
                        }
                        else
                        {
                            CalifTemporalAsistente = partidoArbitro.Calificacion;
                            EstablecerCalificaciones("Asistente");
                        }

                    }
                    else
                    {
                        ReglasPuntajePrincipal = 1;
                        CondicionPuntajePrincipal = 1;
                        DisciplinaPuntajePrincipal = 1;
                        JugadasPuntajePrincipal = 1;
                        DificultadPuntajePrincipal = 1;

                        ReglasPuntajeAsistente = 1;
                        CondicionPuntajeAsistente = 1;
                        DisciplinaPuntajeAsistente = 1;
                        JugadasPuntajeAsistente = 1;
                        DificultadPuntajeAsistente = 1;
                    }

                }
            }

            RunGuardar = new RelayCommand(ExecuteRunGuardar);
            RunCancelar = new RelayCommand(ExecuteRunCancelar);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ArbitroAnterior.
        /// </summary>
        public BE.Arbitro ArbitroAnterior { get; set; }

        /// <summary>
        /// Gets or sets the Arbitros.
        /// </summary>
        public List<BE.Arbitro> Arbitros { get => _arbitros; set => SetProperty(ref _arbitros, value); }

        /// <summary>
        /// Gets or sets the ArbitroSeleccionado.
        /// </summary>
        public BE.Arbitro ArbitroSeleccionado { get => _arbitroSeleccionado; set => SetProperty(ref _arbitroSeleccionado, value); }

        /// <summary>
        /// Gets or sets the CalifTemporalAsistente.
        /// </summary>
        public BE.Calificacion CalifTemporalAsistente { get; set; }

        /// <summary>
        /// Gets or sets the CalifTemporalPrincipal.
        /// </summary>
        public BE.Calificacion CalifTemporalPrincipal { get; set; }

        /// <summary>
        /// Gets or sets the CondicionPuntajeAsistente.
        /// </summary>
        public int CondicionPuntajeAsistente { get => _condicionPuntajeAsistente; set => SetProperty(ref _condicionPuntajeAsistente, value); }

        /// <summary>
        /// Gets or sets the CondicionPuntajePrincipal.
        /// </summary>
        public int CondicionPuntajePrincipal { get => _condicionPuntajePrincipal; set => SetProperty(ref _condicionPuntajePrincipal, value); }

        /// <summary>
        /// Gets or sets the DificultadPuntajeAsistente.
        /// </summary>
        public int DificultadPuntajeAsistente { get => _dificultadPuntajeAsistente; set => SetProperty(ref _dificultadPuntajeAsistente, value); }

        /// <summary>
        /// Gets or sets the DificultadPuntajePrincipal.
        /// </summary>
        public int DificultadPuntajePrincipal { get => _dificultadPuntajePrincipal; set => SetProperty(ref _dificultadPuntajePrincipal, value); }

        /// <summary>
        /// Gets or sets the DisciplinaPuntajeAsistente.
        /// </summary>
        public int DisciplinaPuntajeAsistente { get => _disciplinaPuntajeAsistente; set => SetProperty(ref _disciplinaPuntajeAsistente, value); }

        /// <summary>
        /// Gets or sets the DisciplinaPuntajePrincipal.
        /// </summary>
        public int DisciplinaPuntajePrincipal { get => _disciplinaPuntajePrincipal; set => SetProperty(ref _disciplinaPuntajePrincipal, value); }

        /// <summary>
        /// Gets or sets a value indicating whether Editar.
        /// </summary>
        public bool Editar { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Habilitado.
        /// </summary>
        public bool Habilitado { get => _habilitado; set => SetProperty(ref _habilitado, value); }

        /// <summary>
        /// Gets or sets the JugadasPuntajeAsistente.
        /// </summary>
        public int JugadasPuntajeAsistente { get => _jugadasPuntajeAsistente; set => SetProperty(ref _jugadasPuntajeAsistente, value); }

        /// <summary>
        /// Gets or sets the JugadasPuntajePrincipal.
        /// </summary>
        public int JugadasPuntajePrincipal { get => _jugadasPuntajePrincipal; set => SetProperty(ref _jugadasPuntajePrincipal, value); }

        /// <summary>
        /// Gets or sets the Partido.
        /// </summary>
        public BE.Partido Partido { get; set; }

        /// <summary>
        /// Gets or sets the ReglasPuntajeAsistente.
        /// </summary>
        public int ReglasPuntajeAsistente { get => _reglasPuntajeAsistente; set => SetProperty(ref _reglasPuntajeAsistente, value); }

        /// <summary>
        /// Gets or sets the ReglasPuntajePrincipal.
        /// </summary>
        public int ReglasPuntajePrincipal { get => _reglasPuntajePrincipal; set => SetProperty(ref _reglasPuntajePrincipal, value); }

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
        /// Gets the SelectedItemChangedCommand.
        /// </summary>
        public ICommand SelectedItemChangedCommand { get; private set; }

        /// <summary>
        /// Gets or sets the TipoMensaje.
        /// </summary>
        public TipoMensaje TipoMensaje { get => _tipoMensaje; set => SetProperty(ref _tipoMensaje, value); }

        /// <summary>
        /// Gets or sets the Visibilidad.
        /// </summary>
        public Visibility Visibilidad { get => _visibilidad; set => SetProperty(ref _visibilidad, value); }

        /// <summary>
        /// Gets or sets the VisibilidadAsistente.
        /// </summary>
        public Visibility VisibilidadAsistente { get => _visibilidadAsistente; set => SetProperty(ref _visibilidadAsistente, value); }

        /// <summary>
        /// Gets or sets the VisibilidadPrincipal.
        /// </summary>
        public Visibility VisibilidadPrincipal { get => _visibilidadPrincipal; set => SetProperty(ref _visibilidadPrincipal, value); }

        #endregion

        #region Methods

        /// <summary>
        /// The EstablecerCalificaciones.
        /// </summary>
        /// <param name="tipoArbitro">The tipoArbitro<see cref="string"/>.</param>
        private void EstablecerCalificaciones(string tipoArbitro)
        {
            if (tipoArbitro.Equals("Principal"))
            {
                ReglasPuntajePrincipal = CalifTemporalPrincipal.ReglasPuntaje;
                CondicionPuntajePrincipal = CalifTemporalPrincipal.CondicionFisicaPuntaje;
                DisciplinaPuntajePrincipal = CalifTemporalPrincipal.DisciplinaPuntaje;
                JugadasPuntajePrincipal = CalifTemporalPrincipal.JugadasPuntaje;

                switch (CalifTemporalPrincipal.DificultadPartidoPuntaje)
                {
                    case 0D:
                        DificultadPuntajePrincipal = 1;
                        break;

                    case 0.25D:
                        DificultadPuntajePrincipal = 2;
                        break;

                    case 0.50D:
                        DificultadPuntajePrincipal = 3;
                        break;

                    case 0.75D:
                        DificultadPuntajePrincipal = 4;
                        break;
                }

            }
            else
            {
                switch (CalifTemporalAsistente.DificultadPartidoPuntaje)
                {
                    case 0D:
                        DificultadPuntajeAsistente = 1;
                        break;

                    case 0.25D:
                        DificultadPuntajeAsistente = 2;
                        break;

                    case 0.50D:
                        DificultadPuntajeAsistente = 3;
                        break;

                    case 0.75D:
                        DificultadPuntajeAsistente = 4;
                        break;
                }


                ReglasPuntajeAsistente = CalifTemporalAsistente.ReglasPuntaje;
                CondicionPuntajeAsistente = CalifTemporalAsistente.CondicionFisicaPuntaje;
                DisciplinaPuntajeAsistente = CalifTemporalAsistente.DisciplinaPuntaje;
                JugadasPuntajeAsistente = CalifTemporalAsistente.JugadasPuntaje;

            }
        }

        /// <summary>
        /// The ExecuteRunCancelar.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteRunCancelar(object obj)
        {
            SeCancelo = true;

            DialogHost.CloseDialogCommand.Execute(null, null);
        }

        /// <summary>
        /// The ExecuteRunGuardar.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private async void ExecuteRunGuardar(object obj)
        {

            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            BLL.PartidoArbitro bllPartidoArbitro = new BLL.PartidoArbitro();

            List<BE.PartidoArbitro> partidoArbitros = bllPartidoArbitro.ObtenerPartidoArbitroPorPartidoId(Partido.Id);

            //BE.Arbitro arbitro = Arbitros.FirstOrDefault(x => (x.NombreCompletoTipoArbitro.Contains("Principal")));
            //BE.TipoArbitro tipoArbitroSelec = Partido.ArbitrosYTipos.FirstOrDefault(x => arbitro != null && ((BE.Arbitro) x.Key).Id == arbitro.Id).Value;

            BE.Arbitro arbitro = partidoArbitros.FirstOrDefault(x => x.TipoArbitro.Descripcion.Contains("Principal"))?.Arbitro;
            BE.TipoArbitro tipoArbitroSelec = partidoArbitros.FirstOrDefault(x => x.TipoArbitro.Descripcion.Contains("Principal"))?.TipoArbitro;
            BE.Calificacion cal = new Calificacion
            {
                DisciplinaPuntaje = DisciplinaPuntajePrincipal,
                CondicionFisicaPuntaje = CondicionPuntajePrincipal,
                JugadasPuntaje = JugadasPuntajePrincipal,
                ReglasPuntaje = ReglasPuntajePrincipal
            };


            switch (DificultadPuntajePrincipal)
            {
                case 1:
                    cal.DificultadPartidoPuntaje = 0;
                    break;

                case 2:
                    cal.DificultadPartidoPuntaje = 0.25D;
                    break;

                case 3:
                    cal.DificultadPartidoPuntaje = 0.5D;
                    break;

                case 4:
                    cal.DificultadPartidoPuntaje = 0.75D;
                    break;
            }

            if (arbitro != null)
                ResultadoAltaModificacion =
                    bllCalificacion.Agregar(cal, Partido, arbitro.Id, tipoArbitroSelec.Id);

            arbitro = partidoArbitros.FirstOrDefault(x => x.TipoArbitro.Descripcion.Contains("Asistente"))?.Arbitro;
            tipoArbitroSelec = partidoArbitros.FirstOrDefault(x => x.TipoArbitro.Descripcion.Contains("Asistente"))?.TipoArbitro;

            cal.DisciplinaPuntaje = DisciplinaPuntajeAsistente;
            cal.CondicionFisicaPuntaje = CondicionPuntajeAsistente;
            cal.JugadasPuntaje = JugadasPuntajeAsistente;
            cal.ReglasPuntaje = ReglasPuntajeAsistente;

            switch (DificultadPuntajeAsistente)
            {
                case 1:
                    cal.DificultadPartidoPuntaje = 0;
                    break;

                case 2:
                    cal.DificultadPartidoPuntaje = 0.25D;
                    break;

                case 3:
                    cal.DificultadPartidoPuntaje = 0.5D;
                    break;

                case 4:
                    cal.DificultadPartidoPuntaje = 0.75D;
                    break;
            }

            if (arbitro != null)
                ResultadoAltaModificacion =
                    bllCalificacion.Agregar(cal, Partido, arbitro.Id, tipoArbitroSelec.Id);


            SeGuardo = !ResultadoAltaModificacion.HayError;
            this.TipoMensaje = ResultadoAltaModificacion.HayError == false ? TipoMensaje.CORRECTO : TipoMensaje.ERROR;

            if (SeGuardo)
            {

                var vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Calificación", "La calificación se guardó con éxito");

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");
                }


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
        /// The ExecuteSelectedItemChangedCommand.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            if (ArbitroSeleccionado != null)
            {
                BLL.PartidoArbitro partidoArbitro = new BLL.PartidoArbitro();

                //BE.TipoArbitro tipoArbitroSelec = Partido.ArbitrosYTipos.FirstOrDefault(x => ((BE.Arbitro) x.Key).Id == ArbitroSeleccionado.Id).Value;
                BE.TipoArbitro tipoArbitroSelec =
                    partidoArbitro.ObtenerPartidoArbitroPorPartidoIdYArbitroId(Partido.Id, ArbitroSeleccionado.Id).TipoArbitro;

                if (tipoArbitroSelec.Descripcion.Equals("Principal"))
                {
                    VisibilidadAsistente = Visibility.Collapsed;
                    VisibilidadPrincipal = Visibility.Visible;
                }
                else
                {
                    VisibilidadAsistente = Visibility.Visible;
                    VisibilidadPrincipal = Visibility.Collapsed;
                }


            }


            Visibilidad = Visibility.Visible;
            Habilitado = true;
        }

        #endregion
    }
}
