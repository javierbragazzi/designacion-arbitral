using System;
using System.Windows;
using System.Windows.Input;
using DA.UI.Command;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    public class MainWindowsViewModel : ViewModelBaseLocal
    {

        private Visibility _admArbitrosVisibilidad;
        
        public Visibility AdmArbitrosVisibilidad
        {
            get => _admArbitrosVisibilidad;
            set => SetProperty(ref _admArbitrosVisibilidad, value);
        }
        public ICommand EjecutarCambiarVisibilidadAdmArbitros => new DelegateCommand(CambiarVisibilidadAdmArbitros);

    
        private async void CambiarVisibilidadAdmArbitros(object o)
        {
            if (_admArbitrosVisibilidad == Visibility.Hidden)
            {
                _admArbitrosVisibilidad = Visibility.Visible;
            }
            else
            {
                _admArbitrosVisibilidad = Visibility.Hidden;
            }

        }

        /// <summary>
        /// Closings the event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="DialogClosingEventArgs"/> instance containing the event data.</param>
        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }
    }
}
