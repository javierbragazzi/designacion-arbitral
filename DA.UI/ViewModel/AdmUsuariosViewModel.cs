using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using DA.SS;
using DA.UI.ABM;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    /// <summary>
    /// ViewModel para la pantalla AdmUsuarios
    /// </summary>
    /// <seealso cref="ViewModelBaseLocal" />
    public class AdmUsuariosViewModel : ViewModelBaseLocal
    {
       private bool _busyIndicator;


        public bool BusyIndicator
        {
            get => _busyIndicator;
            set => SetProperty(ref _busyIndicator, value);
        }

        public AdmUsuariosViewModel()
        { 
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (o, ea) =>
            {
                CargarGrillaUsuarios();

                GoToNextPageCommand = new RelayCommand(a => Usuarios.GoToNextPage());
                GoToPreviousPageCommand = new RelayCommand(a => Usuarios.GoToPreviousPage());
                CleanCommand = new RelayCommand(ExecuteCleanCommand);
                RunAlta = new RelayCommand(ExecuteRunAlta);
                RunEditar = new RelayCommand(ExecuteRunEditar);
                RunEliminar = new RelayCommand(ExecuteRunEliminar);

            };
            worker.RunWorkerCompleted += (o, ea) =>
            {

                BusyIndicator = false;
              
            };
       
            BusyIndicator = true;
            worker.RunWorkerAsync();

        }

        private async void ExecuteRunEliminar(object obj)
        {
            BLL.Usuario bllUsuario = new BLL.Usuario();
            Mensaje vieMensaje = null;


            if (UsuarioSeleccionado != null)
            {
                if (UsuarioSeleccionado.NombreUsuario.Equals(ManejadorSesion.Instancia.ObtenerSesion().Usuario
                    .NombreUsuario))
                {
                    vieMensaje = new Mensaje(TipoMensaje.ERROR,
                        SingletonIdioma.Instancia.ObtenerTraduccion("TituloOperacion"),
                        SingletonIdioma.Instancia.ObtenerTraduccion("MenUsuarioActual"));

                }
                else
                {

                    MensajeConsulta mensajeConsulta = new MensajeConsulta();

                    object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");

                    Respuesta respuesta = (Respuesta) (resultadoConsulta ?? Respuesta.Nada);
                    switch (respuesta)
                    {
                        case Respuesta.Si:
                        {

                            ResultadoBd resultado = bllUsuario.Quitar(UsuarioSeleccionado);

                            if (resultado != ResultadoBd.ERROR)
                            {
                                vieMensaje = new Mensaje(TipoMensaje.CORRECTO,
                                    SingletonIdioma.Instancia.ObtenerTraduccion("TituloOperacion"),
                                    SingletonIdioma.Instancia.ObtenerTraduccion("OperacionOk"));
                            }
                            else
                                vieMensaje = new Mensaje(TipoMensaje.ERROR,
                                    SingletonIdioma.Instancia.ObtenerTraduccion("TituloOperacion"),
                                    SingletonIdioma.Instancia.ObtenerTraduccion("OperacionError"));

                            Limpiar();
                            CargarGrillaUsuarios();
                        }
                            break;

                    }
                }
            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, SingletonIdioma.Instancia.ObtenerTraduccion("TituloOperacion"), SingletonIdioma.Instancia.ObtenerTraduccion("MenSeleccionarUsu"));


            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        private void CargarGrillaUsuarios()
        {
            Usuarios = null;
            BLL.Usuario bllUsuario = new BLL.Usuario();

            Usuarios = new SortablePageableCollection<BE.Usuario>(bllUsuario.ObtenerUsuarios());

        }

        private async void ExecuteRunAlta(object obj)
        {

            AmUsuario frmAmUsuario = new AmUsuario();

            //AmArbitroViewModel viewModel = (AmArbitroViewModel)view.DataContext;
            AmUsuarioViewModel viewModel = new AmUsuarioViewModel();

            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Id = 0;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Nombre = string.Empty;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Apellido = string.Empty;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Ranking = 0;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).AniosExperiencia = 0;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).NotaAFA = 0;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Genero = string.Empty;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).DNI = string.Empty;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Activo = true;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).FechaNacimiento = DateTime.Now;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).TituloValidoArgentina = false;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).LicenciaInternacional = false;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).ExamenTeorico = false;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).ExamenFisico = false;

            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Nivel = null;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Deporte = null;

            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Visibilidad = Visibility.Visible;
            //((AmArbitroViewModel)viewModelAmArbitro.DataContext).Titulo = "Alta de Arbitro";

            frmAmUsuario.DataContext = viewModel;

            await DialogHost.Show(frmAmUsuario, "RootDialog");

            if (viewModel.SeCancelo && viewModel.SeGuardo)
            {
                Limpiar();
                CargarGrillaUsuarios();
            }


        }

        private async void ExecuteRunEditar(object obj)
        {
            //Mensaje vieMensaje = null;

            //AmArbitro frmAmArbitro = new AmArbitro();

            //if (UsuarioSeleccionado != null)
            //{
            //    AmArbitroViewModel viewModelAmArbitro = new AmArbitroViewModel();

                

            //    viewModelAmArbitro.Titulo = "Editar Árbitro";
            //    viewModelAmArbitro.ArbitroSeleccionado = UsuarioSeleccionado;
        
            //    viewModelAmArbitro.Id = UsuarioSeleccionado.Id;
            //    viewModelAmArbitro.Nombre = UsuarioSeleccionado.Nombre;
            //    viewModelAmArbitro.Apellido = UsuarioSeleccionado.Apellido;
            //    viewModelAmArbitro.Ranking = UsuarioSeleccionado.Ranking;
            //    viewModelAmArbitro.AniosExperiencia = UsuarioSeleccionado.AniosExperiencia;
            //    viewModelAmArbitro.NotaAFA = UsuarioSeleccionado.NotaAFA;
            //    viewModelAmArbitro.LicenciaInternacional = UsuarioSeleccionado.LicenciaInternacional;
            //    viewModelAmArbitro.Genero = UsuarioSeleccionado.Genero;
            //    viewModelAmArbitro.DNI = UsuarioSeleccionado.DNI;
            //    viewModelAmArbitro.Activo = UsuarioSeleccionado.Estado;
            //    viewModelAmArbitro.FechaNacimiento = UsuarioSeleccionado.FechaNacimiento;

            //    viewModelAmArbitro.TituloValidoArgentina = UsuarioSeleccionado.TituloValidoArgentina;
            //    viewModelAmArbitro.ExamenTeorico = UsuarioSeleccionado.ExamenTeorico;
            //    viewModelAmArbitro.ExamenFisico = UsuarioSeleccionado.ExamenFisico;

            //    viewModelAmArbitro.CargarComboDeportes();
            //    viewModelAmArbitro.Deporte = UsuarioSeleccionado.Deporte;
            //    viewModelAmArbitro.Habilitado = true;
            //    viewModelAmArbitro.CargarComboNivel(UsuarioSeleccionado.Deporte.Id);
            //    viewModelAmArbitro.Nivel = UsuarioSeleccionado.Nivel;
            //    viewModelAmArbitro.Visibilidad = Visibility.Visible;

            //    viewModelAmArbitro.Editar = true;

            //    frmAmArbitro.DataContext = viewModelAmArbitro;

            //    //show the dialog
            //    var result = await DialogHost.Show(frmAmArbitro, "RootDialog");

            //    if (viewModelAmArbitro.SeCancelo == false)
            //    {
            //        if (viewModelAmArbitro.SeGuardo)
            //        {
            //            Limpiar();
            //            CargarGrillaUsuarios();
            //            vieMensaje = new Mensaje(viewModelAmArbitro.TipoMensaje, "Edición de Arbitro",
            //                "Se editó el Arbitro seleccionado");
            //        }
            //        else
            //        {
            //            vieMensaje = new Mensaje(viewModelAmArbitro.TipoMensaje, "Edición de Arbitro",
            //                "El Arbitro no pudo ser editado");
            //        }
            //    }

            //}
            //else
            //    vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Editar Arbitro", "Debe seleccionar un Arbitro");

            //if (vieMensaje != null)
            //{
            //    var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            //}


        }

        #region Propiedades

        private SortablePageableCollection<BE.Usuario> _usuarios;

        public SortablePageableCollection<BE.Usuario> Usuarios
        {
            get
            {
                return _usuarios;
            }
            set
            {
                if (_usuarios != value)
                {
                    _usuarios = value;
                    SendPropertyChanged(() => Usuarios);
                }
            }
        }

        private BE.Usuario _usuariosSeleccionado;

        public BE.Usuario UsuarioSeleccionado
        {
            get => _usuariosSeleccionado;
            set => SetProperty(ref _usuariosSeleccionado, value);
        }
        
        public List<int> EntriesPerPageList
        {
            get
            {
                return new List<int>() { 5, 10, 15, 20 };
            }
        }
       
        #endregion

        #region Commands

        public ICommand GoToNextPageCommand { get; private set; }

        public ICommand GoToPreviousPageCommand { get; private set; }

        public ICommand CleanCommand { get; private set; }

        public ICommand RunAlta { get; private set; }

        public ICommand RunEditar { get; private set; }

        public ICommand RunEliminar { get; private set; }


        #endregion


        public void ExecuteCleanCommand(object obj)
        {
           Limpiar();
      
        }

        private void Limpiar()
        {
            UsuarioSeleccionado = null;
            Usuarios = null;
        }
    }
}
