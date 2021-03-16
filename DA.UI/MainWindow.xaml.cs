using DA.UI.Principales.Designacion;

namespace DA.UI
{
    using DA.BE.Observer;
    using DA.SS;
    using MaterialDesignThemes.Wpf;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Application = System.Windows.Application;
    using ComboBox = System.Windows.Controls.ComboBox;
    using Leyenda = DA.BE.Leyenda;
    using UserControl = System.Windows.Controls.UserControl;

    /// <summary>
    /// Defines the <see cref="MainWindow" />.
    /// </summary>
    public partial class MainWindow : Window, IObserverIdioma
    {
        #region Fields

        /// <summary>
        /// Defines the _bllPermiso.
        /// </summary>
        private BLL.Permiso _bllPermiso;

        /// <summary>
        /// Defines the _userControlActual.
        /// </summary>
        private UserControl _userControlActual;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            _bllPermiso = new BLL.Permiso();

            InicializarComboIdioma();

            if (ManejadorSesion.Instancia.ObtenerSesion().EstadoBaseDeDatos.EsValida)
            {
                HabilitarOpciones();
                cmbIdioma.SelectedItem = ((List<BE.Idioma>)cmbIdioma.ItemsSource).FirstOrDefault(p => p.Id == ManejadorSesion.Instancia.ObtenerSesion().Usuario.Idioma.Id); //ManejadorSesion.Instancia.ObtenerSesion().Usuario.Idioma;
                cmbIdioma.SelectedValue = ((List<BE.Idioma>)cmbIdioma.ItemsSource).FirstOrDefault(p => p.Id == ManejadorSesion.Instancia.ObtenerSesion().Usuario.Idioma.Id); //ManejadorSesion.Instancia.ObtenerSesion().Usuario.Idioma;
            }
            else
            {
                HabilitarSoloRestore();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="idioma">The idioma<see cref="IdiomaSubject"/>.</param>
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
                            delegate (Leyenda leye) { return leye.Etiqueta.Equals((string)textBlock.Tag); }
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

                Leyenda leyendaCombo = idioma.Idioma.Leyendas.Find(delegate (Leyenda leye) { return leye.Etiqueta.Equals((string)cmbIdioma.Tag); }
                );

                if (leyendaCombo != null)
                    HintAssist.SetHint(cmbIdioma, leyendaCombo.Traduccion.TextoTraducido);
            }
        }

        /// <summary>
        /// The Border_OnMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
            DragMove();
        }

        /// <summary>
        /// The BtnAyuda_OnClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void BtnAyuda_OnClick(object sender, RoutedEventArgs e)
        {
            Ayuda.Mostrar();
        }

        /// <summary>
        /// The BtnSalir_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// The CmbIdioma_SelectionChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="SelectionChangedEventArgs"/>.</param>
        private void CmbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized) return;

            if (cmbIdioma.SelectedItem is BE.Idioma idioma)
            {
                SingletonIdioma.Instancia.IdiomaSubject.Idioma = idioma;

                SingletonIdioma.Instancia.IdiomaSubject.Descripcion = idioma.Descripcion;

                BLL.Usuario bllUsuario = new BLL.Usuario();

                BE.Usuario beUsuario = ManejadorSesion.Instancia.ObtenerSesion().Usuario;

                beUsuario.Idioma = (BE.Idioma)cmbIdioma.SelectedItem;

                bllUsuario.Editar(beUsuario);
            }
        }

        /// <summary>
        /// The ColorZone_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        private void ColorZone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
        }

        /// <summary>
        /// The Event_PreviewKeyDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="System.Windows.Input.KeyEventArgs"/>.</param>
        private void Event_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
                Ayuda.Mostrar();
        }

        /// <summary>
        /// The HabilitarNodos.
        /// </summary>
        /// <param name="treeView">The treeView<see cref="TreeViewItem"/>.</param>
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

        /// <summary>
        /// The HabilitarNodosRestore.
        /// </summary>
        /// <param name="treeView">The treeView<see cref="TreeViewItem"/>.</param>
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

        /// <summary>
        /// The HabilitarOpciones.
        /// </summary>
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

        /// <summary>
        /// The HabilitarSoloRestore.
        /// </summary>
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

        /// <summary>
        /// The HacerVisibleAdministracion.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void HacerVisibleAdministracion(object sender, RoutedEventArgs e)
        {
            itemAdministracion.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The HacerVisibleAsignacionNivel.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void HacerVisibleAsignacionNivel(object sender, RoutedEventArgs e)
        {
            itemAsignarNiveles.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The HacerVisibleDesignacion.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void HacerVisibleDesignacion(object sender, RoutedEventArgs e)
        {
            itemDesignación.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The HacerVisibleEvaluacion.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void HacerVisibleEvaluacion(object sender, RoutedEventArgs e)
        {
            itemEvaluación.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The HacerVisiblePersonalizar.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void HacerVisiblePersonalizar(object sender, RoutedEventArgs e)
        {
            itemPersonalizar.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The HacerVisibleSeguridad.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void HacerVisibleSeguridad(object sender, RoutedEventArgs e)
        {
            itemSeguridad.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The HacerVisibleServicios.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void HacerVisibleServicios(object sender, RoutedEventArgs e)
        {
            itemServicios.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The InicializarComboIdioma.
        /// </summary>
        private void InicializarComboIdioma()
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();

            cmbIdioma.ItemsSource = bllIdioma.ObtenerIdiomas();

            cmbIdioma.DisplayMemberPath = "Descripcion";

            cmbIdioma.SelectedValuePath = "Id";
        }

        /// <summary>
        /// The ItemArbitros_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemAsignarNiveles_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemBackup_OnPreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemBitacora_OnPreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemCalificar_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemCampeonatos_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        private void ItemCampeonatos_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarEnConstruccion();
        }

        /// <summary>
        /// The ItemCategorias_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        private void ItemCategorias_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarEnConstruccion();
        }

        /// <summary>
        /// The ItemCrearPerfiles_OnPreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemEquipos_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        private void ItemEquipos_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarEnConstruccion();
        }

        /// <summary>
        /// The ItemGestionarPerfiles_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemIdioma_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemPartidos_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        private void ItemPartidos_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarEnConstruccion();
        }

        /// <summary>
        /// The ItemPromocionDescenso_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemRealizarDesignación_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        private void ItemRealizarDesignación_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_userControlActual != null)
            {
                _userControlActual.Visibility = Visibility.Collapsed;
            }
            ucDesignacion.InitializeComponent();

            _userControlActual = ucDesignacion;

            ucDesignacion.Visibility = Visibility.Visible;

            MenuToggleButton.IsChecked = false;
        }

        /// <summary>
        /// The ItemRestore_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The ItemUsuarios_PreviewMouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
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

        /// <summary>
        /// The MostrarEnConstruccion.
        /// </summary>
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

        /// <summary>
        /// The ScrollViewer_MouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        private void ScrollViewer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
        }

        /// <summary>
        /// The ScrollViewer_PreviewMouseWheel.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseWheelEventArgs"/>.</param>
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        /// <summary>
        /// The TraducirMenu.
        /// </summary>
        /// <param name="idioma">The idioma<see cref="IdiomaSubject"/>.</param>
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

        /// <summary>
        /// The TraducirNodos.
        /// </summary>
        /// <param name="treeView">The treeView<see cref="TreeViewItem"/>.</param>
        /// <param name="idioma">The idioma<see cref="IdiomaSubject"/>.</param>
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

        /// <summary>
        /// The Window_ContentRendered.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="System.EventArgs"/>.</param>
        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            SingletonIdioma.Instancia.IdiomaSubject.Idioma = SingletonIdioma.Instancia.IdiomaSubject.Idioma;
            SingletonIdioma.Instancia.IdiomaSubject.Descripcion = SingletonIdioma.Instancia.IdiomaSubject.Descripcion;
        }

        /// <summary>
        /// The Window_Loaded.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Subject.AddObserver(this);
            Subject.AddObserver(admBackup);
        }

        #endregion
    }
}
