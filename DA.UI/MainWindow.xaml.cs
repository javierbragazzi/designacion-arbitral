using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DA.BE.Observer;
using DA.SS;
using MaterialDesignThemes.Wpf;
using Application = System.Windows.Application;
using ComboBox = System.Windows.Controls.ComboBox;
using Leyenda = DA.BE.Leyenda;
using UserControl = System.Windows.Controls.UserControl;

namespace DA.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserverIdioma
    {
        private UserControl _userControlActual;

        private BLL.Permiso _bllPermiso;

        public MainWindow()
        {
            InitializeComponent();

            _bllPermiso = new BLL.Permiso();

            InicializarComboIdioma();
  
            if (ManejadorSesion.Instancia.ObtenerSesion().EstadoBaseDeDatos.EsValida)
                HabilitarOpciones();
            else
            {
                HabilitarSoloRestore();
            }



        }

        private void InicializarComboIdioma()
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();

            cmbIdioma.ItemsSource = bllIdioma.ObtenerIdiomas();

            cmbIdioma.DisplayMemberPath = "Descripcion";

            cmbIdioma.SelectedValuePath = "Id";

       
        }

        private void HabilitarSoloRestore()
        {
                foreach (TreeViewItem item in treeViewMenu.Items)
                {
                    string menuServicio = item.Tag.ToString().Split('|').GetValue(1).ToString();

                    if (menuServicio.ToString().Equals("Servicios"))
                    {
                        item.Visibility = Visibility.Visible;
                    }


                    HabilitarNodosRestore(item);
                }

        }

        private void HabilitarNodosRestore(TreeViewItem treeView)
        {
            ItemCollection nodos = treeView.Items;

            foreach (TreeViewItem item in nodos)
            {
               
                string menuServicio = item.Tag.ToString().Split('|').GetValue(1).ToString();

                if (menuServicio.ToString().Equals("Restore"))
                {
                    item.Visibility = Visibility.Visible;
                }


                HabilitarNodosRestore(item);
            }

        }

        private void HabilitarOpciones()
        {
            foreach (TreeViewItem item in treeViewMenu.Items)
            {
                int idPermiso = Convert.ToInt32(item.Tag.ToString().Split('|').GetValue(0));

                if (_bllPermiso.TienePermiso(idPermiso, ManejadorSesion.Instancia.ObtenerSesion().Usuario.Permisos))
                {
                    item.Visibility = Visibility.Visible;
                    item.Focus();
                    HabilitarNodos(item);
                }
                else
                {
                    HabilitarNodos(item);
                }
      
            }

        }

        private void HabilitarNodos(TreeViewItem treeView)
        {
            ItemCollection nodos = treeView.Items;

            foreach (TreeViewItem item in nodos)
            {
                int idPermiso = Convert.ToInt32(item.Tag.ToString().Split('|').GetValue(0));

                if (_bllPermiso.TienePermiso(idPermiso, ManejadorSesion.Instancia.ObtenerSesion().Usuario.Permisos))
                {
                    item.Visibility = Visibility.Visible;
                    item.Focus();
     
                    HabilitarNodos(item);
                }
                else
                {
                    HabilitarNodos(item);
                }
            }

        }


        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
            DragMove();
        }

        private void ItemArbitros_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = admArbitros;
            
            admArbitros.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void ItemCampeonatos_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarEnConstruccion();
        }

        private void ItemCategorias_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarEnConstruccion();
        }

        private void ItemEquipos_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarEnConstruccion();
        }

        private void ItemPartidos_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarEnConstruccion();
        }

        private void ItemRealizarDesignación_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = ucDesignacion;

            ucDesignacion.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;

        }

        private void ItemCalificar_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = UcCalificacion;

            UcCalificacion.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void ItemPromocionDescenso_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = UcPromocionDescenso;

            UcPromocionDescenso.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void ItemUsuarios_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }
            
            _userControlActual = admUsuario;

            admUsuario.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void ItemGestionarPerfiles_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = admPerfiles;


            admPerfiles.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void ItemIdioma_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }
            
            _userControlActual = admIdioma;

            admIdioma.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void ItemAsignarNiveles_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = ucAsignarNiveles;

            ucAsignarNiveles.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        public void Update(IdiomaSubject idioma)
        {
            if (idioma.Idioma != null)
            {
                TraducirMenu(idioma);

                foreach (TextBlock textBlock in SingletonIdioma.FindWindowChildren<TextBlock>(this))
                {
                    if (textBlock.Tag != null)
                    {
                        Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                            delegate(Leyenda leye) { return leye.Etiqueta.Equals((string) textBlock.Tag); }
                        );

                        if (leyenda != null)
                            textBlock.Text = leyenda.Traduccion.TextoTraducido;
                    }


                }


                foreach (ComboBox comboBox in SingletonIdioma.FindWindowChildren<ComboBox>(this))
                {
                    if (comboBox.Tag != null)
                    {
                        Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                            delegate (Leyenda leye) { return leye.Etiqueta.Equals((string)comboBox.Tag); }
                        );

                        if (leyenda != null)
                            HintAssist.SetHint(comboBox, leyenda.Traduccion.TextoTraducido);

                    }

                }

                Leyenda leyendaCombo = idioma.Idioma.Leyendas.Find( delegate (Leyenda leye) { return leye.Etiqueta.Equals((string)cmbIdioma.Tag); }
                );

                if (leyendaCombo != null)
                    HintAssist.SetHint(cmbIdioma, leyendaCombo.Traduccion.TextoTraducido);
            }
        }

        private void TraducirMenu(IdiomaSubject idioma)
        {
            foreach (TreeViewItem item in treeViewMenu.Items)
            {

                if (item.Tag != null)
                {
                    Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                        delegate (Leyenda leye) { return leye.Etiqueta.Equals(((string)item.Tag).Split('|').GetValue(1)); }
                    );

                    if (leyenda != null)
                        item.Header = leyenda.Traduccion.TextoTraducido;
                }


                TraducirNodos(item, idioma);
            }

            foreach (TreeViewItem item in treeViewIdioma.Items)
            {

                if (item.Tag != null)
                {
                    Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                        delegate (Leyenda leye) { return leye.Etiqueta.Equals(((string)item.Tag).Split('|').GetValue(1)); }
                    );

                    if (leyenda != null)
                        item.Header = leyenda.Traduccion.TextoTraducido;
                }


            }

        }

        private void TraducirNodos(TreeViewItem treeView, IdiomaSubject idioma)
        {
            ItemCollection nodos = treeView.Items;

            foreach (TreeViewItem item in nodos)
            {
                if (item.Tag != null)
                {
                    Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                        delegate (Leyenda leye) { return leye.Etiqueta.Equals(((string)item.Tag).Split('|').GetValue(1)); }
                    );
                    if (leyenda != null)
                        item.Header = leyenda.Traduccion.TextoTraducido;
                }

                TraducirNodos(item, idioma);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Subject.AddObserver(this);
            Subject.AddObserver(admBackup);
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            SingletonIdioma.Instancia.IdiomaSubject.Idioma = SingletonIdioma.Instancia.IdiomaSubject.Idioma;
            SingletonIdioma.Instancia.IdiomaSubject.Descripcion = SingletonIdioma.Instancia.IdiomaSubject.Descripcion;

        }

        private void ScrollViewer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
        }

        private void ColorZone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
        }
        
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void ItemBitacora_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }
            
   
            _userControlActual = admBitacora;

            admBitacora.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void ItemCrearPerfiles_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }
            
   
            _userControlActual = admGruposPermisos;

            admGruposPermisos.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void HacerVisibleAdministracion(object sender, RoutedEventArgs e)
        {
            itemAdministracion.Visibility = Visibility.Visible;
        }

        private void HacerVisibleDesignacion(object sender, RoutedEventArgs e)
        {
            itemDesignación.Visibility = Visibility.Visible;
        }

        private void HacerVisibleEvaluacion(object sender, RoutedEventArgs e)
        {
            itemEvaluación.Visibility = Visibility.Visible;
        }

        private void HacerVisibleSeguridad(object sender, RoutedEventArgs e)
        {
            itemSeguridad.Visibility = Visibility.Visible;
        }

        private void HacerVisibleServicios(object sender, RoutedEventArgs e)
        {
            itemServicios.Visibility = Visibility.Visible;
        }

        private void HacerVisiblePersonalizar(object sender, RoutedEventArgs e)
        {
            itemPersonalizar.Visibility = Visibility.Visible;
        }

        private void HacerVisibleAsignacionNivel(object sender, RoutedEventArgs e)
        {
            itemAsignarNiveles.Visibility = Visibility.Visible;
        }

        private void MostrarEnConstruccion()
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = EnConstruccion;

            EnConstruccion.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        private void CmbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized) return;

            if (cmbIdioma.SelectedItem is BE.Idioma idioma)
            {
                SingletonIdioma.Instancia.IdiomaSubject.Idioma = idioma;

                SingletonIdioma.Instancia.IdiomaSubject.Descripcion = idioma.Descripcion;
            }
        }

        private void ItemBackup_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = admBackup;

            admBackup.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;

        }

        private void ItemRestore_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }

            _userControlActual = admRestore;

            admRestore.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }


        private void BtnAyuda_OnClick(object sender, RoutedEventArgs e)
        {
           Ayuda.Mostrar();
        }

        private void Event_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
                Ayuda.Mostrar();
        }

    }
}
