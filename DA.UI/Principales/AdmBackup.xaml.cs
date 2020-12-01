using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using DA.BE;
using DA.BE.Observer;
using DA.BLL;
using DA.SS;
using DA.UI.ViewModel;
using MaterialDesignThemes.Wpf;
using Button = System.Windows.Controls.Button;
using Leyenda = DA.BE.Leyenda;
using TextBox = System.Windows.Controls.TextBox;
using UserControl = System.Windows.Controls.UserControl;

namespace DA.UI.Principales
{
    /// <summary>
    /// Interaction logic for AdmBackup.xaml
    /// </summary>
    public partial class AdmBackup : UserControl , IObserverIdioma, IControlUsuario
    {
        public AdmBackup()
        {
            InitializeComponent();
            InicializarControl();


        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LimpiarControl();
        }

        public void Update(IdiomaSubject idioma)
        {
            if (idioma.Idioma != null)
            {


                foreach (TextBox txtBox in SingletonIdioma.FindWindowChildren<TextBox>(this))
                {
                    if (txtBox.Tag != null)
                    {
                        Leyenda leyenda = idioma.Idioma.Leyendas.Find(delegate(Leyenda leye) { return leye.Etiqueta.Equals((string) txtBox.Tag); });

                        if (leyenda != null)
                            MaterialDesignThemes.Wpf.HintAssist.SetHint(txtBox, leyenda.Traduccion.TextoTraducido);
                        //txtBox.Text = leyenda.Traduccion.TextoTraducido;
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

        private void BtnExaminar_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = @"C:\Backup";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDirectorio.Text = dialog.SelectedPath;
            }
        }

        private void BtnBackup_Click(object sender, RoutedEventArgs e)
        {
            if(!ExisteNombre())
                RealizarBackup();
            else
            {
                Mensaje vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Backup", "Ya existe un archivo de backup con ese nombre");

                DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }


        private bool ExisteNombre()
        {
            BLL.Resguardo bllBackup = new BLL.Resguardo();

            foreach (BE.Resguardo objResguardo in bllBackup.ObtenerResguardos())
            {
                if (objResguardo.NombreArchivo.ToUpper().Equals((txtNombreArchivo.Text + ".bak").ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }

        private async Task RealizarBackup()
        {
            BLL.Sistema bllSistema = new BLL.Sistema();
            BLL.Resguardo bllBackup = new BLL.Resguardo();
            BE.Resguardo resguardo = new BE.Resguardo() {Directorio = txtDirectorio.Text + @"\", NombreArchivo = txtNombreArchivo.Text + ".bak"}; 
            
            bllBackup.Agregar(resguardo);

            if (bllSistema.Backup("DesignacionArbitral", txtDirectorio.Text, txtNombreArchivo.Text))
            {
                Mensaje vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Backup", "Se realizo el backup con éxito");

                await DialogHost.Show(vieMensaje, "dhMensajes");
            }
            else
            {

                foreach (BE.Resguardo objResguardo in bllBackup.ObtenerResguardos())
                {
                    if (objResguardo.NombreArchivo.Equals(resguardo.NombreArchivo))
                    {
                        resguardo.Id = objResguardo.Id;
                        break;
                    }
                }
                
                bllBackup.Quitar(resguardo);

                Mensaje vieMensaje = new Mensaje(TipoMensaje.ERROR, "Backup", "No se pudo relizar el backup");

                await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        private void TxtDirectorio_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDirectorio.Text) && !String.IsNullOrEmpty(txtNombreArchivo.Text))
            {
                btnBackup.IsEnabled = true;
            }
            else
            {
                btnBackup.IsEnabled = false;
            }
        }

        private void TxtNombreArchivo_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombreArchivo.Text) && !String.IsNullOrEmpty(txtDirectorio.Text))
            {
                btnBackup.IsEnabled = true;
            }
            else
            {
                btnBackup.IsEnabled = false;
            }
        }

        public void InicializarControl()
        {
            this.DataContext = new AdmBackupViewModel();
        }

        public void LimpiarControl()
        {
            if (this.IsVisible == true)
            {
                txtDirectorio.Text = "";
                txtNombreArchivo.Text = "";

            }
        }
    }
}
