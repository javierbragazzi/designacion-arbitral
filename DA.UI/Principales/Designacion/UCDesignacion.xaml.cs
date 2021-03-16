namespace DA.UI.Principales.Designacion
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for UCDesignacion.xaml.
    /// </summary>
    public partial class UCDesignacion : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDesignacion"/> class.
        /// </summary>
        public UCDesignacion()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The TransitionerOnSelectionChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="SelectionChangedEventArgs"/>.</param>
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

        #endregion
    }
}
