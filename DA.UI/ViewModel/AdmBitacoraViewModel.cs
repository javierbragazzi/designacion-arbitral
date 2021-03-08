using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DA.UI.Command;
using DA.UI.DataGrid;

namespace DA.UI.ViewModel
{
    public class AdmBitacoraViewModel : ViewModelBaseLocal
    {
        public AdmBitacoraViewModel()
        {
            BLL.Bitacora bllBitacora = new BLL.Bitacora();
            FechaDesde = DateTime.Now;
            FechaHasta = DateTime.Now;
            _coleccionCompleta = bllBitacora.ObtenerBitacoras();

            ColeccionBitacora = new SortablePageableCollection<BE.Bitacora>(_coleccionCompleta);
            //ListaTipoEventos = new ObservableCollection<string>(ObtenerTiposEventos());
            GoToNextPageCommand = new RelayCommand(a => ColeccionBitacora.GoToNextPage());
            GoToPreviousPageCommand = new RelayCommand(a => ColeccionBitacora.GoToPreviousPage());

        }

        #region Propiedades

        private SortablePageableCollection<BE.Bitacora> _coleccionBitacora;

        private readonly List<BE.Bitacora> _coleccionCompleta;

        public SortablePageableCollection<BE.Bitacora> ColeccionBitacora
        {
            get
            {
                return _coleccionBitacora;
            }
            set
            {
                if (_coleccionBitacora != value)
                {
                    _coleccionBitacora = value;
                    SendPropertyChanged(() => ColeccionBitacora);
                }
            }
        }

        //private ObservableCollection<string> _listaTipoEventos;

        //public ObservableCollection<string> ListaTipoEventos
        //{
        //    get
        //    {
        //        return _listaTipoEventos;
        //    }
        //    set
        //    {
        //        if (_listaTipoEventos != value)
        //        {
        //            _listaTipoEventos = value;
        //            SendPropertyChanged(() => ListaTipoEventos);
        //        }
        //    }
        //}

        private string _nombreUsuario;

        public string NombreUsuario
        {
            get => _nombreUsuario;
            set => SetProperty(ref _nombreUsuario, value);
        }

        private string _descripcion;

        public string Descripcion
        {
            get => _descripcion;
            set => SetProperty(ref _descripcion, value);
        }
        
        private string _tipoEventoSeleccionado;

        public string TipoEventoSeleccionado
        {
            get => _tipoEventoSeleccionado;
            set => SetProperty(ref _tipoEventoSeleccionado, value);
        }

        private DateTime _fechaDesde;

        public DateTime FechaDesde
        {
            get => _fechaDesde;
            set => SetProperty(ref _fechaDesde, value);
        }

        private DateTime _fechaHasta;

        public DateTime FechaHasta
        {
            get => _fechaHasta;
            set => SetProperty(ref _fechaHasta, value);
        }

        #endregion

        #region Commands

        public ICommand GoToNextPageCommand { get; private set; }

        public ICommand GoToPreviousPageCommand { get; private set; }

        public ICommand SearchCommand => new DelegateCommand(ExecuteSearchCommand);

        public ICommand CleanCommand => new DelegateCommand(ExecuteCleanCommand);

        #endregion
        
        public List<int> EntriesPerPageList
        {
            get
            {
                return new List<int>() { 5, 10, 15 };
            }
        }
        
        public List<string> TiposDeEventos
        {
            get
            {
                return new List<string>() { "", "MENSAJE", "ADVERTENCIA", "ERROR", "ALTA", "BAJA", "MODIFICACION" };
            }


        }

        private void ExecuteSearchCommand(object obj)
        {

            IEnumerable<BE.Bitacora> bitacoraFiltrada =
                                            from bitacora in _coleccionCompleta
                                            where (NombreUsuario == null || bitacora.Usuario.NombreUsuario.ToLowerInvariant().Contains(NombreUsuario.ToLowerInvariant()) 
                                               && (Descripcion == null || bitacora.Descripcion.ToLowerInvariant().Contains(Descripcion.ToLowerInvariant())))
                                               && (TipoEventoSeleccionado == null || bitacora.TipoEvento.Descripcion.ToString().ToLowerInvariant().Contains(TipoEventoSeleccionado.ToLowerInvariant()))
                                               && (bitacora.Fecha.Date >= FechaDesde.Date &&  bitacora.Fecha.Date <= FechaHasta.Date)
                                            select bitacora;
    
            ColeccionBitacora = new SortablePageableCollection<BE.Bitacora>(bitacoraFiltrada);
        }    
        
        public void ExecuteCleanCommand(object obj)
        {
            NombreUsuario = "";
            Descripcion = "";
            TipoEventoSeleccionado = "";
            ColeccionBitacora = new SortablePageableCollection<BE.Bitacora>(_coleccionCompleta);
            //FechaDesde = null;
        }

    }
}
