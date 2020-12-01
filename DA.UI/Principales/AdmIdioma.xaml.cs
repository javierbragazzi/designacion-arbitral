using System;
using System.Collections.Generic;
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
using DA.UI.ViewModel;

namespace DA.UI.Principales
{
    /// <summary>
    /// Interaction logic for AdmIdioma.xaml
    /// </summary>
    public partial class AdmIdioma : UserControl
    {
        public AdmIdioma()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                this.DataContext = new AdmIdiomaViewModel();
            }
        }
    }
}
