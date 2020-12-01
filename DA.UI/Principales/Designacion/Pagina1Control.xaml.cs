using System.ComponentModel;
using System.Windows.Controls;

namespace DA.UI.Principales.Designacion
{
    /// <summary>
    /// Interaction logic for Pagina1Control.xaml
    /// </summary>
    public partial class Pagina1Control : UserControl
    {
        public Pagina1Control()
        {
            InitializeComponent();
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
        }
    }
}
