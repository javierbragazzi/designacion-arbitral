using DA.BE;
using DA.SS;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DA.UI.ViewModel
{
    public class UCAsignarNivelesViewModel : ViewModelBaseLocal
    {
        private Visibility _visibilidad;

        public Visibility Visibilidad
        {
            get => _visibilidad;
            set => SetProperty(ref _visibilidad, value);
        }

        public UCAsignarNivelesViewModel()
        {
            CargarArbitros();
            CargarNiveles();
            Visibilidad = Visibility.Collapsed;

            GoToNextPageCommand = new RelayCommand(a => ColeccionArbitros.GoToNextPage());
            GoToPreviousPageCommand = new RelayCommand(a => ColeccionArbitros.GoToPreviousPage());
            CleanCommand = new RelayCommand(ExecuteCleanCommand);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
            RunAsignarNiveles = new RelayCommand(ExecuteRunAsignarNiveles);

        }

        private void CargarArbitros()
        {
            BLL.Arbitro bllArbitro = new BLL.Arbitro();

            Arbitros = bllArbitro.ObtenerArbitrosReducido();
        }

        private void CargarNiveles()
        {
            BLL.Nivel bllNivel = new BLL.Nivel();
            Niveles = bllNivel.ObtenerNiveles();
            Niveles.Add(new Nivel() { NombreNivel="Sin nivel" });
        }

        private async void ExecuteRunAsignarNiveles(object obj)
        {
            BLL.Nivel _nivelBLL = new BLL.Nivel();
            Mensaje vieMensaje = null;
            if (_nivelBLL.AsignarNiveles(ArbitrosFiltrados))
            {
                vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Niveles Asignados", "Operacion finalizada correctamente");
            }else
            {
                vieMensaje = new Mensaje(TipoMensaje.ERROR, "Niveles No Asignados", "Operacion finalizada con errores");
            }

            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }

            Limpiar();
        }

        #region Propiedades

        private SortablePageableCollection<BE.Arbitro> _coleccionArbitros;

        public SortablePageableCollection<BE.Arbitro> ColeccionArbitros
        {
            get
            {
                return _coleccionArbitros;
            }
            set
            {
                if (_coleccionArbitros != value)
                {
                    _coleccionArbitros = value;
                    SendPropertyChanged(() => ColeccionArbitros);
                }
            }
        }

        private SortablePageableCollection<BE.Nivel> _coleccionNiveles;

        public SortablePageableCollection<BE.Nivel> ColeccionNiveles
        {
            get
            {
                return _coleccionNiveles;
            }
            set
            {
                if (_coleccionNiveles != value)
                {
                    _coleccionNiveles = value;
                    SendPropertyChanged(() => ColeccionNiveles);
                }
            }
        }

        private List<BE.Arbitro> _arbitro;
        private List<BE.Arbitro> _arbitrosFiltrados;

        public List<BE.Arbitro> Arbitros
        {
            get => _arbitro;
            set => SetProperty(ref _arbitro, value);
        }

        public List<BE.Arbitro> ArbitrosFiltrados
        {
            get => _arbitrosFiltrados;
            set => SetProperty(ref _arbitrosFiltrados, value);
        }

        private List<BE.Nivel> _nivel;

        public List<BE.Nivel> Niveles
        {
            get => _nivel;
            set => SetProperty(ref _nivel, value);
        }

        private BE.Arbitro _arbitroSeleccionado;

        public BE.Arbitro ArbitroSeleccionado
        {
            get => _arbitroSeleccionado;
            set => SetProperty(ref _arbitroSeleccionado, value);
        }

        private BE.Nivel _nivelSeleccionado;

        public BE.Nivel NivelSeleccionado
        {
            get => _nivelSeleccionado;
            set => SetProperty(ref _nivelSeleccionado, value);
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

        public ICommand RunAsignarNiveles { get; private set; }




        #endregion

        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            if (NivelSeleccionado != null && NivelSeleccionado.NombreNivel != null)
            {
                ColeccionNiveles = new SortablePageableCollection<Nivel>(Niveles);
                ArbitrosFiltrados = Arbitros.Where(arbitro => arbitro?.Nivel?.Id == NivelSeleccionado.Id).ToList();
                ColeccionArbitros = new SortablePageableCollection<Arbitro>(ArbitrosFiltrados);
                if (NivelSeleccionado.NombreNivel == "Sin nivel")
                {
                    ArbitrosFiltrados = Arbitros.Where(arbitro => arbitro.Nivel == null).ToList();
                    ColeccionArbitros = new SortablePageableCollection<Arbitro>(ArbitrosFiltrados);
                }
                Visibilidad = Visibility.Visible;
            }

        }

        public void ExecuteCleanCommand(object obj)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            ArbitroSeleccionado = null;
            ColeccionArbitros = null;
            Visibilidad = Visibility.Collapsed;
        }

    }
}
