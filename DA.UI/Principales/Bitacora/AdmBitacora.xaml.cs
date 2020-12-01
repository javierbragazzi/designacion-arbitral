using System.Windows;
using System.Windows.Controls;
using DA.BE.Observer;
using DA.UI.ViewModel;

namespace DA.UI.Principales.Bitacora
{
    /// <summary>
    /// Interaction logic for AdmBitacora.xaml
    /// </summary>
    public partial class AdmBitacora : UserControl, IControlUsuario, IObserverIdioma
    {
        public AdmBitacora() 
        {
            InitializeComponent();
            InicializarControl();
           
        }

        public void InicializarControl()
        {
            this.DataContext = new AdmBitacoraViewModel();
        }

        public void LimpiarControl()
        {
           ((AdmBitacoraViewModel)DataContext).ExecuteCleanCommand(new object());
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

        public void Update(IdiomaSubject idioma)
        {
           
        }
    }
}
