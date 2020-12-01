using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DA.BE.Composite;
using DA.SS;
using DA.UI.ABM;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    public class AdmGruposPermisosViewModel : ViewModelBaseLocal
    {
   
        public AdmGruposPermisosViewModel()
        {
 
            Visibilidad = Visibility.Collapsed;
            CargarGruposPermisos();
            CleanCommand = new RelayCommand(ExecuteCleanCommand);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
            RunAltaGrupo = new RelayCommand(ExecuteRunAltaGrupo);
            RunGuardarGrupo = new RelayCommand(ExecuteRunGuardarGrupo);
            RunEliminarGrupo = new RelayCommand(ExecuteRunEliminarGrupo);

        }
        
        #region Metodos

         private async void ExecuteRunEliminarGrupo(object obj)
        {
            BLL.Permiso bllPermiso = new BLL.Permiso();
            Mensaje vieMensaje = null;
     

            if (PermisoSeleccionado != null)
            {
                
                MensajeConsulta mensajeConsulta = new MensajeConsulta( );

                object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");
            
                Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
                switch (respuesta)
                {
                    case Respuesta.Si:
                    {

                        Resultado resultado = bllPermiso.Quitar(PermisoSeleccionado);

                        if (resultado.HayError == false)
                        {
                            vieMensaje = new Mensaje(resultado.TipoMensaje,resultado.Titulo, resultado.Descripcion);
                            CargarGruposPermisos();
                            Limpiar();
                        }
                        else
                            vieMensaje =new Mensaje(resultado.TipoMensaje,resultado.Titulo, resultado.Descripcion);

                    } 
                    break;
      
                }
              
            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Eliminar grupo de permisos", "Debe seleccionar un grupo de permisos");


            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        private async void ExecuteRunGuardarGrupo(object obj)
        {
            BLL.Permiso bllPermiso = new BLL.Permiso();
            Mensaje vieMensaje = null;


            if (PermisoSeleccionado != null)
            {

                MensajeConsulta mensajeConsulta = new MensajeConsulta();

                object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");

                Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
                switch (respuesta)
                {
                    case Respuesta.Si:
                        {
                       
                            Resultado resultado = bllPermiso.ActualizarPermisosDeGrupo(PermisoSeleccionado);

                            if (resultado.HayError == false)
                            {
                                vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Edición de Grupo",
                                    "Se editó el grupo de permisos seleccionado");
                                CargarGruposPermisos();
                                Limpiar();
                            }
                            else
                            { 
                                vieMensaje = new Mensaje(TipoMensaje.ERROR, "Edición de Grupo",
                                    "El grupo de permisos no pudo ser editado");
                                CargarGruposPermisos();

                            }
                        }
                        break;

                }

            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Edición de Grupo", "Debe seleccionar un permiso");


            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }

        }

        public void CargarGruposPermisos()
        {
            BLL.Permiso bllPermiso = new BLL.Permiso();

            PermisosComponentes = bllPermiso.ObtenerGruposPermisos();

        }
        
        private async void ExecuteRunAltaGrupo(object obj)
        {
            var view = new AltaGrupo()
            {
                DataContext = new AltaGrupoViewModel()
            };

            var result = await DialogHost.Show(view, "RootDialog");

            AltaGrupoViewModel viewModel = (AltaGrupoViewModel)view.DataContext;

            if (viewModel.SeGuardo)
            {
                CargarGruposPermisos();

                foreach (PermisoComponente permiso in PermisosComponentes)
                {
                    if (permiso.Descripcion.Equals(viewModel.GrupoNuevo))
                    {
                        PermisoSeleccionado = permiso;
                        break;
                    }
                }

            }

        }

        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            //if (PermisoSeleccionado != null && PermisoSeleccionado.Leyendas != null)
            //{
            //    ColeccionLeyenda = new SortablePageableCollection<Leyenda>(PermisoSeleccionado.Leyendas);

            //    Visibilidad = Visibility.Visible;
            //}
           

        }

        public void ExecuteCleanCommand(object obj)
        {
            Limpiar();
      
        }

        private void Limpiar()
        {
            PermisoSeleccionado = null;
            Visibilidad = Visibility.Collapsed;
        }

        #endregion

        #region Propiedades

        private Visibility _visibilidad;

        public Visibility Visibilidad
        {
            get => _visibilidad;
            set => SetProperty(ref _visibilidad, value);
        }

        private List<PermisoComponente> _permisosComponentes;

        public List<PermisoComponente> PermisosComponentes
        {
            get => _permisosComponentes;
            set => SetProperty(ref _permisosComponentes, value);
        }

        private PermisoComponente _permisoSeleccionado;

        public PermisoComponente PermisoSeleccionado
        {
            get => _permisoSeleccionado;
            set => SetProperty(ref _permisoSeleccionado, value);
        }
        
        
        private List<PermisoComponente> _permisosDelGrupo;

        public List<PermisoComponente> PermisosDelGrupo
        {
            get => _permisosDelGrupo;
            set => SetProperty(ref _permisosDelGrupo, value);
        }

       
        #endregion

        #region Commands

        public ICommand CleanCommand { get; private set; }

        public ICommand SelectedItemChangedCommand { get; private set; }

        public ICommand RunAltaGrupo { get; private set; }
       
        public ICommand RunGuardarGrupo { get; private set; }
       
        public ICommand RunEliminarGrupo { get; private set; }


        #endregion
        
 
    }
}
