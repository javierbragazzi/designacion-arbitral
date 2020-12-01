using System.Windows.Controls;
using System.Windows.Media;
using DA.SS;
using MaterialDesignThemes.Wpf;

namespace DA.UI
{
    /// <summary>
    /// Interaction logic for Mensaje.xaml
    /// </summary>
    public partial class Mensaje : UserControl
    {
        public Mensaje(TipoMensaje tipoMensaje, string titulo, string mensaje)
        {
            InitializeComponent();

            ArmarMensaje(tipoMensaje, titulo, mensaje);
        }

        private void ArmarMensaje(TipoMensaje tipoMensaje, string titulo, string mensaje)
        {
            txtTitulo.Text = titulo;
            txtMensaje.Text = mensaje;

            switch (tipoMensaje)
            {
                case TipoMensaje.CORRECTO:
                    icono.Kind = PackIconKind.CheckBold;
                    icono.Foreground = new SolidColorBrush(Colors.SpringGreen);   //#00E676
                    btnAceptar.Background = new SolidColorBrush(Colors.SpringGreen);
                    break;

                case TipoMensaje.ERROR:
                    icono.Kind = PackIconKind.Alert;
                    icono.Foreground = new SolidColorBrush(Color.FromRgb(246,86,86));   //#F65656
                    btnAceptar.Background = new SolidColorBrush(Color.FromRgb(246, 86, 86));
                    break;

                case TipoMensaje.NORMAL:
                    icono.Kind = PackIconKind.InformationCircleOutline;
                    icono.Foreground = new SolidColorBrush(Color.FromRgb(2, 136, 209));   //#F65656
                    btnAceptar.Background = new SolidColorBrush(Color.FromRgb(2, 136, 209));
                    break;
            }
        }
    }
}
