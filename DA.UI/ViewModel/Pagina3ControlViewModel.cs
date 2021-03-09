using System.Collections.Generic;
using System.Windows.Forms;
using DA.BE;
using DA.SS;
using DA.UI.Principales.Designacion;

namespace DA.UI.ViewModel
{
    public class Pagina3ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {
        private List<PartidoHelperUI> _partidosDesignados;
        
        public List<PartidoHelperUI> PartidosDesignados
        {
            get => _partidosDesignados;
            set => SetProperty(ref _partidosDesignados, value);
        }

        public List<BE.Fecha> FechasDisponibles { get; set; }

        public Pagina3ControlViewModel()
        {
            FechasDisponibles = new List<Fecha>();
            PartidosDesignados = new List<PartidoHelperUI>();
        }

        public void Hidden(ITransitionerViewModel newViewModel)
        {
            
        }

        public void Shown(ITransitionerViewModel previousViewModel)
        {
            Pagina2ControlViewModel pag2Vm = (Pagina2ControlViewModel)previousViewModel;

            FechasDisponibles = pag2Vm.FechasDisponibles;

            Cursor.Current = Cursors.WaitCursor;
            BLL.Designacion business = new BLL.Designacion();

            PartidosDesignados = business.RealizarDesignacion(pag2Vm.Partidos, pag2Vm.Arbitros, pag2Vm.DeporteSeleccionado);


            Cursor.Current = Cursors.Default;


        }
    }

}
