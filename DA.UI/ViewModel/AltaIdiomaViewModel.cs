using System.Windows.Input;
using DA.SS;
using GalaSoft.MvvmLight;
using MaterialDesignThemes.Wpf;
using RelayCommand = DA.UI.DataGrid.RelayCommand;

namespace DA.UI.ViewModel
{
    public class AltaIdiomaViewModel : ViewModelBase
    {
        private string _nombreIdioma;

        public string NombreIdioma
        {
            get => _nombreIdioma;
            set => Set(ref _nombreIdioma, value);
        }
        
        public SnackbarMessageQueue BoundMessageQueue { get; } = new SnackbarMessageQueue();

        public bool SeGuardo { get; set; }

        public ICommand RunGuardar { get; private set; }

       // public RelayCommand<string> SendMessageCommand { get; }

        public AltaIdiomaViewModel()
        {

          //  SendMessageCommand = new RelayCommand<string>(OnSendMessage);
            RunGuardar = new RelayCommand(ExecuteRunGuardar);

        }

        //private void OnSendMessage(string message)
        //{
        //    BoundMessageQueue.Enqueue(message);
        //}

        private void ExecuteRunGuardar(object obj)
        {
            BLL.Idioma bllIdioma = new BLL.Idioma();

            Resultado resultado = bllIdioma.Agregar(new BE.Idioma() {Descripcion = NombreIdioma});

            if (resultado.HayError)
            {
                BoundMessageQueue.Enqueue("Error en el alta de idioma.");
                SeGuardo = false;
            }
            else
            {
                NombreIdioma = "";
                BoundMessageQueue.Enqueue("Se dio de alta el idioma.");
                SeGuardo = true;
            }
        }
    }
}
