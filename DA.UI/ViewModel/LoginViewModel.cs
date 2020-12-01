namespace DA.UI.ViewModel
{
    public class LoginViewModel : ViewModelBaseLocal
    {
        private string _usuario;

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }

        public LoginViewModel()
        {
            Usuario = "jbragazzi";
        }
    }
}
