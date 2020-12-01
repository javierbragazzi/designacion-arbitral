using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DA.BE.Composite;
using DA.BE.Observer;
using DA.SS;
using MaterialDesignThemes.Wpf;


namespace DA.UI.Principales
{
    /// <summary>
    /// Interaction logic for AdmPerfiles.xaml
    /// </summary>
    public partial class AdmPerfiles : UserControl, IControlUsuario, IObserverIdioma
    {
        private BLL.Usuario _bllUsuario;
        private BLL.Permiso _bllPermiso;
        private BE.Usuario _beUsuario;
        private PermisoComponente _permisoActualAgregar;
        private PermisoComponente _permisoActualQuitar;
        private PermisoComponente _permisoPadreAgregar;
        private PermisoComponente _permisoPadreQuitar;


        public AdmPerfiles()
        {
            InitializeComponent();
        }

        private void CargarComboUsuario()
        {

            cmbUsuarios.ItemsSource = _bllUsuario.ObtenerUsuarios();

            //this column will display as text
            cmbUsuarios.DisplayMemberPath = "NombreCompleto";

            //this column will use as back end value who can you use in selectedValue property
            cmbUsuarios.SelectedValuePath = "Id";
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

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private  void BtnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var resultado = Guardar();
            
        }

        private async Task Guardar()
        {
            if (_beUsuario != null)
            {
                Resultado resultado = _bllUsuario.ActualizarPermisos(_beUsuario);

                if (resultado.HayError)
                {
                    Mensaje vieMensaje = new Mensaje(TipoMensaje.ERROR, "Actualizar permisos", "No se pudieron actualizar los permisos");

                    var resultadoMensaje = DialogHost.Show(vieMensaje, "dhMensajes");
                }
                else
                {
                    Mensaje vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Actualizar permisos", "Se actualizaron los permisos");

                    var resultadoMensaje = await DialogHost.Show(vieMensaje, "dhMensajes");

                    CargarComboUsuario();

                    cmbUsuarios.SelectedValue = _beUsuario.Id;
                }

            }

        }

        private void BtnAgregar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            btnGuardar.IsEnabled = true;

            if (_permisoActualAgregar != null)
            {
                if (_bllPermiso.AgregarPermiso(_permisoPadreAgregar, _permisoActualAgregar, _beUsuario.Permisos))
                {
                    CargarTreeView(treeViewPermisosUsuario, _beUsuario.Permisos);
                }

   
            }

        }

        private void BtnQuitar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            btnGuardar.IsEnabled = true;

            if (_permisoActualQuitar != null)
            {
                if (_bllPermiso.QuitarPermiso(_permisoActualQuitar, _beUsuario.Permisos))
                {
                    CargarTreeView(treeViewPermisosUsuario, _beUsuario.Permisos);
                }


            }

        }

        private void CmbUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized) return;

            if (cmbUsuarios.SelectedItem is BE.Usuario usuario)
            {
                btnAgregar.IsEnabled = true;
                treeViewPermisosUsuario.Items.Clear();
                _beUsuario = usuario;
                CargarTreeView(treeViewPermisosUsuario, usuario.Permisos);
            }
        }

        private void UserControl_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
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

        public void InicializarControl()
        {
            _bllPermiso = new BLL.Permiso();
            _bllUsuario = new BLL.Usuario();
            InitializeComponent();
            //CargarTreeView(treeViewPermisosUsuario, ManejadorSesion.Instancia.ObtenerSesion().Usuario.Permisos);
            CargarTreeView(treeViewPermisos, _bllPermiso.ObtenerPermisos());
            CargarComboUsuario();
        }

        public void LimpiarControl()
        {
            //cmbUsuarios.Items.Clear();
            cmbUsuarios.ItemsSource = null;
            treeViewPermisosUsuario.Items.Clear();
            treeViewPermisos.Items.Clear();
            _permisoActualAgregar = null;
            _permisoPadreAgregar = null;
            _beUsuario = null;
            btnQuitar.IsEnabled = false;
            btnAgregar.IsEnabled = false;
            btnGuardar.IsEnabled = false;


        }

        private void TreeViewPermisos_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (cmbUsuarios.SelectedItem != null)
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

        public void Update(IdiomaSubject idioma)
        {
            

        }

        private void TreeViewPermisosUsuario_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
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
    }
}
