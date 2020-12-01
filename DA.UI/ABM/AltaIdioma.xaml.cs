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
using DA.BE.Observer;
using DA.SS;
using DA.UI.ViewModel;

namespace DA.UI.ABM
{
    /// <summary>
    /// Interaction logic for AltaIdioma.xaml
    /// </summary>
    public partial class AltaIdioma : UserControl, IObserverIdioma, IControlUsuario
    {
        private AltaIdiomaViewModel _viewModel;
        public AltaIdioma()
        {
            InitializeComponent();
            _viewModel = (AltaIdiomaViewModel)this.DataContext;
        }


        public void Update(IdiomaSubject idioma)
        {
            
        }

        public void InicializarControl()
        {
            
        }

        public void LimpiarControl()
        {
            
        }
    }
}
