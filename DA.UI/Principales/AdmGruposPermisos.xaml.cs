using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DA.BE.Composite;
using DA.BE.Observer;
using DA.UI.ViewModel;

namespace DA.UI.Principales
{
    /// <summary>
    /// Interaction logic for AdmGruposPermisos.xaml
    /// </summary>
    public partial class AdmGruposPermisos : UserControl, IControlUsuario, IObserverIdioma
    {
        private BLL.Permiso _bllPermiso;
        private PermisoComponente _grupoPermisoSeleccionado;
        private PermisoComponente _permisoActualAgregar;
        private PermisoComponente _permisoActualQuitar;
        private PermisoComponente _permisoPadreAgregar;
        private PermisoComponente _permisoPadreQuitar;
        
        public AdmGruposPermisos()
        {
            InitializeComponent();
        }

        private void CargarTreeView(TreeView treeView, List<PermisoComponente> permisos)
        {
            treeView.Items.Clear();

            if (permisos != null)
            {
                foreach (PermisoComponente permiso in permisos)
                {
                    TreeViewItem item = new TreeViewItem();
                    item.Header = permiso.Descripcion;
                    item.Tag = permiso;

                    if (permiso.ObtenerHijos().Count != 0)
                    {
                        CargarHijos(item, permiso.ObtenerHijos());

                    }

                    treeView.Items.Add(item);

                }
            }

   
        }

        private void CargarHijos(TreeViewItem treeView, List<PermisoComponente> permisos)
        {
            foreach (PermisoComponente permiso in permisos)
            {
                TreeViewItem item = new TreeViewItem
                {
                    Header = permiso.Descripcion,
                    Tag = permiso
                };

                if (permiso.ObtenerHijos().Count != 0)
                {
                    CargarHijos(item, permiso.ObtenerHijos());

                }


                treeView.Items.Add(item);
                
            }

        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                InicializarControl();

            }
            else
            {
                LimpiarControl();
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void TreeViewPermisosDisponibles_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (cmbGrupos.SelectedItem != null)
            {

                TreeView tv = e.OriginalSource as TreeView;
                
                if (tv != null)
                {
                    TreeViewItem selectedItem = (TreeViewItem) tv.SelectedItem;

                    if (null != selectedItem)
                    {
                        _permisoActualAgregar = (PermisoComponente) selectedItem.Tag;

                        btnAgregar.IsEnabled = true;

                        object item = ItemsControl.ItemsControlFromItemContainer(selectedItem);

                        if (item != null)
                        {
                            if (item is TreeView)
                            {
                                TreeView parentItem =
                                    (TreeView) ItemsControl.ItemsControlFromItemContainer(selectedItem);

                                if (null != parentItem)
                                    _permisoPadreAgregar = (PermisoComponente) parentItem.Tag;
                                else
                                    _permisoPadreAgregar = null;
                            }

                            if (item is TreeViewItem)
                            {
                                TreeViewItem parentItem =
                                    (TreeViewItem) ItemsControl.ItemsControlFromItemContainer(selectedItem);

                                if (null != parentItem)
                                    _permisoPadreAgregar = (PermisoComponente) parentItem.Tag;
                                else
                                    _permisoPadreAgregar = null;
                            }


                        }

                    }
                }
            }
        }

        private void TreeViewPermisosGrupo_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView tv = e.OriginalSource as TreeView;
            _permisoActualQuitar = null;
            _permisoPadreQuitar = null;

            if (tv != null)
            {
                TreeViewItem selectedItem = (TreeViewItem)tv.SelectedItem;

                if (null != selectedItem)
                {
                    _permisoActualQuitar = (PermisoComponente)selectedItem.Tag;

                    btnAgregar.IsEnabled = true;

                    object item = ItemsControl.ItemsControlFromItemContainer(selectedItem);

                    if (item != null)
                    {
                        if (item is TreeView)
                        {
                            TreeView parentItem = (TreeView)ItemsControl.ItemsControlFromItemContainer(selectedItem);

                            if (null != parentItem)
                                _permisoPadreQuitar = (PermisoComponente)parentItem.Tag;
                            else
                                _permisoPadreQuitar = null;
                        }

                        if (item is TreeViewItem)
                        {
                            TreeViewItem parentItem = (TreeViewItem)ItemsControl.ItemsControlFromItemContainer(selectedItem);

                            if (null != parentItem)
                                _permisoPadreQuitar = (PermisoComponente)parentItem.Tag;
                            else
                                _permisoPadreQuitar = null;
                        }


                    }

                }

                if (_permisoPadreQuitar != null)
                    btnQuitar.IsEnabled = false;
                else
                {
                    btnQuitar.IsEnabled = true;
                }

            }
        }

        private void BtnAgregar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            btnGuardar.IsEnabled = true;

            if (_permisoActualAgregar != null)
            {
                if (_bllPermiso.AgregarPermiso(_permisoPadreAgregar, _permisoActualAgregar, _grupoPermisoSeleccionado.ObtenerHijos()))
                {
                    CargarTreeView(treeViewPermisosGrupo, _grupoPermisoSeleccionado.ObtenerHijos());
                }

   
            }

        }

        private void BtnQuitar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            btnGuardar.IsEnabled = true;

            if (_permisoActualQuitar != null)
            {
                if (_bllPermiso.QuitarPermiso(_permisoActualQuitar, _grupoPermisoSeleccionado.ObtenerHijos()))
                {
                    CargarTreeView(treeViewPermisosGrupo, _grupoPermisoSeleccionado.ObtenerHijos());
                }


            }

        }

        private void CmbGrupos_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized) return;

            if (cmbGrupos.SelectedItem is PermisoComponente componente)
            {
                btnAgregar.IsEnabled = true;
                treeViewPermisosGrupo.Items.Clear();
                _grupoPermisoSeleccionado = componente;
                //var permisos = _bllPermiso.ObtenerPermisosDelGrupo(componente.Id);
                CargarTreeView(treeViewPermisosGrupo, componente.ObtenerHijos());
                CargarTreeViewSinGrupoSeleccionado(treeViewPermisosDisponibles, _bllPermiso.ObtenerPermisosSinPerfiles());
            }
            else
            {
                treeViewPermisosGrupo.Items.Clear();
            }
        }

        private void CargarTreeViewSinGrupoSeleccionado(TreeView treeView, List<PermisoComponente> permisos)
        {
            treeView.Items.Clear();

            if (permisos != null)
            {
                foreach (PermisoComponente permiso in permisos)
                {
                    TreeViewItem item = new TreeViewItem();
                    item.Header = permiso.Descripcion;
                    item.Tag = permiso;

                    if (!permiso.Descripcion.Equals(_grupoPermisoSeleccionado.Descripcion))
                    {
                        if (permiso.ObtenerHijos().Count != 0)
                        {
                            CargarHijos(item, permiso.ObtenerHijos());

                        }

                        treeView.Items.Add(item);
                    }

                }
            }
        }

        public void InicializarControl()
        {
            this.DataContext = new AdmGruposPermisosViewModel();
            _bllPermiso = new BLL.Permiso();
            _grupoPermisoSeleccionado = null;
            InitializeComponent();

        }

        public void LimpiarControl()
        {
    
            cmbGrupos.ItemsSource = null;
            treeViewPermisosDisponibles.Items.Clear();
            treeViewPermisosGrupo.Items.Clear();
            _permisoActualAgregar = null;
            _permisoPadreAgregar = null;
            _grupoPermisoSeleccionado = null;
            btnQuitar.IsEnabled = false;
            btnAgregar.IsEnabled = false;
            btnGuardar.IsEnabled = false;


        }
        
        public void Update(IdiomaSubject idioma)
        {
     
        }
    }
}
