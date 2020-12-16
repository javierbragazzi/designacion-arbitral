using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DA.SS;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;
using Situacion = DA.BE.Situacion;

namespace DA.UI.ViewModel
{
    public class UCPromocionDescensoViewModel : ViewModelBaseLocal
    {
        private bool _busyIndicator;

        public bool BusyIndicator
        {
            get => _busyIndicator;
            set => SetProperty(ref _busyIndicator, value);
        }

        private bool _habilitadoGuardar;

        public bool HabilitadoGuardar
        {
            get => _habilitadoGuardar;
            set => SetProperty(ref _habilitadoGuardar, value);
        }

        private bool _habilitadoBorrar;

        public bool HabilitadoBorrar
        {
            get => _habilitadoBorrar;
            set => SetProperty(ref _habilitadoBorrar, value);
        }

        private bool _habilitadoCalcular;

        public bool HabilitadoCalcular
        {
            get => _habilitadoCalcular;
            set => SetProperty(ref _habilitadoCalcular, value);
        }

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

        private async void ExecuteRunGuardar(object obj)
        {

            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            Mensaje vieMensaje = null;
            
            MensajeConsulta mensajeConsulta = new MensajeConsulta();

            object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");

            Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
            switch (respuesta)
            {
                case Respuesta.Si:
                    Resultado resultado = new Resultado(false,"");
                    
                    foreach (BE.Puntaje puntaje in Puntajes.GetAllObjects())
                    {
                        resultado = puntaje.IdNivelNuevo == -1 ? bllPuntaje.ActualizarProcesado(puntaje) : bllPuntaje.ActualizarNuevoNivel(puntaje);
                       
                        if (puntaje.Situacion == Situacion.Baja)
                            resultado = bllPuntaje.ActualizarBaja(puntaje);
                        
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

        private void ExecuteRunBorrar(object obj)
        {
            Puntajes = null;
            HabilitadoGuardar = false;
        }

        private void ExecuteRunCalcular(object obj)
        {
            CargaGrillaPuntajes();
            HabilitadoCalcular = false;
            HabilitadoGuardar = true;
            HabilitadoBorrar = true;
        }

        private void CargaGrillaPuntajes()
        {
            Puntajes = null;
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();

            Puntajes = new SortablePageableCollection<BE.Puntaje>(bllPuntaje.ObtenerPuntajeDeTemporada());

            if (Puntajes.GetAllObjects().Count != 0)
            {
                HabilitadoCalcular = true;
            }
            else
            {
                HabilitadoCalcular = false;
            }

        }


        #region Propiedades

     
        private SortablePageableCollection<BE.Puntaje> _puntajes;

        public SortablePageableCollection<BE.Puntaje> Puntajes
        {
            get => _puntajes;
            set => SetProperty(ref _puntajes, value);
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

        public ICommand RunGuardar { get; private set; }
        
        public ICommand RunBorrar { get; private set; }

        public ICommand RunCalcular { get; private set; }



        #endregion


        public void ExecuteCleanCommand(object obj)
        {
           Limpiar();
      
        }

        private void Limpiar()
        {

            Puntajes = null;
        }


    }
}
