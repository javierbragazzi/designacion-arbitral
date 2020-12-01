using System;
using System.Windows;
using System.Windows.Controls;
using DA.UI.ViewModel;

namespace DA.UI.Principales
{
    /// <summary>
    /// Interaction logic for AdmArbitros.xaml
    /// </summary>
    public partial class AdmArbitros : UserControl, IControlUsuario
    {
        public AdmArbitros()
        {
            InitializeComponent();
        }

        public void InicializarControl()
        {
     
        }

        public void LimpiarControl()
        {
            
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                this.DataContext = new AdmArbitroViewModel();
            }
        }
    }
}
