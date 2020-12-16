using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DA.BE;
using DA.SS;
using DA.UI.ABM;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    public class AdmArbitroViewModel : ViewModelBaseLocal
    {
        private bool _busyIndicator;
        
        public bool BusyIndicator
        {
            get => _busyIndicator;
            set => SetProperty(ref _busyIndicator, value);
        }

        private readonly AmArbitro _viewModelAmArbitro;

        public AdmArbitroViewModel()
        { 
            
            _viewModelAmArbitro = new AmArbitro()
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

        private void CargaGrillaArbitro()
        {
            ColeccionArbitro = null;
            BLL.Arbitro blllArbitro = new BLL.Arbitro();

            Arbitros = blllArbitro.ObtenerArbitrosReducido();

            ColeccionArbitro = new SortablePageableCollection<BE.Arbitro>(Arbitros);
        }

        private async void ExecuteRunAltaArbitro(object obj)
        {
            AmArbitroViewModel viewModel = (AmArbitroViewModel)_viewModelAmArbitro.DataContext;
            viewModel.SeCancelo = true;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Id = 0;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Nombre = string.Empty;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Apellido = string.Empty;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Ranking = 0;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).AniosExperiencia = 0;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).NotaAFA = 0;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Genero = Genero.MASCULINO;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).DNI = string.Empty;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Activo = true;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).FechaNacimiento = DateTime.Now;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).TituloValidoArgentina = false;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).LicenciaInternacional = false;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).ExamenTeorico = false;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).ExamenFisico = false;

            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Nivel = null;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Deporte = null;

            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Visibilidad = Visibility.Visible;
            ((AmArbitroViewModel)_viewModelAmArbitro.DataContext).Titulo = "Alta de árbitro";

            await DialogHost.Show(_viewModelAmArbitro, "RootDialog");

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
                viewModelAmArbitro.NotaAFA = ArbitroSeleccionado.NotaAFA;
                viewModelAmArbitro.LicenciaInternacional = ArbitroSeleccionado.PoseeLicenciaInternacional;
                viewModelAmArbitro.Genero = ArbitroSeleccionado.Genero;
                viewModelAmArbitro.DNI = ArbitroSeleccionado.DNI;
                viewModelAmArbitro.Activo = ArbitroSeleccionado.Habilitado;
                viewModelAmArbitro.FechaNacimiento = ArbitroSeleccionado.FechaNacimiento;

                viewModelAmArbitro.TituloValidoArgentina = ArbitroSeleccionado.PoseeTituloValidoArgentina;
                viewModelAmArbitro.ExamenTeorico = ArbitroSeleccionado.ExamenTeoricoAprobado;
                viewModelAmArbitro.ExamenFisico = ArbitroSeleccionado.ExamenFisicoAprobado;

                viewModelAmArbitro.CargarComboDeportes();
                viewModelAmArbitro.CargarComboGeneros();
                viewModelAmArbitro.Deporte = ArbitroSeleccionado.Deporte;
                viewModelAmArbitro.Habilitado = true;
                viewModelAmArbitro.CargarComboNivel(ArbitroSeleccionado.Deporte.Id);
                viewModelAmArbitro.Nivel = ArbitroSeleccionado.Nivel;
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

        #region Propiedades

        private SortablePageableCollection<BE.Arbitro> _coleccionArbitro;

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

        private List<BE.Arbitro> _arbitros;

        public List<BE.Arbitro> Arbitros
        {
            get => _arbitros;
            set => SetProperty(ref _arbitros, value);
        }

        private BE.Arbitro _arbitroSeleccionado;

        public BE.Arbitro ArbitroSeleccionado
        {
            get => _arbitroSeleccionado;
            set => SetProperty(ref _arbitroSeleccionado, value);
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

        public ICommand RunAltaArbitro { get; private set; }

        public ICommand RunEditarArbitro { get; private set; }

        public ICommand RunGuardarArbitro { get; private set; }
       
        public ICommand RunEliminarArbitro { get; private set; }


        #endregion


        public void ExecuteCleanCommand(object obj)
        {
           Limpiar();
      
        }

        private void Limpiar()
        {
            ArbitroSeleccionado = null;
            ColeccionArbitro = null;
        }

    }
}
