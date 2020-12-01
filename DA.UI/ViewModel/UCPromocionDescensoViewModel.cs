using System.Collections.Generic;
using System.ComponentModel;
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

        private bool _habilitado;

        public bool Habilitado
        {
            get => _habilitado;
            set => SetProperty(ref _habilitado, value);
        }


        public UCPromocionDescensoViewModel()
        { 
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (o, ea) =>
            {
                CargaGrillaPuntajes();

                GoToNextPageCommand = new RelayCommand(a => Puntajes.GoToNextPage());
                GoToPreviousPageCommand = new RelayCommand(a => Puntajes.GoToPreviousPage());
                CleanCommand = new RelayCommand(ExecuteCleanCommand);
                RunGuardar = new RelayCommand(ExecuteRunGuardar);


            };
            worker.RunWorkerCompleted += (o, ea) =>
            {

                BusyIndicator = false;
              
            };
       
            BusyIndicator = true;
            worker.RunWorkerAsync();

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
  
          //  vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Promoción / Descenso", "Debe seleccionar un Arbitro");

        if (vieMensaje != null)
        {
            var resul = await DialogHost.Show(vieMensaje, "dhMensajes");
        }




        }

        private void CargaGrillaPuntajes()
        {
            Puntajes = null;
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();

            Puntajes = new SortablePageableCollection<BE.Puntaje>(bllPuntaje.ObtenerPuntajeDeTemporada());

            if (Puntajes.GetAllObjects().Count != 0)
            {
                Habilitado = true;
            }
            else
            {
                Habilitado = false;
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
