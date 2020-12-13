using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DA.BE;
using DA.SS;
using MaterialDesignThemes.Wpf;
using RelayCommand = DA.UI.DataGrid.RelayCommand;

namespace DA.UI.ViewModel
{
    public class AmArbitroViewModel : ViewModelBaseLocal
    {
        #region Variables

        private Visibility _visibilidad;
        private TipoMensaje _tipoMensaje;
        private Arbitro _arbitroSeleccionado;
        private string _nombre;
        private string _apellido;
        private DateTime _fechanacimiento;
        private Nivel _nivel;
        private string _dni;
        private BE.Genero _genero;
        private Deporte _deporte;
        private int _ranking;
        private int _aniosexperiencia;
        private int _notaafa;
        private int _id;
        private bool? _activo;
        private string _titulo;
        private List<BE.Nivel> _niveles = new List<Nivel>();
        private List<BE.Deporte> _deportes = new List<Deporte>();
        private bool? _habilitado;
        private bool? _titulovalidoargentina;
        private bool? _licenciainternacional;
        private bool? _examenfisico;
        private bool? _examenteorico;

        #endregion

        #region Propiedades


        public bool? TituloValidoArgentina
        {
            get => _titulovalidoargentina;
            set => SetProperty(ref _titulovalidoargentina, value);
        }

        public bool? LicenciaInternacional
        {
            get => _licenciainternacional;
            set => SetProperty(ref _licenciainternacional, value);
        }

        public bool? ExamenFisico
        {
            get => _examenfisico;
            set => SetProperty(ref _examenfisico, value);
        }

        public bool? ExamenTeorico
        {
            get => _examenteorico;
            set => SetProperty(ref _examenteorico, value);
        }
        public bool? Habilitado
        {
            get => _habilitado;
            set => SetProperty(ref _habilitado, value);
        }

        public Visibility Visibilidad
        {
            get => _visibilidad;
            set => SetProperty(ref _visibilidad, value);
        }

        public TipoMensaje TipoMensaje
        {
            get => _tipoMensaje;
            set => SetProperty(ref _tipoMensaje, value);
        }

        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string Apellido
        {
            get => _apellido;
            set => SetProperty(ref _apellido, value);
        }

        public DateTime FechaNacimiento
        {
            get => _fechanacimiento;
            set => SetProperty(ref _fechanacimiento, value);
        }

        public Nivel Nivel
        {
            get => _nivel;
            set => SetProperty(ref _nivel, value);
        }

        public string DNI
        {
            get => _dni;
            set => SetProperty(ref _dni, value);
        }

        public BE.Genero Genero
        {
            get => _genero;
            set => SetProperty(ref _genero, value);
        }

        public Deporte Deporte
        {
            get => _deporte;
            set => SetProperty(ref _deporte, value);
        }

        public int Ranking
        {
            get => _ranking;
            set => SetProperty(ref _ranking, value);
        }

        public int AniosExperiencia
        {
            get => _aniosexperiencia;
            set => SetProperty(ref _aniosexperiencia, value);
        }

        public int NotaAFA
        {
            get => _notaafa;
            set => SetProperty(ref _notaafa, value);
        }

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public bool? Activo
        {
            get => _activo;
            set => SetProperty(ref _activo, value);
        }

        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }
        public List<BE.Nivel> Niveles
        {
            get => _niveles;
            set => SetProperty(ref _niveles, value);
        }

        public List<BE.Deporte> Deportes
        {
            get => _deportes;
            set => SetProperty(ref _deportes, value);
        }
        
        public Arbitro ArbitroSeleccionado
        {
            get => _arbitroSeleccionado;
            set => SetProperty(ref _arbitroSeleccionado, value);
        }
        #endregion

        public void CargarComboNivel(int idDeporte)
        {
            BLL.Nivel bllNivel = new BLL.Nivel();

            Niveles = bllNivel.ObtenerNivelesPorDeporte(idDeporte);
        }

        public void CargarComboDeportes()
        {
            BLL.Deporte bllDeporte = new BLL.Deporte();

            Deportes = bllDeporte.ObtenerDeportes();
        }

        public bool SeGuardo { get;  set; }

        public Resultado ResultadoAltaModificacion { get;  set; }

        public bool SeCancelo { get;  set; }

        public bool Editar { get;  set; }

        public ICommand RunGuardar { get; }

        public ICommand RunCancelar { get; }

        public ICommand SelectedItemChangedDeporteCommand { get; }


        public AmArbitroViewModel()
        {
            Habilitado = false;
            CargarComboDeportes();
            this.Visibilidad = Visibility.Visible;
            RunGuardar = new RelayCommand(ExecuteRunGuardar);
            RunCancelar = new RelayCommand(ExecuteRunCancelar);
            SelectedItemChangedDeporteCommand = new RelayCommand(ExecuteSelectedItemChangedDeporteCommand);
            
        }

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
                        NotaAFA = NotaAFA,
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
                        NotaAFA = NotaAFA,
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

           // var vieMensaje = new Mensaje(ResultadoAltaModificacion.TipoMensaje, "Árbitro", ResultadoAltaModificacion.Descripcion);


            if (SeGuardo)
            {
                
                var vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Árbitro", "El árbitro se guardo con éxito");

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");
                }

                //DialogHostInstance.IsOpen = false;

                //DialogHost.CloseDialogCommand.Execute(null, null);
                //DialogHost.CloseDialogCommand.Execute(null, null);
            }
            else
            {
                var vieMensaje = new Mensaje(TipoMensaje.ERROR, ResultadoAltaModificacion.Titulo, ResultadoAltaModificacion.Descripcion);

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");

                    DialogHost.CloseDialogCommand.Execute(null,vieMensaje );
                }
            }
            

        }

        private void ExecuteRunCancelar(object obj)
        {
            SeCancelo = true;

            DialogHost.CloseDialogCommand.Execute(null,null);

        }

        private void ExecuteSelectedItemChangedDeporteCommand(object obj)
        {
            if (Deporte != null && Editar == false)
            {
                CargarComboNivel(Deporte.Id);

                Habilitado = true;
            }
           

        }

    }
}
