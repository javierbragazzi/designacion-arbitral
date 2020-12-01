using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DA.BE.Composite;
using DA.SS;
using DA.UI.DataGrid;
using GalaSoft.MvvmLight;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    public class AltaGrupoViewModel : ViewModelBase
    {
        private string _nombreGrupo;

        public string NombreGrupo
        {
            get => _nombreGrupo;
            set => Set(ref _nombreGrupo, value);
        }

        public string GrupoNuevo { get; set; }
        
        public SnackbarMessageQueue BoundMessageQueue { get; } = new SnackbarMessageQueue();

        public bool SeGuardo { get; set; }

        public ICommand RunGuardar { get; private set; }

        public AltaGrupoViewModel()
        {
            RunGuardar = new RelayCommand(ExecuteRunGuardar);
        }


        private void ExecuteRunGuardar(object obj)
        {
            BLL.Permiso bllPermiso = new BLL.Permiso();
            Permiso permiso = new Permiso(NombreGrupo) {EsPermiso = false};

            Resultado resultado = bllPermiso.Agregar(permiso);

            if (resultado.HayError)
            {
                BoundMessageQueue.Enqueue("Error en el alta de grupo de permisos.");
                SeGuardo = false;
            }
            else
            {
                GrupoNuevo = NombreGrupo;
                NombreGrupo = "";
                BoundMessageQueue.Enqueue("Se dio de alta el grupo de permisos.");
                SeGuardo = true;
            }
        }
    }
}
