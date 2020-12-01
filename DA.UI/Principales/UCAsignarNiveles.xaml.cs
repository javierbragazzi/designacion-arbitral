using System.Windows;
using System.Windows.Controls;
using DA.UI.ViewModel;

namespace DA.UI.Principales
{
    /// <summary>
    /// Lógica de interacción para AsignarNiveles.xaml
    /// </summary>
    public partial class UCAsignarNiveles : UserControl
    {
        public UCAsignarNiveles()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                this.DataContext = new UCAsignarNivelesViewModel();
            }
        }
    }
}
