using System;
using System.Windows;
using System.Windows.Controls;
using DA.SS;
using DA.UI.ViewModel;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ABM
{
    /// <summary>
    /// Interaction logic for AltaUsuario.xaml
    /// </summary>
    public partial class AmUsuario : UserControl
    {
        public AmUsuario()
        {
            InitializeComponent();
        }


        private void btnAceptar_Click_1(object sender, RoutedEventArgs e)
        {
            BLL.Usuario bllUsuario = new BLL.Usuario();
            BE.Usuario beUsuario = new BE.Usuario();

            BE.Idioma idioma = ((AmUsuarioViewModel)this.DataContext).IdiomaSeleccionado;

            beUsuario.Nombre = txtNombre.Text;
            beUsuario.Apellido = txtApellido.Text;
            beUsuario.NombreUsuario = txtNombreUsu.Text;
            beUsuario.Password = txtPassword.Password;
            string passVal = txtPasswordVal.Password;
            beUsuario.Idioma = idioma;
            beUsuario.Activo = true;
            int idPermiso = ((AmUsuarioViewModel) this.DataContext).PermisosComponenteSeleccionado.Id;


            if (ValidarNombreUsuarioExiste(beUsuario.NombreUsuario))
            {
                Mensaje vieMensaje = new Mensaje(TipoMensaje.ERROR,SingletonIdioma.Instancia.ObtenerTraduccion("titNombreUsu"), SingletonIdioma.Instancia.ObtenerTraduccion("MenNombreUsuExiste"));
                DialogHost.Show(vieMensaje, "dhMensajes");

                return;

            }

            if (!ValidarPassword(beUsuario.Password, passVal))
            {
                Mensaje vieMensaje = new Mensaje(TipoMensaje.ERROR,SingletonIdioma.Instancia.ObtenerTraduccion("titPassword"), SingletonIdioma.Instancia.ObtenerTraduccion("MenPasswordTexto"));
                DialogHost.Show(vieMensaje, "dhMensajes");

                return;

            }
            
            Resultado resultado = bllUsuario.Agregar(beUsuario, idPermiso);

            Mensaje mensajeResult;

            if (!resultado.HayError)
            {
                ((AmUsuarioViewModel) this.DataContext).SeGuardo = true;
                Limpiar();
                mensajeResult = new Mensaje(TipoMensaje.CORRECTO, SingletonIdioma.Instancia.ObtenerTraduccion("TituloOperacion"), SingletonIdioma.Instancia.ObtenerTraduccion("OperacionOk"));
            }
            else
            {
                ((AmUsuarioViewModel) this.DataContext).SeGuardo = false;
                mensajeResult = new Mensaje(TipoMensaje.ERROR,SingletonIdioma.Instancia.ObtenerTraduccion("TituloOperacion"), SingletonIdioma.Instancia.ObtenerTraduccion("OperacionError"));

            }

            var result = DialogHost.Show(mensajeResult, "dhMensajes");
            
        }

        private bool ValidarPassword(string pass1, string pass2)
        {
            if (String.IsNullOrEmpty(pass1) || string.IsNullOrEmpty(pass2))
            {
                return false;
            }

            if (pass1.Equals(pass2))
            {
                return true;
            }

            return false;
        }

        private bool ValidarNombreUsuarioExiste(string nombreUsu)
        {
            BLL.Usuario bllUsuario = new BLL.Usuario();

            if (bllUsuario.ObtenerUsuarioPorNombreDeUsuario(nombreUsu) == null)
                return false;

            return true;

        }

        private void Limpiar()
        {
            ((AmUsuarioViewModel) this.DataContext).Nombre = "";
            ((AmUsuarioViewModel) this.DataContext).Apellido = "";
            ((AmUsuarioViewModel) this.DataContext).NombreUsuario = "";
            ((AmUsuarioViewModel) this.DataContext).Password = "";
            ((AmUsuarioViewModel) this.DataContext).RepitePassword = "";
            txtPassword.Password = "";
            txtPasswordVal.Password = "";
        }
    }
}
