using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DA.BLL;
using DA.SS;
using DA.UI.ABM;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    public class UCCalificacionViewModel : ViewModelBaseLocal
    {
        #region Propiedades

        private SortablePageableCollection<PartidoHelperUI> _partidos;

        public SortablePageableCollection<PartidoHelperUI> Partidos
        {
            get
            {
                return _partidos;
            }
            set
            {
                if (_partidos != value)
                {
                    _partidos = value;
                    SendPropertyChanged(() => Partidos);
                }
            }
        }


        private List<SS.Filtro> _filtros;

        public List<SS.Filtro> Filtros
        {
            get => _filtros;
            set => SetProperty(ref _filtros, value);
        }


        private SS.Filtro _filtroSeleccionado;

        public SS.Filtro FiltroSeleccionado
        {
            get => _filtroSeleccionado;
            set => SetProperty(ref _filtroSeleccionado, value);
        }
        
        private PartidoHelperUI _partidoSeleccionado;

        public PartidoHelperUI PartidoSeleccionado
        {
            get => _partidoSeleccionado;
            set => SetProperty(ref _partidoSeleccionado, value);
        }
        
        private Visibility _visibilidad;

        public Visibility Visibilidad
        {
            get => _visibilidad;
            set => SetProperty(ref _visibilidad, value);
        }

        private bool _habilitado;

        public bool Habilitado
        {
            get => _habilitado;
            set => SetProperty(ref _habilitado, value);
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

        public ICommand SelectedPartidoChangedCommand { get; private set; }

        public ICommand RunCargarCalificacion { get; private set; }


        #endregion

        public UCCalificacionViewModel()
        {
            CargarComboFiltros();
            Visibilidad = Visibility.Collapsed;

            GoToNextPageCommand = new RelayCommand(a => Partidos.GoToNextPage());
            GoToPreviousPageCommand = new RelayCommand(a => Partidos.GoToPreviousPage());
            CleanCommand = new RelayCommand(ExecuteCleanCommand);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
            SelectedPartidoChangedCommand = new RelayCommand(ExecuteSelectedPartidoChangedCommand);
            RunCargarCalificacion = new RelayCommand(ExecuteRunCargarCalificacion);


        }

        private void CargarComboFiltros()
        {
            Filtros = new List<Filtro>();
            Filtros.Add(new Filtro(){Id = 1, Descripcion = "Sin calificación"});
            Filtros.Add(new Filtro(){Id = 2, Descripcion = "Con calificación"});
        }

        private async void ExecuteRunCargarCalificacion(object obj)
        {
            BLL.PartidoArbitro bllPartidoArbitro = new PartidoArbitro();
            List<BE.PartidoArbitro> partidoArbitros = bllPartidoArbitro.ObtenerPartidoArbitroPorPartidoId(PartidoSeleccionado.Id);

            AmCalificacionViewModel viewModel = new AmCalificacionViewModel(PartidoSeleccionado.ConvertirAPartido(), partidoArbitros);

            var view = new AmCalificacion
            {
                DataContext = viewModel
            };
            
     
            var result = await DialogHost.Show(view, "RootDialog");

            viewModel = (AmCalificacionViewModel)view.DataContext;

            if (viewModel.SeGuardo)
            {
                CargarListaPartidos();

            }

        }
  
        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            CargarListaPartidos();
        }

        private void CargarListaPartidos()
        {
            if (FiltroSeleccionado != null)
            {
                BLL.Partido bllPartido = new Partido();

                if (FiltroSeleccionado.Id == 1)
                    Partidos = new SortablePageableCollection<PartidoHelperUI>(bllPartido.ObtenerPartidosSinCalificacion());
                else
                    Partidos = new SortablePageableCollection<PartidoHelperUI>(bllPartido.ObtenerPartidosConCalificacion());


                Visibilidad = Visibility.Visible;
            }
        }

        private void ExecuteSelectedPartidoChangedCommand(object obj)
        {
            Habilitado = PartidoSeleccionado != null;
        }
        
        public void ExecuteCleanCommand(object obj)
        {
           Limpiar();
      
        }

        private void Limpiar()
        {
            FiltroSeleccionado = null;
            Partidos = null;
            Visibilidad = Visibility.Collapsed;
        }

    }
}
