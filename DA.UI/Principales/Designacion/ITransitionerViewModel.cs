namespace DA.UI.Principales.Designacion
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="ITransitionerViewModel" />.
    /// </summary>
    public interface ITransitionerViewModel
    {
        #region Methods

        /// <summary>
        /// The Hidden.
        /// </summary>
        /// <param name="newViewModel">The newViewModel<see cref="ITransitionerViewModel"/>.</param>
        void Hidden(ITransitionerViewModel newViewModel);

        /// <summary>
        /// The Shown.
        /// </summary>
        /// <param name="previousViewModel">The previousViewModel<see cref="ITransitionerViewModel"/>.</param>
        void Shown(ITransitionerViewModel previousViewModel);

        #endregion
    }

    #endregion
}
