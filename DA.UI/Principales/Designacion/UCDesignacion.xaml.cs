using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf.Transitions;

namespace DA.UI.Principales.Designacion
{
    /// <summary>
    /// Interaction logic for UCDesignacion.xaml
    /// </summary>
    public partial class UCDesignacion : UserControl
    {
        public UCDesignacion()
        {
            InitializeComponent();
        }

        private void TransitionerOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ITransitionerViewModel previousViewModel = GetViewModels(e.RemovedItems).FirstOrDefault();

            ITransitionerViewModel nextVieWModel = GetViewModels(e.AddedItems).FirstOrDefault();

            previousViewModel?.Hidden(nextVieWModel);
            nextVieWModel?.Shown(previousViewModel);

            IEnumerable<ITransitionerViewModel> GetViewModels(IList list)
            {
                return list.OfType<FrameworkElement>().Select(x => x.DataContext).OfType<ITransitionerViewModel>();
            }
        }
    }
}
