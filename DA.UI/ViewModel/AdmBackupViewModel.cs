namespace DA.UI.ViewModel
{
    public class AdmBackupViewModel : ViewModelBaseLocal
    {
        private string _directorio;
        private string _base;
        private string _nombreArchivo;

        public string Directorio
        {
            get => _directorio;
            set => SetProperty(ref _directorio, value);
        }

        public string Base
        {
            get => _base;
            set => SetProperty(ref _base, value);
        }

        public string NombreArchivo
        {
            get => _nombreArchivo;
            set => SetProperty(ref _nombreArchivo, value);
        }
    }
}
