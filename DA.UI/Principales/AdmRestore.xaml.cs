using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DA.BE.Observer;
using DA.BLL;
using DA.SS;
using MaterialDesignThemes.Wpf;

namespace DA.UI.Principales
{
    /// <summary>
    /// Interaction logic for AdmRestore.xaml
    /// </summary>
    public partial class AdmRestore : UserControl, IObserverIdioma, IControlUsuario
    {
        private BE.Resguardo _resguardoSeleccionado;
        public AdmRestore()
        {
            InitializeComponent();
        }

        public void Update(IdiomaSubject idioma)
        {
        
        }

        public void InicializarControl()
        {
            CargarDataGridBackup();
        }

        public void LimpiarControl()
        {
            dgBackup.ItemsSource = null;
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

        private void CargarDataGridBackup()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            BLL.Resguardo bllResguardo = new BLL.Resguardo();

            dgBackup.ItemsSource = bllResguardo.ObtenerResguardos();
        }

        private void BtnRestore_OnClick(object sender, RoutedEventArgs e)
        {
            Restore();
        }

        private async Task Restore()
        {
            BLL.Sistema bllSistema = new BLL.Sistema();

            if (bllSistema.Restore("DesignacionArbitral", _resguardoSeleccionado.Directorio,
                _resguardoSeleccionado.NombreArchivo))
            {
                Mensaje vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Restore", "Se realizó el restore con éxito");

                await DialogHost.Show(vieMensaje, "dhMensajes");
            }
            else
            {
                Mensaje vieMensaje = new Mensaje(TipoMensaje.ERROR, "Restore", "No se pudo relizar el restore");

                await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        private void DgBackup_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _resguardoSeleccionado = (BE.Resguardo)dgBackup.SelectedItem;

            btnRestore.IsEnabled = true;
        }
    }
}
