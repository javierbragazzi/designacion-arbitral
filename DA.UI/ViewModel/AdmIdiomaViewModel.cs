using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DA.BE;
using DA.SS;
using DA.UI.ABM;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;
using Leyenda = DA.BE.Leyenda;

namespace DA.UI.ViewModel
{
    public class AdmIdiomaViewModel : ViewModelBaseLocal
    {
        private Visibility _visibilidad;

        public Visibility Visibilidad
        {
            get => _visibilidad;
            set => SetProperty(ref _visibilidad, value);
        }

        public AdmIdiomaViewModel()
        {
            CargarComboIdiomas();
            Visibilidad = Visibility.Collapsed;

            //ColeccionLeyenda = new SortablePageableCollection<BE.Leyenda>(_coleccionCompleta);
            //ListaTipoEventos = new ObservableCollection<string>(ObtenerTiposEventos());
            GoToNextPageCommand = new RelayCommand(a => ColeccionLeyenda.GoToNextPage());
            GoToPreviousPageCommand = new RelayCommand(a => ColeccionLeyenda.GoToPreviousPage());
            CleanCommand = new RelayCommand(ExecuteCleanCommand);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
            RunAltaIdioma = new RelayCommand(ExecuteRunAltaIdioma);
            RunGuardarIdioma = new RelayCommand(ExecuteRunGuardarIdioma);
            RunEliminarIdioma = new RelayCommand(ExecuteRunEliminarIdioma);

        }

        private async void ExecuteRunEliminarIdioma(object obj)
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();
            Mensaje vieMensaje = null;
     

            if (IdiomaSeleccionado != null)
            {
                
                MensajeConsulta mensajeConsulta = new MensajeConsulta();

                object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");
            
                Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
                switch (respuesta)
                {
                    case Respuesta.Si:
                    {

                        Resultado resultado = bllIdioma.Quitar(IdiomaSeleccionado);

                        if (resultado.HayError == false)
                        {
                            vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Baja de Idioma",
                                "Se elimino el idioma seleccionado");
                            CargarComboIdiomas();
                            Limpiar();
                        }
                        else
                            vieMensaje = new Mensaje(TipoMensaje.ERROR, "Baja de Idioma",
                                "El idioma no pudo ser eliminado");
                    } 
                    break;
      
                }
              
            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Eliminar Idioma", "Debe seleccionar un idioma");


            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        private async void ExecuteRunGuardarIdioma(object obj)
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();
            Mensaje vieMensaje = null;
     

            if (IdiomaSeleccionado != null)
            {
                
                MensajeConsulta mensajeConsulta = new MensajeConsulta( );

                object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");
            
                Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
                switch (respuesta)
                {
                    case Respuesta.Si:
                    {
                        IdiomaSeleccionado.Leyendas.Clear();
                        IdiomaSeleccionado.Leyendas = (List<Leyenda>) ColeccionLeyenda.GetAllObjects();
                        Resultado resultado = bllIdioma.Editar(IdiomaSeleccionado);

                        if (resultado.HayError == false)
                        {
                            vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Edición de Idioma",
                                "Se editó el idioma seleccionado");
                            CargarComboIdiomas();
                            Limpiar();
                        }
                        else
                            vieMensaje = new Mensaje(TipoMensaje.ERROR, "Edición de Idioma",
                                "El idioma no pudo ser editado");
                    } 
                        break;
      
                }
              
            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Eliminar Idioma", "Debe seleccionar un idioma");


            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }

        }

        private void CargarComboIdiomas()
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();

            Idiomas = bllIdioma.ObtenerIdiomas();
        }

        private async void ExecuteRunAltaIdioma(object obj)
        {
            var view = new AltaIdioma
            {
                DataContext = new AltaIdiomaViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog");

            AltaIdiomaViewModel viewModel = (AltaIdiomaViewModel)view.DataContext;

            if (viewModel.SeGuardo)
            {
                CargarComboIdiomas();
                ColeccionLeyenda = null;

                foreach (Idioma idioma in Idiomas)
                {
                    if (idioma.Descripcion.Equals(viewModel.NombreIdioma))
                    {
                        IdiomaSeleccionado = idioma;
                        break;
                    }
                }

            }

        }

        #region Propiedades

        private SortablePageableCollection<BE.Leyenda> _coleccionLeyenda;

        public SortablePageableCollection<BE.Leyenda> ColeccionLeyenda
        {
            get
            {
                return _coleccionLeyenda;
            }
            set
            {
                if (_coleccionLeyenda != value)
                {
                    _coleccionLeyenda = value;
                    SendPropertyChanged(() => ColeccionLeyenda);
                }
            }
        }

        private List<BE.Idioma> _idiomas;

        public List<BE.Idioma> Idiomas
        {
            get => _idiomas;
            set => SetProperty(ref _idiomas, value);
        }

        private BE.Idioma _idiomaSeleccionado;

        public BE.Idioma IdiomaSeleccionado
        {
            get => _idiomaSeleccionado;
            set => SetProperty(ref _idiomaSeleccionado, value);
        }
        
        public List<int> EntriesPerPageList
        {
            get
            {
                return new List<int>() { 5, 10, 15 };
            }
        }
       
        #endregion

        #region Commands

        public ICommand GoToNextPageCommand { get; private set; }

        public ICommand GoToPreviousPageCommand { get; private set; }

        public ICommand CleanCommand { get; private set; }

        public ICommand SelectedItemChangedCommand { get; private set; }

        public ICommand RunAltaIdioma { get; private set; }
       
        public ICommand RunGuardarIdioma { get; private set; }
       
        public ICommand RunEliminarIdioma { get; private set; }
        

        #endregion
        
        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            if (IdiomaSeleccionado != null && IdiomaSeleccionado.Leyendas != null)
            {
                ColeccionLeyenda = new SortablePageableCollection<Leyenda>(IdiomaSeleccionado.Leyendas);

                Visibilidad = Visibility.Visible;
            }
           

        }

        public void ExecuteCleanCommand(object obj)
        {
           Limpiar();
      
        }

        private void Limpiar()
        {
            IdiomaSeleccionado = null;
            ColeccionLeyenda = null;
            Visibilidad = Visibility.Collapsed;
        }

    }
}
