using System;
using System.Collections.Generic;
using System.Windows.Input;
using DA.BE;
using DA.BE.Composite;
using DA.SS;
using DA.UI.Command;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    /// <summary>
    /// ViewModel para la pantalla AmUsuarios
    /// </summary>
    /// <seealso cref="ViewModelBaseLocal" />
    public class AmUsuarioViewModel : ViewModelBaseLocal
    {

        /// <summary>
        /// The nombre
        /// </summary>
        private string _nombre;

        /// <summary>
        /// The apellido
        /// </summary>
        private string _apellido;

        /// <summary>
        /// The nombre usuario
        /// </summary>
        private string _nombreUsuario;

        /// <summary>
        /// The password
        /// </summary>
        private string _password;

        /// <summary>
        /// The repite password
        /// </summary>
        private string _repitePassword;

        private List<PermisoComponente> _permisosComponentes;

        public List<PermisoComponente> PermisosComponentes
        {
            get => _permisosComponentes;
            set => SetProperty(ref _permisosComponentes, value);
        }

        private PermisoComponente _permisosComponenteSeleccionado;

        public PermisoComponente PermisosComponenteSeleccionado
        {
            get => _permisosComponenteSeleccionado;
            set => SetProperty(ref _permisosComponenteSeleccionado, value);
        }

        private List<BE.Idioma> _idiomas;

        private BE.Idioma _idiomaSeleccionado;

        public BE.Usuario Usuario;

        public AmUsuarioViewModel()
        {
            Usuario = new Usuario();
            
            InicializarComboIdioma();

            IdiomaSeleccionado = SingletonIdioma.Instancia.IdiomaSubject.Idioma;

            CargarGruposPermisos();

            PermisosComponenteSeleccionado = (PermisoComponente)PermisosComponentes.ToArray().GetValue(0);

            RunCerrar = new RelayCommand(ExecuteRunCerrar);

            

        }

        
        private async void ExecuteRunCerrar(object obj)
        {
            SeCancelo = true;

            DialogHost.CloseDialogCommand.Execute(null,null);

        }

        public void CargarGruposPermisos()
        {
            BLL.Permiso bllPermiso = new BLL.Permiso();

            PermisosComponentes = bllPermiso.ObtenerGruposPermisos();

        }

        private void InicializarComboIdioma()
        {
            BLL.Idioma bllIdioma = new  BLL.Idioma();

            Idiomas = bllIdioma.ObtenerIdiomas();

        }

        public ICommand RunCerrar { get; private set; }

        public BE.Idioma IdiomaSeleccionado
        {
            get => _idiomaSeleccionado;
            set => SetProperty(ref _idiomaSeleccionado, value);
        }

        public List<BE.Idioma> Idiomas
        {
            get => _idiomas;
            set => SetProperty(ref _idiomas, value);
        }

        public bool SeCancelo { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        /// <summary>
        /// Gets or sets the apellido.
        /// </summary>
        /// <value>
        /// The apellido.
        /// </value>
        public string Apellido
        {
            get => _apellido;
            set => SetProperty(ref _apellido, value);
        }

        /// <summary>
        /// Gets or sets the nombre usuario.
        /// </summary>
        /// <value>
        /// The nombre usuario.
        /// </value>
        public string NombreUsuario
        {
            get => _nombreUsuario;
            set => SetProperty(ref _nombreUsuario, value);
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        /// <summary>
        /// Gets or sets the repite password.
        /// </summary>
        /// <value>
        /// The repite password.
        /// </value>
        public string RepitePassword
        {
            get => _repitePassword;
            set => SetProperty(ref _repitePassword, value);
        }

        public bool SeGuardo { get; set; }
    }
}
