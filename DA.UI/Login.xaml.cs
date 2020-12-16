using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DA.BE;
using DA.BE.Observer;
using DA.SS;
using DA.UI.ViewModel;
using MaterialDesignThemes.Wpf;

namespace DA.UI
{

    public partial class Login : Window , IObserverIdioma
    {
        private EstadoBaseDeDatos _estadoBd;

        public Login()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
            InicializarComboIdioma();
            
        }

        private async Task ValidarBaseDeDatos()
        {
            BLL.DVV bllDvv = new BLL.DVV();

            _estadoBd = bllDvv.ValidarBasedeDatos();

            if (!_estadoBd.EsValida)
            {
                string mensaje = String.Empty;
                
                foreach (string registro in _estadoBd.RegistrosCorruptos)
                {
                    mensaje += registro + Environment.NewLine;
                }

                //ManejadorSesion.Instancia.ObtenerSesion().BaseValida = false;

                Mensaje vieMensaje = new Mensaje(TipoMensaje.ERROR, "Base de datos corrupta", mensaje + @"Se habilitará solo la opción de restore al iniciar sesión con el usuario de servicio");

                var resultadoMensaje = await DialogHost.Show(vieMensaje, "dhMensajes");
            }

        }

        private void InicializarComboIdioma()
        {
            BLL.Idioma bllIdioma = new  BLL.Idioma();

            cmbIdioma.ItemsSource = bllIdioma.ObtenerIdiomas();

            cmbIdioma.DisplayMemberPath = "Descripcion";

            cmbIdioma.SelectedValuePath = "Id";
        }

        private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnCerrar_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnIniciar_OnClick(object sender, RoutedEventArgs e)
        {
            IniciarSesion();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                IniciarSesion();

            }
        }

        private async void IniciarSesion()
        {
            BE.Usuario usuario = new BE.Usuario();

            if (cmbIdioma.SelectedItem != null)
            {
                BE.Idioma idioma = (BE.Idioma) ((List<BE.Idioma>)cmbIdioma.ItemsSource).ToArray().GetValue(0);

                SingletonIdioma.Instancia.IdiomaSubject.Idioma = idioma;

                SingletonIdioma.Instancia.IdiomaSubject.Descripcion = idioma.Descripcion;
            }


            usuario.NombreUsuario = txtUsuario.Text;
            usuario.Password = txtPassword.Password;

            BLL.Usuario usuarioBll = new BLL.Usuario();

            Resultado resultado = usuarioBll.IniciarSesion(usuario, _estadoBd);

            if (resultado.HayError == false)
            {
                // BLL.DVV bllDvv = new BLL.DVV();

                // BLL.Usuario bllUsuario = new BLL.Usuario();

                //  string dvh = bllUsuario.GenerarDvh(ManejadorSesion.Instancia.ObtenerSesion().Usuario);

                //bllUsuario.ActualizarDvv();

                // EstadoBaseDeDatos estado = bllDvv.ValidarBasedeDatos(true);
                //EstadoBaseDeDatos estado = bllDvv.ValidarBasedeDatos();

                //if (!estado.EsValida)
                //{
                //    string mensaje = String.Empty;

                //    foreach (string registro in estado.RegistrosCorruptos)
                //    {
                //        mensaje += registro + Environment.NewLine;
                //    }

                //    ManejadorSesion.Instancia.ObtenerSesion().EstadoBaseDeDatos.EsValida = false;

                //    Mensaje vieMensaje = new Mensaje(TipoMensaje.ERROR, "Base de datos corrupta", mensaje + @"Se habilitará solo la opción de restore");

                //    var resultadoMensaje = await DialogHost.Show(vieMensaje, "dhMensajes");
                //}
                //else
                //    ManejadorSesion.Instancia.ObtenerSesion().EstadoBaseDeDatos.EsValida = true;
                SingletonIdioma.Instancia.IdiomaSubject.Idioma = ManejadorSesion.Instancia.ObtenerSesion()?.Usuario?.Idioma;

                SingletonIdioma.Instancia.IdiomaSubject.Descripcion = ManejadorSesion.Instancia.ObtenerSesion()?.Usuario?.Idioma?.Descripcion;

                MainWindow main = new MainWindow();

                main.Show();

                this.Close();

            }
            else
            {
                Mensaje vieMensaje = new Mensaje(resultado.TipoMensaje, resultado.Titulo, resultado.Descripcion);

                await DialogHost.Show(vieMensaje, "dhMensajes");
            }

        }

        public void Update(IdiomaSubject idioma)
        {
            if (idioma.Idioma != null)
            {


                foreach (TextBox txtBox in SingletonIdioma.FindWindowChildren<TextBox>(this))
                {
                    if (txtBox.Tag != null)
                    {
                        Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                            delegate(Leyenda leye) { return leye.Etiqueta.Equals((string) txtBox.Tag); }
                        );

                        if (leyenda != null)
                            HintAssist.SetHint(txtBox, leyenda.Traduccion.TextoTraducido);
                        txtBox.Text = txtBox.Text;

                    }

                }

                foreach (TextBlock textBlock in SingletonIdioma.FindWindowChildren<TextBlock>(this))
                {
                    if (textBlock.Tag != null)
                    {
                        Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                            delegate(Leyenda leye) { return leye.Etiqueta.Equals((string) textBlock.Tag); }
                        );

                        if (leyenda != null)
                            textBlock.Text = leyenda.Traduccion.TextoTraducido;

                    }

                }

                foreach (ComboBox comboBox in SingletonIdioma.FindWindowChildren<ComboBox>(this))
                {
                    if (comboBox.Tag != null)
                    {
                        Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                            delegate(Leyenda leye) { return leye.Etiqueta.Equals((string) comboBox.Tag); }
                        );

                        if (leyenda != null)
                            HintAssist.SetHint(comboBox, leyenda.Traduccion.TextoTraducido);

                    }

                }

                foreach (PasswordBox passwordBox in SingletonIdioma.FindWindowChildren<PasswordBox>(this))
                {
                    if (passwordBox.Tag != null)
                    {
                        Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                            delegate(Leyenda leye) { return leye.Etiqueta.Equals((string) passwordBox.Tag); }
                        );

                        if (leyenda != null)
                            HintAssist.SetHint(passwordBox, leyenda.Traduccion.TextoTraducido);

                    }

                }

                foreach (Button button in SingletonIdioma.FindWindowChildren<Button>(this))
                {
                    if (button.Tag != null)
                    {
                        Leyenda leyenda = idioma.Idioma.Leyendas.Find(
                            delegate(Leyenda leye) { return leye.Etiqueta.Equals((string) button.Tag); }
                        );

                        if (leyenda != null)
                            button.Content = leyenda.Traduccion.TextoTraducido;
                    }

                }
            }
        }

        public static IEnumerable<T> FindWindowChildren<T>(DependencyObject dObj) where T : DependencyObject
        {
            if (dObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dObj); i++)
                {
                    DependencyObject ch = VisualTreeHelper.GetChild(dObj, i);


                    if (ch != null && ch is T)
                    {
                        yield return (T)ch;
                    }

                    foreach (T nestedChild in FindWindowChildren<T>(ch))
                    {
                        yield return nestedChild;
                    }
                }
            }
        }


        private void DhCamposVacios_Loaded(object sender, RoutedEventArgs e)
        {
            Subject.AddObserver(this);
        }

        private void CmbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized) return;

            if (cmbIdioma.SelectedItem is BE.Idioma idioma)
            {
                SingletonIdioma.Instancia.IdiomaSubject.Idioma = idioma;

                SingletonIdioma.Instancia.IdiomaSubject.Descripcion = idioma.Descripcion;
            }
        }

   
        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            await ValidarBaseDeDatos();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
                Ayuda.Mostrar();
          
        }
    }
}
