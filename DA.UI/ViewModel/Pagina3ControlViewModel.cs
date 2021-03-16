namespace DA.UI.ViewModel
{
    using DA.BE;
    using DA.SS;
    using DA.UI.Principales.Designacion;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Pagina3ControlViewModel" />.
    /// </summary>
    public class Pagina3ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the _partidosDesignados.
        /// </summary>
        private List<PartidoHelperUI> _partidosDesignados;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagina3ControlViewModel"/> class.
        /// </summary>
        public Pagina3ControlViewModel()
        {
            FechasDisponibles = new List<Fecha>();
            PartidosDesignados = new List<PartidoHelperUI>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the FechasDisponibles.
        /// </summary>
        public List<BE.Fecha> FechasDisponibles { get; set; }

        /// <summary>
        /// Gets or sets the PartidosDesignados.
        /// </summary>
        public List<PartidoHelperUI> PartidosDesignados { get => _partidosDesignados; set => SetProperty(ref _partidosDesignados, value); }

        #endregion

        #region Methods

        /// <summary>
        /// The Hidden.
        /// </summary>
        /// <param name="newViewModel">The newViewModel<see cref="ITransitionerViewModel"/>.</param>
        public void Hidden(ITransitionerViewModel newViewModel)
        {
        }

        /// <summary>
        /// The Shown.
        /// </summary>
        /// <param name="previousViewModel">The previousViewModel<see cref="ITransitionerViewModel"/>.</param>
        public void Shown(ITransitionerViewModel previousViewModel)
        {
            Pagina2ControlViewModel pag2Vm = (Pagina2ControlViewModel)previousViewModel;

            FechasDisponibles = pag2Vm.FechasDisponibles;

            Cursor.Current = Cursors.WaitCursor;
            BLL.Designacion business = new BLL.Designacion();

            PartidosDesignados = business.RealizarDesignacion(pag2Vm.Partidos, pag2Vm.Arbitros, pag2Vm.DeporteSeleccionado);


            Cursor.Current = Cursors.Default;
        }

        #endregion
    }
}
