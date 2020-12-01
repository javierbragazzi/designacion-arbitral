using System.Collections.Generic;
using System.Windows.Forms;
using DA.BE;
using DA.UI.Principales.Designacion;
using GalaSoft.MvvmLight;

namespace DA.UI.ViewModel
{
    public class Pagina3ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {
        private List<BE.Partido> _partidosDesignados;
        
        public List<BE.Partido> PartidosDesignados
        {
            get => _partidosDesignados;
            set => SetProperty(ref _partidosDesignados, value);
        }


        public Pagina3ControlViewModel()
        {
            PartidosDesignados = new List<Partido>();
        }

        public void Hidden(ITransitionerViewModel newViewModel)
        {
            
        }

        public void Shown(ITransitionerViewModel previousViewModel)
        {
            Pagina2ControlViewModel pag2Vm = (Pagina2ControlViewModel)previousViewModel;

            Cursor.Current = Cursors.WaitCursor;
            BLL.Designacion business = new BLL.Designacion();

            PartidosDesignados = business.RealizarDesignacion(pag2Vm.Partidos, pag2Vm.Arbitros, pag2Vm.DeporteSeleccionado);


            Cursor.Current = Cursors.Default;


        }
    }

}
