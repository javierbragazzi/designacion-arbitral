using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DA.SS;
using DA.UI.Principales.Designacion;
using Fecha = DA.BE.Fecha;
using Partido = DA.BE.Partido;

namespace DA.UI.ViewModel
{
    public class Pagina2ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {

        private List<PartidoHelperUI> _partidos;

        private ITransitionerViewModel _previousViewModel;

        public List<PartidoHelperUI> Partidos
        {
            get => _partidos;
            set => SetProperty(ref _partidos, value);
        }

        private List<BE.Arbitro> _arbitros;
        
        public List<BE.Arbitro> Arbitros
        {
            get => _arbitros;
            set => SetProperty(ref _arbitros, value);
        }
        
        private BE.Deporte _deporteSeleccionado;

        public BE.Deporte DeporteSeleccionado
        {
            get => _deporteSeleccionado;
            set => SetProperty(ref _deporteSeleccionado, value);
        }

        private bool _busyArbitro;

        public bool BusyArbitro
        {
            get => _busyArbitro;
            set => SetProperty(ref _busyArbitro, value);
        }

        private bool _busyPartido;

        public bool BusyPartido
        {
            get => _busyPartido;
            set => SetProperty(ref _busyPartido, value);
        }

        private bool _habilitado;

        public bool Habilitado
        {
            get => _habilitado;
            set => SetProperty(ref _habilitado, value);
        }

        public List<BE.Fecha> FechasDisponibles { get; set; }

        public Pagina2ControlViewModel()
        {
            FechasDisponibles = new List<Fecha>();
            Partidos = new List<PartidoHelperUI>();
        }

        public void Hidden(ITransitionerViewModel newViewModel)
        {
            
        }

        public void Shown(ITransitionerViewModel previousViewModel)
        {
            if (_previousViewModel is Pagina1ControlViewModel)
            {
                _previousViewModel = previousViewModel;
                
            }
            
            var task = new Task(CargarVista);
            task.Start();
           // CargarVista(previousViewModel);
        }

        private void CargarVista()
        {
            //Cursor.Current = Cursors.WaitCursor;

            CargarPartidos();

            CargarArbitros();

            //BLL.Arbitro bllArbitro = new BLL.Arbitro();

            //Arbitros = bllArbitro.ObtenerArbitrosConNivel();

            //Cursor.Current = Cursors.Default;
        }

        private void CargarArbitros()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (o, ea) =>
            {

                BLL.Arbitro bllArbitro = new BLL.Arbitro();

                Arbitros = bllArbitro.ObtenerArbitrosConNivel();
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
  
                BusyArbitro = false;
                Habilitado = true;
            };

            Habilitado = false;
            BusyArbitro = true;
            worker.RunWorkerAsync();
        }

        private void CargarPartidos()
        {
            BackgroundWorker worker = new BackgroundWorker();
        
            worker.DoWork += (o, ea) =>
            {
                if (_previousViewModel is Pagina1ControlViewModel)
                {
                    //Partidos = new List<PartidoHelperUI>();

                    Pagina1ControlViewModel pag1Vm = (Pagina1ControlViewModel) _previousViewModel;

                    DeporteSeleccionado = pag1Vm.DeporteSeleccionado;

                    foreach (Fecha fecha in pag1Vm.FechasDisponibles)
                    {
                        foreach (Partido partido in fecha.Partidos)
                        {
                            Partidos.Add(new PartidoHelperUI(partido));
                        }
                    }
                }
        

            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
            
                BusyPartido = false;
            };
    
            BusyPartido = true;
            worker.RunWorkerAsync();
        }
    }
}
